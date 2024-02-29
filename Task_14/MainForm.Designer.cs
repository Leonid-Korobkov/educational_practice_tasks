namespace Task_14
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.inputSizeN = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.inputIntervalTimeMs = new System.Windows.Forms.NumericUpDown();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.inputSizeN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputIntervalTimeMs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(1312, 32);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(157, 71);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(1496, 32);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(157, 71);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Стоп";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // inputSizeN
            // 
            this.inputSizeN.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.inputSizeN.Location = new System.Drawing.Point(1312, 163);
            this.inputSizeN.Margin = new System.Windows.Forms.Padding(6);
            this.inputSizeN.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.inputSizeN.Name = "inputSizeN";
            this.inputSizeN.Size = new System.Drawing.Size(240, 31);
            this.inputSizeN.TabIndex = 12;
            this.inputSizeN.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1307, 132);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Размер поля N";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1307, 242);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Интервал времени (мс)";
            // 
            // label
            // 
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.ForeColor = System.Drawing.Color.IndianRed;
            this.label.Location = new System.Drawing.Point(1308, 330);
            this.label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(345, 96);
            this.label.TabIndex = 9;
            this.label.Text = "Чтобы применить настройки необходимо нажать на кнопку стоп, затем изменить настро" +
    "йки и только потом нажать на старт\r\n";
            // 
            // inputIntervalTimeMs
            // 
            this.inputIntervalTimeMs.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.inputIntervalTimeMs.Location = new System.Drawing.Point(1312, 273);
            this.inputIntervalTimeMs.Margin = new System.Windows.Forms.Padding(6);
            this.inputIntervalTimeMs.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.inputIntervalTimeMs.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.inputIntervalTimeMs.Name = "inputIntervalTimeMs";
            this.inputIntervalTimeMs.Size = new System.Drawing.Size(240, 31);
            this.inputIntervalTimeMs.TabIndex = 13;
            this.inputIntervalTimeMs.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1694, 1000);
            this.Controls.Add(this.inputIntervalTimeMs);
            this.Controls.Add(this.inputSizeN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.inputSizeN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputIntervalTimeMs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.NumericUpDown inputSizeN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.NumericUpDown inputIntervalTimeMs;
        private System.Windows.Forms.Timer timer;
    }
}