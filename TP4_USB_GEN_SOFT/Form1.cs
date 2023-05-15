using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;




namespace TP4_USB_GEN_SOFT
{

    

    public partial class form1 : Form
    {
        //Variables globales
        
        byte[] Mess1 = new byte[29];                //tb du message à envoyer
        bool Sauvegarde = false;                    //Etat de sauvegarde

        //Constantes

        const int m_MessSize = 29;              
        const int nbMAX = 100;
        const double MAX_ECH = 100;
        const double MAX_VAL = 65535;
        const double MIN_VAL = 0;
        const double DEFAULT_OFFSET = 32767;


        // Pour le graphique du signal (init)

        double[] SignalValues = new double[100];    //tb des val pour la gen. du signal
        private List<Point> lstSignalValues = new List<Point>();
        private double amplitude = 32767;
        private double A = 0;
        public delegate void ReceiverD();
        public ReceiverD myDelegate;


        //Constructeur de la Form
        public form1()
        {
            InitializeComponent();

            //Choix du Carré par défaut
            cmbChoixSignal.SelectedIndex = 0;

            //Regarder les ports disponibles
            CheckPortCOM();

            //Initalisation du graphique
            A = (amplitude * 2) / nbMAX;

            // Ajout des valeurs dans la liste de points
            for (int i = 0; i<nbMAX; i+=1)
            {
                lstSignalValues.Add(new Point(i, (A * i)));
            }
            // Ajout des points dans le graphique
            foreach (Point item in lstSignalValues)
            {
                chart1.Series[0].Points.AddXY(item.GetPosition(), item.GetValue());
            }

            //Notion de delegate (sous-tâches) pour la réception des données
            myDelegate = new ReceiverD(ReceiveData);
        }

        ///////////////////////////////////////////////////////////////////////////////////
        //------------------------------Sauvegarde---------------------------------------//
        ///////////////////////////////////////////////////////////////////////////////////
        
        private void btnSAVE_Click(object sender, EventArgs e)
        {
            //Change l'état de la sauvegarde à true
            Sauvegarde = true;
        }

