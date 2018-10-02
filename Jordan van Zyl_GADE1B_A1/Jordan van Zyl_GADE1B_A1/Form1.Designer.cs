namespace Jordan_van_Zyl_GADE1B_A1
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
            this.components = new System.ComponentModel.Container();
            this.lblMap = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.timerCounter = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.cmbUnits = new System.Windows.Forms.ComboBox();
            this.rchUnitInfo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMap.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMap.Location = new System.Drawing.Point(56, 55);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(2, 33);
            this.lblMap.TabIndex = 0;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(1075, 57);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 31);
            this.lblTime.TabIndex = 1;
            // 
            // timerCounter
            // 
            this.timerCounter.Enabled = true;
            this.timerCounter.Interval = 1000;
            this.timerCounter.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(647, 105);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(146, 72);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(799, 105);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(137, 72);
            this.btnPause.TabIndex = 4;
            this.btnPause.Text = "pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // cmbUnits
            // 
            this.cmbUnits.FormattingEnabled = true;
            this.cmbUnits.Location = new System.Drawing.Point(647, 229);
            this.cmbUnits.Name = "cmbUnits";
            this.cmbUnits.Size = new System.Drawing.Size(289, 24);
            this.cmbUnits.TabIndex = 5;
            this.cmbUnits.SelectedIndexChanged += new System.EventHandler(this.cmbUnits_SelectedIndexChanged);
            // 
            // rchUnitInfo
            // 
            this.rchUnitInfo.Location = new System.Drawing.Point(647, 337);
            this.rchUnitInfo.Name = "rchUnitInfo";
            this.rchUnitInfo.Size = new System.Drawing.Size(289, 280);
            this.rchUnitInfo.TabIndex = 6;
            this.rchUnitInfo.Text = "";
            this.rchUnitInfo.TextChanged += new System.EventHandler(this.rchUnitInfo_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 1002);
            this.Controls.Add(this.rchUnitInfo);
            this.Controls.Add(this.cmbUnits);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblMap);
            this.Name = "Form1";
            this.Text = "Heros vs. Villains";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timerCounter;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.ComboBox cmbUnits;
        private System.Windows.Forms.RichTextBox rchUnitInfo;
    }
}

