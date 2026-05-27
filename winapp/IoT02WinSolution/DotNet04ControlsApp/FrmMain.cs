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
            if(pictureBox1.SizeMode == PictureBoxSizeMode.CenterImage)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }
    }
}