        ///////////////////////////////////////////////////////////////////////////////////
        //------------------------------Port COM ----------------------------------------//
        ///////////////////////////////////////////////////////////////////////////////////
        public void CheckPortCOM()
        {
            //Donner une liste des noms des ports disponibles
            string[] ports = SerialPort.GetPortNames();

            for (int i = 0; i <= ports.Length - 1; i++)
            {
                cmbPortCOM.Items.Add(ports[i]);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
            {
                // Configuration du port
                serialPort1.PortName = (string)cmbPortCOM.SelectedItem;
                serialPort1.BaudRate = 57600;
                serialPort1.Parity = Parity.None;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Handshake = Handshake.RequestToSend;

                // Set the read/write timeouts
                serialPort1.ReadTimeout = 500;
                serialPort1.WriteTimeout = 500;

                //Ouverir le port
                serialPort1.Open();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //Fermer le port
            serialPort1.Close();
        }

        private void BtnUpdatePortCOM_Click(object sender, EventArgs e)
        {
            //Suprimer la liste des Port
            cmbPortCOM.Items.Clear();
            //Ré-écrire une liste des ports disponibles
            CheckPortCOM();
        }

        ///////////////////////////////////////////////////////////////////////////////////
        //----------------------------Réception du message-------------------------------//
        ///////////////////////////////////////////////////////////////////////////////////
        public void ReceiveData()
        {
            //Variables
            int i;                          //compteur                     
            int j;                          //compteur 
            byte[] RxMess = new byte[30];   //tb Réception du message

            /*Traitement de la reception*/
            //Contrôle de la première donnée
            do
            {
                RxMess[0] = (byte)serialPort1.ReadByte();
            } while (RxMess[0] != Convert.ToByte('!'));

            //Si on a envoyé toutes les données
            if (serialPort1.BytesToRead >= 28)
            {
                //Ecrire les données reçues dans un tb
                for (i = 1; i < 29; i++)
                {
                    RxMess[i] = (byte)serialPort1.ReadByte();
                }
            }

            //Si on a une sauvegarde
            if (RxMess[27].ToString() == "49") //49 ASCII = 1
            {
                //Quittance sauvegarde
                MessageBox.Show("Backup done", "Warning !");
            }

            //Mettre à jour le txt de réception
            txtReceive.Text = Encoding.ASCII.GetString(RxMess);
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Faire en sous-taches l'écriture des données réceptionnées 
            txtReceive.Invoke(myDelegate);
        }

        ///////////////////////////////////////////////////////////////////////////////////
        //------------------------------Envoi du message---------------------------------//
        ///////////////////////////////////////////////////////////////////////////////////
        private void btnSEND_Click(object sender, EventArgs e)
        {
            SendMessage();              //Envoyer le message
            timer1.Stop();              //Stoper le timer
            CalculAndRefreshChart();    //Mettre à jour le graph avec les données envoyées
        }

        private void btnSendCount_Click(object sender, EventArgs e)
        {
            CalculAndRefreshChart();    //Mettre à jour le graph avec les données envoyées
            timer1.Interval = 25;       //Pour 1 message chaque 25 ms
            timer1.Start();             //Active le timer
        }

        private void timer1_Tick(object sender, EventArgs e)
        {           
            SendMessage();              //Envoi le message en continu
        }

        ///////////////////////////////////////////////////////////////////////////////////
        //----------------------------------Méthodes-------------------------------------//
        ///////////////////////////////////////////////////////////////////////////////////
        /// 
        /// Choix de la forme
        /// 
        private string ChoixForme()
        {
            //Variables
            string ChoixForme = "";

            ////Récupération de la selection de la Forme selon le choix
            if ("Carré" == cmbChoixSignal.SelectedItem.ToString())
            {
                ChoixForme = "S=C";
            }
            else if ("Triangle" == cmbChoixSignal.SelectedItem.ToString())
            {
                ChoixForme = "S=T";
            }
            else if ("Sinus" == cmbChoixSignal.SelectedItem.ToString())
            {
                ChoixForme = "S=S";
            }
            else if ("Dent de scie" == cmbChoixSignal.SelectedItem.ToString())
            {
                ChoixForme = "S=D";
            }

            return ChoixForme;
        }
        /// 
        /// Envoi du message
        /// 
        void SendMessage()
        {          
            int NbCharMess;
            
            // Envoi le message si le port est ouvert
            if (serialPort1.IsOpen == true)
            {

                // Compose le message 
                ComposeMessage(ref Mess1);
                NbCharMess = m_MessSize;
                
                //Ecriture des données
                try
                {
                    serialPort1.Write(Mess1, 0, NbCharMess);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Write Mess1");
                }
                
            }
            else
            {
                //Indication que le port n'est pas ouvert
                MessageBox.Show("Port is not open", "Warning !");              
            }          
        }
        /// 
        /// Composition du message
        /// 
        void ComposeMessage(ref byte[] Mess)
        {
            //Variables
            string Start = "!";
            string Save = "";
            string Offset = "";
           
            //Récupération de la selection de la Forme
            string Forme = ChoixForme();

            //Récupération de la selection de la Frequence
            string Frequence = "F=" + nudFrequence.Value.ToString("0000");

            //Récupération de la selection de l'Amplitude
            string Amplitude = "A=" + nudAmplitude.Value.ToString("00000");

            //Récupération de la selection de l'Offset
            if (nudOffset.Value >= 0)
            {
                Offset = "O=" + "+" + nudOffset.Value.ToString("0000");
            }
            else
            {
                Offset = "O=" + nudOffset.Value.ToString("0000");
            }

            //Récupération de l'état de la sauvegarde
            if (Sauvegarde == true)
            {
                Save = "WP=1#";
            }
            else
            {
                Save = "WP=0#";
            }

            //Composition du message
            string Message = Start + Forme + Frequence + Amplitude + Offset + Save;
            txtSEND.Text = Message;
            Mess = Encoding.ASCII.GetBytes(Message);

            //Remettre à 0 la sauvegarde
            Sauvegarde = false;         
        }
        /// 
        /// Calcul pour le chart
        /// 
        void CalculAndRefreshChart()
        {
            //Variables
            double Offset =  2.0*double.Parse(nudOffset.Value.ToString());
            double Amplitude = 2.0* double.Parse(nudAmplitude.Value.ToString());
            int i = 0;
            double Resultat = 0;
            double pointValue = (DEFAULT_OFFSET - Amplitude);
            double CalculOffset = 0;

            //Mettre à 0 les valeurs du chart
            chart1.Series[0].Points.Clear();

            //Calculs des signaux
            for (i = 0; i<= MAX_ECH-1; i++)
            {
                switch (ChoixForme())
                {
                    case "S=C":
                        if (i < (MAX_ECH / 2))
                        {
                            SignalValues[i] = Amplitude + 1 + DEFAULT_OFFSET; ;
                        }
                        else
                        {
                            SignalValues[i] = -Amplitude + DEFAULT_OFFSET;
                        }
                        break;

                    case "S=T":
                        SignalValues[i] = pointValue + 0.5;
                        if (i < (MAX_ECH / 2))
                        {
                            pointValue = pointValue + (Amplitude * 2.0 + 1.0) / (MAX_ECH / 2.0);
                        }
                        else
                        {
                            pointValue = pointValue - (Amplitude * 2.0 + 1.0) / (MAX_ECH / 2.0);
                        }
                        break;

                    case "S=S":
                        Resultat = Amplitude * Math.Sin(2.0 * Math.PI * i / MAX_ECH) + 0.5 + DEFAULT_OFFSET;
                        SignalValues[i] = Resultat;
                        break;

                    case "S=D":
                        SignalValues[i] = pointValue + 0.5;
                        pointValue = pointValue + (Amplitude * 2.0 + 1.0) / (MAX_ECH - 1.0);
                        break;
                }       
            }

            // Ajout de l'offset au signal plus fixation des limites max et min
            for (i = 0; i <= MAX_ECH - 1; i++)
            {
                CalculOffset = SignalValues[i] + Offset;
                if (CalculOffset > MAX_VAL)
                {
                    CalculOffset = MAX_VAL;
                }
                else if (CalculOffset < MIN_VAL)
                {
                    CalculOffset = MIN_VAL;
                }
                SignalValues[i] = CalculOffset;

                //Mettre à jour le signal
                chart1.Series[0].Points.AddXY(i, SignalValues[i]);
            }           
        }
    }
}
