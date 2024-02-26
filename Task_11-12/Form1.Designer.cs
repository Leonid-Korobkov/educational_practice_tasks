namespace Task_11_12
{
    partial class Form1
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
            this.BtnShowSolution = new System.Windows.Forms.Button();
            this.BtnUnlockCells = new System.Windows.Forms.Button();
            this.BtnNewGame = new System.Windows.Forms.Button();
            this.BtnLoadSave = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnConditionImposed = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnShowSolution
            // 
            this.BtnShowSolution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BtnShowSolution.Location = new System.Drawing.Point(855, 91);
            this.BtnShowSolution.Margin = new System.Windows.Forms.Padding(10);
            this.BtnShowSolution.Name = "BtnShowSolution";
            this.BtnShowSolution.Size = new System.Drawing.Size(189, 81);
            this.BtnShowSolution.TabIndex = 0;
            this.BtnShowSolution.Text = "Показать решение";
            this.BtnShowSolution.UseVisualStyleBackColor = false;
            this.BtnShowSolution.Click += new System.EventHandler(this.BtnShowSolution_Click);
            // 
            // BtnUnlockCells
            // 
            this.BtnUnlockCells.Location = new System.Drawing.Point(855, 394);
            this.BtnUnlockCells.Margin = new System.Windows.Forms.Padding(10);
            this.BtnUnlockCells.Name = "BtnUnlockCells";
            this.BtnUnlockCells.Size = new System.Drawing.Size(189, 81);
            this.BtnUnlockCells.TabIndex = 9;
            this.BtnUnlockCells.Text = "Разблокировать ячейки";
            this.BtnUnlockCells.UseVisualStyleBackColor = true;
            this.BtnUnlockCells.Click += new System.EventHandler(this.BtnUnlockCells_Click);
            // 
            // BtnNewGame
            // 
            this.BtnNewGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BtnNewGame.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnNewGame.Location = new System.Drawing.Point(855, 192);
            this.BtnNewGame.Margin = new System.Windows.Forms.Padding(10);
            this.BtnNewGame.Name = "BtnNewGame";
            this.BtnNewGame.Size = new System.Drawing.Size(189, 81);
            this.BtnNewGame.TabIndex = 8;
            this.BtnNewGame.Text = "Новая игра";
            this.BtnNewGame.UseVisualStyleBackColor = false;
            this.BtnNewGame.Click += new System.EventHandler(this.BtnNewGame_Click);
            // 
            // BtnLoadSave
            // 
            this.BtnLoadSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtnLoadSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnLoadSave.Location = new System.Drawing.Point(855, 596);
            this.BtnLoadSave.Margin = new System.Windows.Forms.Padding(10);
            this.BtnLoadSave.Name = "BtnLoadSave";
            this.BtnLoadSave.Size = new System.Drawing.Size(189, 99);
            this.BtnLoadSave.TabIndex = 7;
            this.BtnLoadSave.Text = "Загрузить сохраненное решение";
            this.BtnLoadSave.UseVisualStyleBackColor = false;
            this.BtnLoadSave.Click += new System.EventHandler(this.BtnLoadSave_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtnSave.Location = new System.Drawing.Point(855, 495);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(10);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(189, 81);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "Сохранить решение";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnConditionImposed
            // 
            this.BtnConditionImposed.Location = new System.Drawing.Point(855, 293);
            this.BtnConditionImposed.Margin = new System.Windows.Forms.Padding(10);
            this.BtnConditionImposed.Name = "BtnConditionImposed";
            this.BtnConditionImposed.Size = new System.Drawing.Size(189, 81);
            this.BtnConditionImposed.TabIndex = 5;
            this.BtnConditionImposed.Text = "Условие введено";
            this.BtnConditionImposed.UseVisualStyleBackColor = true;
            this.BtnConditionImposed.Click += new System.EventHandler(this.BtnConditionImposed_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 860);
            this.Controls.Add(this.BtnUnlockCells);
            this.Controls.Add(this.BtnNewGame);
            this.Controls.Add(this.BtnLoadSave);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnConditionImposed);
            this.Controls.Add(this.BtnShowSolution);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Игра \"Судоку\"";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnShowSolution;
        private System.Windows.Forms.Button BtnUnlockCells;
        private System.Windows.Forms.Button BtnNewGame;
        private System.Windows.Forms.Button BtnLoadSave;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnConditionImposed;
    }
}

