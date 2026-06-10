namespace DotNet03GuessNum
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            LblDisplay = new Label();
            TxtNum = new TextBox();
            BtnCheck = new Button();
            BtnStart = new Button();
            SuspendLayout();
            // 
            // LblDisplay
            // 
            LblDisplay.Dock = DockStyle.Top;
            LblDisplay.Font = new Font("맑은 고딕", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblDisplay.Location = new Point(0, 0);
            LblDisplay.Name = "LblDisplay";
            LblDisplay.Size = new Size(365, 38);
            LblDisplay.TabIndex = 0;
            LblDisplay.Text = "게임을 시작합니다";
            LblDisplay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TxtNum
            // 
            TxtNum.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtNum.Location = new Point(62, 53);
            TxtNum.Name = "TxtNum";
            TxtNum.Size = new Size(125, 34);
            TxtNum.TabIndex = 1;
            // 
            // BtnCheck
            // 
            BtnCheck.Font = new Font("맑은 고딕", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnCheck.Location = new Point(193, 53);
            BtnCheck.Name = "BtnCheck";
            BtnCheck.Size = new Size(110, 34);
            BtnCheck.TabIndex = 2;
            BtnCheck.Text = "확인";
            BtnCheck.UseVisualStyleBackColor = true;
            BtnCheck.Click += BtnCheck_Click;
            // 
            // BtnStart
            // 
            BtnStart.Dock = DockStyle.Bottom;
            BtnStart.Font = new Font("맑은 고딕", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnStart.Location = new Point(0, 114);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(365, 37);
            BtnStart.TabIndex = 3;
            BtnStart.Text = "게임 시작";
            BtnStart.UseVisualStyleBackColor = true;
            BtnStart.Click += BtnStart_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(365, 151);
            Controls.Add(BtnStart);
            Controls.Add(BtnCheck);
            Controls.Add(TxtNum);
            Controls.Add(LblDisplay);
            Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "숫자 맞히기 게임";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblDisplay;
        private TextBox TxtNum;
        private Button BtnCheck;
        private Button BtnStart;
    }
}
