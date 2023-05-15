using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace AppCsTp2Pwm
{
    public partial class Form1 : Form
    {
        public delegate void ReceiverD();
        public ReceiverD myDelegate;
        int m_SendCount = 0;
        int m_DispCount = 0;
        byte[] Mess1 = new byte[5];

        const byte stx = 0xAA;
        const int m_MessSize = 5;
        CalCrc16 MyCrc = new CalCrc16();

        public Form1()
        {
            InitializeComponent();
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();
            cboPortNames.Items.AddRange(ports);
            cboPortNames.SelectedIndex = 0;
            lstDataIn.Items.Clear();

            myDelegate = new ReceiverD(DispInListRxData);

        }

        void composeMessage( ref byte[] Mess)
        {
            ushort crc = 0xFFFF;
            sbyte TmpVal;
            Mess[0] = stx;
            crc = MyCrc.updateCRC16(crc, stx);
            TmpVal = (sbyte)nudVitesse.Value;
            // Mess[1] = ConvSignedToByte(TmpVal);
            Mess[1] = (byte)TmpVal;
            crc = MyCrc.updateCRC16(crc, Mess[1]);
            TmpVal = (sbyte)nudAngle.Value;
            //Mess[2] = ConvSignedToByte(TmpVal);
            Mess[2] = (byte)TmpVal;
            crc = MyCrc.updateCRC16(crc, Mess[2]);
            Mess[3] = (byte)(crc >> 8);      // attention MSB
            Mess[4] = (byte)(crc & 0xFF);    // attention LSB
            if (chkDispTX.Checked == true) {
                txtDispTX.Text = "";
                for (int i = 0; i < 5; i++) {
                    txtDispTX.Text = txtDispTX.Text  + NumToHex(Mess[i]) + " ";
                }
            }
        }

        // compose un message raccourci sans le CRC
        void composeBadMessage(ref byte[] Mess)
        {
            // compose un message raccourci sans le CRC
            sbyte TmpVal;
            Mess[0] = stx;
            TmpVal = (sbyte)nudVitesse.Value;
            Mess[1] = (byte)TmpVal;
            TmpVal = (sbyte)nudAngle.Value;
            Mess[2] = (byte)TmpVal;

            if (chkDispTX.Checked == true)
            {
                txtDispTX.Text = "";
                for (int i = 0; i < 3; i++)
                {
                    txtDispTX.Text = txtDispTX.Text + NumToHex(Mess[i]) + " ";
                }
            }
        }    
    
               
        string NumToHex(byte val)
        {
            string tmp = val.ToString("X");
            if (tmp.Length < 2)
            {
                tmp = "0" + tmp;
            }
            return tmp;
        }

        void SendMessage(int count)
        {
            int NbCharMess;
            // Envoi le message si le port est ouvert
            if (serialPort1.IsOpen == true) {
                // Compose et envoie le message canal 1
                if ((chkBad.Checked == true) && (count % 10 == 0) ) {
                    composeBadMessage(ref Mess1);
                    NbCharMess = m_MessSize - 2;
                } else
                {
                    composeMessage(ref Mess1);
                    NbCharMess = m_MessSize;
                }

                try {
                    serialPort1.Write(Mess1, 0, NbCharMess);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Write Mess1");
                }

            } else { 
                MessageBox.Show("Port is not open", "Test PWM 2016");
                timer1.Stop();     // pour éviter problème en mode continu
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false) {
                // Configuration du port
                serialPort1.PortName = (string)cboPortNames.SelectedItem;
                serialPort1.BaudRate  = 57600;
                serialPort1.Parity    = Parity.None;
                serialPort1.DataBits  = 8;
                serialPort1.StopBits  = StopBits.One;
                serialPort1.Handshake = Handshake.RequestToSend;

                // Set the read/write timeouts
                serialPort1.ReadTimeout = 500;
                serialPort1.WriteTimeout = 500;
                                
                serialPort1.Open();
           
            }
        } // end btnOpen_Click

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            lstDataIn.Invoke(myDelegate);
          
        }

        public void DispInListRxData()
        {
            int i;
            byte[] RxMess = new byte[5];
            ushort Crc;
            short tmpVal;
           
            // Traitement de la réception
            do
            {
                RxMess[0] = (byte)serialPort1.ReadByte();
            } while (RxMess[0] != stx);

            if (serialPort1.BytesToRead >= 4)
            {

                for (i = 1; i < 5; i++)
                {
                    RxMess[i] = (byte)serialPort1.ReadByte();
                }

                // Calcul du CRC sur les 5 premiers
                Crc = 0xFFFF;
                for (i = 0; i < 5; i++)
                {
                    Crc = MyCrc.updateCRC16(Crc, RxMess[i]);
                }

                if (Crc == 0)
                {
                    txtVitesse.Text = ConvUsignedToSignedString(RxMess[1]);
                    txtAngle.Text = ConvUsignedToSignedString(RxMess[2]);
                }
                else
                {
                    txtVitesse.Text = "Bad CRC";
                }

                //Affichage de la trame recue
                if (chkDispRX.Checked == true)
                {
                    string tmp = "";
                    for (i = 0; i < 5; i++)
                    {
                        tmp = tmp + NumToHex(RxMess[i]) + " ";
                    }
                    lstDataIn.Items.Add(tmp);
                    m_DispCount++;
                    if (m_DispCount > 20)
                    {
                        lstDataIn.Items.Clear();
                        m_DispCount = 0;
                    }
                }
            }
        }

        string ConvUsignedToSignedString(byte val)
        {
            string Res = "";
            short tmp;
            if (val < 128) {
                tmp = val;
            } else
            {
                tmp = val;
                tmp -= 256;
            }
            Res = tmp.ToString();
            return Res;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            // Envoi le message si le port est ouvert
            m_SendCount = 0;
            SendMessage(m_SendCount);
            timer1.Stop();
        }

        private void btnSendContinuous_Click(object sender, EventArgs e)
        {
            timer1.Interval = 50;  // pour 1 message chaque 50 ms
            m_SendCount = 0;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Envoi le message si le port est ouvert
            m_SendCount = m_SendCount + 1;
            SendMessage(m_SendCount);
        }
    }
}
