
namespace TP4_USB_GEN_SOFT
{
    partial class form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form1));
            this.cmbChoixSignal = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudFrequence = new System.Windows.Forms.NumericUpDown();
            this.nudAmplitude = new System.Windows.Forms.NumericUpDown();
            this.nudOffset = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPortCOM = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSEND = new System.Windows.Forms.TextBox();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.btnSAVE = new System.Windows.Forms.Button();
            this.btnSEND = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnUpdatePortCOM = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnSendCount = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrequence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmplitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbChoixSignal
            // 
            this.cmbChoixSignal.FormattingEnabled = true;
            this.cmbChoixSignal.Items.AddRange(new object[] {
            "Carré",
            "Triangle",
            "Dent de scie",
            "Sinus"});
            this.cmbChoixSignal.Location = new System.Drawing.Point(178, 67);
            this.cmbChoixSignal.Name = "cmbChoixSignal";
            this.cmbChoixSignal.Size = new System.Drawing.Size(99, 21);
            this.cmbChoixSignal.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GrayText;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choix signal :";
            // 
            // nudFrequence
            // 
            this.nudFrequence.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudFrequence.Location = new System.Drawing.Point(178, 113);
            this.nudFrequence.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudFrequence.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudFrequence.Name = "nudFrequence";
            this.nudFrequence.Size = new System.Drawing.Size(99, 20);
            this.nudFrequence.TabIndex = 2;
            this.nudFrequence.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // nudAmplitude
            // 
            this.nudAmplitude.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudAmplitude.Location = new System.Drawing.Point(178, 159);
            this.nudAmplitude.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudAmplitude.Name = "nudAmplitude";
            this.nudAmplitude.Size = new System.Drawing.Size(99, 20);
            this.nudAmplitude.TabIndex = 3;
            // 
            // nudOffset
            // 
            this.nudOffset.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudOffset.Location = new System.Drawing.Point(178, 204);
            this.nudOffset.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudOffset.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.nudOffset.Name = "nudOffset";
            this.nudOffset.Size = new System.Drawing.Size(99, 20);
            this.nudOffset.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GrayText;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Amplitude     :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.GrayText;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fréquence   :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.GrayText;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Offset            :";
            // 
            // cmbPortCOM
            // 
            this.cmbPortCOM.FormattingEnabled = true;
            this.cmbPortCOM.Location = new System.Drawing.Point(583, 68);
            this.cmbPortCOM.Name = "cmbPortCOM";
            this.cmbPortCOM.Size = new System.Drawing.Size(148, 21);
            this.cmbPortCOM.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GrayText;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(361, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "Port COM :";
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(364, 104);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(160, 29);
            this.btnOpen.TabIndex = 10;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(583, 104);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(148, 29);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.GrayText;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(360, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 24);
            this.label6.TabIndex = 12;
            this.label6.Text = "Message envoyé :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.GrayText;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(360, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 24);
            this.label7.TabIndex = 13;
            this.label7.Text = "Message reçu      :";
            // 
            // txtSEND
            // 
            this.txtSEND.Location = new System.Drawing.Point(532, 158);
            this.txtSEND.Name = "txtSEND";
            this.txtSEND.Size = new System.Drawing.Size(199, 20);
            this.txtSEND.TabIndex = 14;
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(532, 203);
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.Size = new System.Drawing.Size(199, 20);
            this.txtReceive.TabIndex = 15;
            // 
            // btnSAVE
            // 
            this.btnSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSAVE.Location = new System.Drawing.Point(44, 259);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(233, 68);
            this.btnSAVE.TabIndex = 16;
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.UseVisualStyleBackColor = true;
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // btnSEND
            // 
            this.btnSEND.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSEND.Location = new System.Drawing.Point(365, 259);
            this.btnSEND.Name = "btnSEND";
            this.btnSEND.Size = new System.Drawing.Size(160, 68);
            this.btnSEND.TabIndex = 17;
            this.btnSEND.Text = "SEND";
            this.btnSEND.UseVisualStyleBackColor = true;
            this.btnSEND.Click += new System.EventHandler(this.btnSEND_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.GrayText;
            chartArea1.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.Maximum = 100D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX2.Maximum = 2000D;
            chartArea1.AxisX2.Minimum = 20D;
            chartArea1.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.Maximum = 65535D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY2.Maximum = 10D;
            chartArea1.AxisY2.Minimum = -10D;
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.BorderColor = System.Drawing.Color.Bisque;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(752, 28);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(426, 341);
            this.chart1.TabIndex = 18;
            this.chart1.Text = "chart1";
            // 
            // btnUpdatePortCOM
            // 
            this.btnUpdatePortCOM.Location = new System.Drawing.Point(464, 67);
            this.btnUpdatePortCOM.Name = "btnUpdatePortCOM";
            this.btnUpdatePortCOM.Size = new System.Drawing.Size(61, 20);
            this.btnUpdatePortCOM.TabIndex = 19;
            this.btnUpdatePortCOM.Text = "Update";
            this.btnUpdatePortCOM.UseVisualStyleBackColor = true;
            this.btnUpdatePortCOM.Click += new System.EventHandler(this.BtnUpdatePortCOM_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnSendCount
            // 
            this.btnSendCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendCount.Location = new System.Drawing.Point(571, 259);
            this.btnSendCount.Name = "btnSendCount";
            this.btnSendCount.Size = new System.Drawing.Size(160, 68);
            this.btnSendCount.TabIndex = 20;
            this.btnSendCount.Text = "SEND COUNT";
            this.btnSendCount.UseVisualStyleBackColor = true;
            this.btnSendCount.Click += new System.EventHandler(this.btnSendCount_Click);
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(1212, 398);
            this.Controls.Add(this.btnSendCount);
            this.Controls.Add(this.btnUpdatePortCOM);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnSEND);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.txtSEND);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbPortCOM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudOffset);
            this.Controls.Add(this.nudAmplitude);
            this.Controls.Add(this.nudFrequence);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbChoixSignal);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form1";
            this.Text = "TP4_USB_GEN";
            ((System.ComponentModel.ISupportInitialize)(this.nudFrequence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmplitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbChoixSignal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudFrequence;
        private System.Windows.Forms.NumericUpDown nudAmplitude;
        private System.Windows.Forms.NumericUpDown nudOffset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPortCOM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSEND;
        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.Button btnSAVE;
        private System.Windows.Forms.Button btnSEND;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnUpdatePortCOM;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnSendCount;
    }
}

