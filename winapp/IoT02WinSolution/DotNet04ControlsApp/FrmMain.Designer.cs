namespace DotNet04ControlsApp
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            groupBox1 = new GroupBox();
            btnDialog = new Button();
            message = new Button();
            modeless = new Button();
            modal = new Button();
            txtresult = new TextBox();
            italic = new CheckBox();
            bold = new CheckBox();
            comboBox1 = new ComboBox();
            font = new Label();
            groupBox2 = new GroupBox();
            TrkStatus = new TrackBar();
            progressBar1 = new ProgressBar();
            groupBox3 = new GroupBox();
            button2 = new Button();
            button1 = new Button();
            listview = new ListView();
            treeview = new TreeView();
            groupBox4 = new GroupBox();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            groupBox5 = new GroupBox();
            groupBox6 = new GroupBox();
            DlgOpenFile = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            imageList1 = new ImageList(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrkStatus).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDialog);
            groupBox1.Controls.Add(message);
            groupBox1.Controls.Add(modeless);
            groupBox1.Controls.Add(modal);
            groupBox1.Controls.Add(txtresult);
            groupBox1.Controls.Add(italic);
            groupBox1.Controls.Add(bold);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(font);
            groupBox1.Location = new Point(32, 39);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(309, 152);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "기본컨트롤";
            // 
            // btnDialog
            // 
            btnDialog.Location = new Point(259, 91);
            btnDialog.Name = "btnDialog";
            btnDialog.Size = new Size(38, 23);
            btnDialog.TabIndex = 8;
            btnDialog.Text = "...";
            btnDialog.UseVisualStyleBackColor = true;
            btnDialog.Click += btnDialog_Click;
            // 
            // message
            // 
            message.Location = new Point(171, 91);
            message.Name = "message";
            message.Size = new Size(82, 23);
            message.TabIndex = 7;
            message.Text = "message";
            message.UseVisualStyleBackColor = true;
            message.Click += message_Click;
            // 
            // modeless
            // 
            modeless.Location = new Point(82, 91);
            modeless.Name = "modeless";
            modeless.Size = new Size(83, 23);
            modeless.TabIndex = 6;
            modeless.Text = "modeless";
            modeless.UseVisualStyleBackColor = true;
            modeless.Click += modeless_Click;
            // 
            // modal
            // 
            modal.Location = new Point(16, 91);
            modal.Name = "modal";
            modal.Size = new Size(60, 23);
            modal.TabIndex = 5;
            modal.Text = "modal";
            modal.UseVisualStyleBackColor = true;
            modal.Click += modal_Click;
            // 
            // txtresult
            // 
            txtresult.Location = new Point(16, 51);
            txtresult.Name = "txtresult";
            txtresult.Size = new Size(281, 23);
            txtresult.TabIndex = 4;
            txtresult.FontChanged += txtresult_FontChanged;
            // 
            // italic
            // 
            italic.AutoSize = true;
            italic.Location = new Point(246, 24);
            italic.Name = "italic";
            italic.Size = new Size(51, 19);
            italic.TabIndex = 3;
            italic.Text = "italic";
            italic.UseVisualStyleBackColor = true;
            // 
            // bold
            // 
            bold.AutoSize = true;
            bold.Location = new Point(190, 24);
            bold.Name = "bold";
            bold.Size = new Size(50, 19);
            bold.TabIndex = 2;
            bold.Text = "bold";
            bold.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(51, 22);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 24);
            comboBox1.TabIndex = 1;
            // 
            // font
            // 
            font.AutoSize = true;
            font.Location = new Point(16, 25);
            font.Name = "font";
            font.Size = new Size(29, 15);
            font.TabIndex = 0;
            font.Text = "font";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(TrkStatus);
            groupBox2.Controls.Add(progressBar1);
            groupBox2.Location = new Point(32, 197);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(309, 145);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "트랙바, 진행바";
            // 
            // TrkStatus
            // 
            TrkStatus.Location = new Point(16, 22);
            TrkStatus.Maximum = 100;
            TrkStatus.Name = "TrkStatus";
            TrkStatus.Size = new Size(281, 45);
            TrkStatus.TabIndex = 1;
            TrkStatus.TickFrequency = 5;
            TrkStatus.Value = 10;
            TrkStatus.Scroll += TrkStatus_Scroll;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(16, 82);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(281, 27);
            progressBar1.TabIndex = 2;
            progressBar1.Value = 10;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button2);
            groupBox3.Controls.Add(button1);
            groupBox3.Controls.Add(listview);
            groupBox3.Controls.Add(treeview);
            groupBox3.Location = new Point(32, 348);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(309, 169);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "트리, 리스트뷰";
            // 
            // button2
            // 
            button2.Location = new Point(224, 137);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 4;
            button2.Text = "노드추가";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(143, 137);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "루트추가";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listview
            // 
            listview.Location = new Point(143, 22);
            listview.Name = "listview";
            listview.Size = new Size(154, 112);
            listview.TabIndex = 2;
            listview.UseCompatibleStateImageBehavior = false;
            // 
            // treeview
            // 
            treeview.Location = new Point(16, 22);
            treeview.Name = "treeview";
            treeview.Size = new Size(121, 112);
            treeview.TabIndex = 1;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(pictureBox1);
            groupBox4.Controls.Add(button3);
            groupBox4.Location = new Point(347, 39);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(315, 303);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "픽쳐박스";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(6, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(303, 242);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(234, 274);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 0;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // groupBox5
            // 
            groupBox5.Location = new Point(347, 348);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(315, 169);
            groupBox5.TabIndex = 4;
            groupBox5.TabStop = false;
            groupBox5.Text = "스레드";
            // 
            // groupBox6
            // 
            groupBox6.Location = new Point(668, 39);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(504, 478);
            groupBox6.TabIndex = 1;
            groupBox6.TabStop = false;
            groupBox6.Text = "텍스트 에디터";
            // 
            // DlgOpenFile
            // 
            DlgOpenFile.FileName = "openFileDialog1";
            DlgOpenFile.Filter = "텍스트 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "qweqwe.png");
            imageList1.Images.SetKeyName(1, "스크린샷 2026-04-13 161459.png");
            imageList1.Images.SetKeyName(2, "스크린샷 2026-04-13 162055.png");
            imageList1.Images.SetKeyName(3, "스크린샷 2026-04-13 162115.png");
            imageList1.Images.SetKeyName(4, "스크린샷 2026-05-26 113403.png");
            imageList1.Images.SetKeyName(5, "스크린샷 2026-05-26 142504.png");
            imageList1.Images.SetKeyName(6, "스크린샷 2026-05-26 155800.png");
            imageList1.Images.SetKeyName(7, "스크린샷 2026-05-26 160616.png");
            imageList1.Images.SetKeyName(8, "스크린샷 2026-05-26 163259.png");
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 541);
            Controls.Add(groupBox5);
            Controls.Add(groupBox6);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmMain";
            Text = "컨트롤예제";
            Load += FrmMain_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TrkStatus).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private TextBox txtresult;
        private CheckBox italic;
        private CheckBox bold;
        private ComboBox comboBox1;
        private Label font;
        private Button modal;
        private Button btnDialog;
        private Button message;
        private Button modeless;
        private OpenFileDialog DlgOpenFile;
        private TrackBar TrkStatus;
        private ProgressBar progressBar1;
        private ListView listview;
        private TreeView treeview;
        private Button button2;
        private Button button1;
        private SaveFileDialog saveFileDialog1;
        private ImageList imageList1;
        private PictureBox pictureBox1;
        private Button button3;
    }
}
