namespace DotNet04ControlsApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        // 폼로드 이벤트 핸들러
        private void FrmMain_Load(object sender, EventArgs e)
        {
            foreach (System.Drawing.FontFamily font in System.Drawing.FontFamily.Families)
            {
                comboBox1.Items.Add(font.Name);
            }

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }


        private void txtresult_FontChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                return;
            }
            FontStyle style = FontStyle.Regular;
            if (bold.Checked)
            {
                style |= FontStyle.Bold;
            }
            if (italic.Checked)
            {
                style |= FontStyle.Italic;
            }
            txtresult.Font = new Font(comboBox1.SelectedItem.ToString(), 10, style);
        }

        // 모달 
        private void modal_Click(object sender, EventArgs e)
        {
            FrmSub frmSub = new FrmSub();
            frmSub.Text = "모달창";
            frmSub.StartPosition = FormStartPosition.CenterParent;
            frmSub.ShowDialog(); // 모달창으로 여는 함수
        }
        // 모달리스 
        private void modeless_Click(object sender, EventArgs e)
        {
            FrmSub frmSub = new FrmSub();
            frmSub.Text = "모달리스창";
            frmSub.StartPosition = FormStartPosition.Manual;
            frmSub.Show(this); // 모달리스창으로 여는 함수
        }

        private void message_Click(object sender, EventArgs e)
        {
            // 기본적인 메시지 ㅁ박스
            // 파라미터: 메시지, 타이틀, 버튼 종류, 아이콘 종류
            MessageBox.Show(txtresult.Text, "메시지박스", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 다이얼로그 창 띄우기
        private void btnDialog_Click(object sender, EventArgs e)
        {
            DlgOpenFile.ShowDialog();
        }

        // 트랙바 스크롤변경 이벤트 핸들러
        private void TrkStatus_Scroll(object sender, EventArgs e)
        {
            progressBar1.Value = TrkStatus.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var random = new Random();
            treeview.Nodes.Add(random.Next().ToString());


        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (treeview.SelectedNode == null)
            {
                MessageBox.Show("노드를 선택하세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            var random = new Random();
            TreeNode childNode = new TreeNode(random.Next().ToString());
            childNode.ImageIndex = 1;
            treeview.SelectedNode.Nodes.Add(childNode);
            treeview.ExpandAll();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "파일 열기";
            dlg.Filter = "이미지파일 (*.jpg;*.png)|*.jpg;*.png|모든파일 (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dlg.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }
        }
        //피쳐박스 컨트롤 클릭 이벤트
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.SizeMode == PictureBoxSizeMode.CenterImage)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }
        // 스레드 없이 진행
        private void button4_Click(object sender, EventArgs e)
        {
            var maximum = 100;
            var minimum = 0;
            var currValue = 0;
            process.Maximum = maximum;
            process.Minimum = minimum;
            process.Value = 0;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = true;
            // 프로세스 진행 더미로 실행
            for (int i = 0; i <= maximum; i++)
            {
                currValue = i;
                process.Value = currValue;
                textBox1.AppendText($"진행사항{currValue}\r\n");
                Thread.Sleep(500);

            }
            button4.Enabled = button5.Enabled = true;
            button6.Enabled = false;
        }
        // 스레드로 진행
        private void button5_Click(object sender, EventArgs e)
        {
            var maximum = 100;
            var minimum = 0;
            var currValue = 0;
            process.Maximum = maximum;
            process.Minimum = minimum;
            process.Value = 0;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = true;

            // 내부작업을 백그라운드 워커에 이벤트로 분리해야함
            backgroundWorker1.WorkerReportsProgress = true; // 진행사항 리포트 활성화 
            backgroundWorker1.WorkerSupportsCancellation = true;// 백그라운드 워커 취소 활성화
            backgroundWorker1.RunWorkerAsync(null);
        }
        // 정지
        private void button6_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;

            backgroundWorker1.CancelAsync();
        }


        #region 백그라운드 워커 이벤트 핸들러
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var maximum = 100;
            var currValue = 0;
            for (int i = 0; i <= maximum; i++)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    currValue = i;
                    Thread.Sleep(100);
                    backgroundWorker1.ReportProgress((int)currValue);
                }


            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            process.Value = e.ProgressPercentage;
            textBox1.AppendText($"진행사항{process.Value}\r\n");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            MessageBox.Show("작업이 완료되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
        }
        #endregion

        private void load_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Filter = "텍스트 파일(*.txt;*.cs;*.py)|*.txt;*.cs;*.py|모든 파일(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                TextBox2.LoadFile(dlg.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "텍스트 파일(*.txt)|*.txt|모든 파일(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                TextBox2.SaveFile(dlg.FileName, RichTextBoxStreamType.PlainText);
            }
        }
    }
}
