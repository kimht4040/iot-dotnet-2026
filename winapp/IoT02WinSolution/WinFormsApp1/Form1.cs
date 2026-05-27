using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // 1. 클래스 멤버 변수로 정답과 남은 기회를 선언합니다.
        private int targetNumber;
        private int chance;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 게임 시작 (버튼2 클릭 이벤트)
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            var rand = new Random();
            targetNumber = rand.Next(1, 31); // 1부터 30까지의 랜덤 숫자 생성
            chance = 10;                     // 기회 10번으로 초기화

            // 상태를 알려주는 라벨의 이름을 lblStatus로 변경했다고 가정합니다.
            lblStatus.Text = "숫자를 입력하세요";
            TxtNum.Text = "";                // 텍스트 박스 초기화

            MessageBox.Show("숫자 맞추기 게임이 시작되었습니다!");
        }

        /// <summary>
        /// 정답 확인 (버튼1 클릭 이벤트)
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            // 남은 기회가 없다면 더 이상 진행하지 않음
            if (chance <= 0)
            {
                MessageBox.Show("기회를 모두 소진했습니다. 다시 시작 버튼을 눌러주세요.");
                return;
            }

            // 2. 사용자가 숫자가 아닌 문자나 빈칸을 입력했을 때의 오류 방지
            if (!int.TryParse(TxtNum.Text, out int inputNum))
            {
                MessageBox.Show("올바른 숫자를 입력해주세요.");
                return;
            }

            // 3. 정답 비교 로직
            if (inputNum == targetNumber)
            {
                lblStatus.Text = "정답입니다!";
                MessageBox.Show("축하합니다! 정답을 맞추셨습니다.");
            }
            else
            {
                chance--; // 기회를 1 차감합니다.

                if (chance > 0)
                {
                    if (inputNum > targetNumber)
                    {
                        lblStatus.Text = $"숫자가 너무 큽니다. 남은 기회: {chance}";
                    }
                    else
                    {
                        lblStatus.Text = $"숫자가 너무 작습니다. 남은 기회: {chance}";
                    }
                }
                else
                {
                    // 기회가 0이 되었을 때
                    lblStatus.Text = $"게임 오버! 정답은 {targetNumber}였습니다.";
                }
            }

            // 다음 입력을 편하게 하기 위해 텍스트박스를 비우고 포커스를 줍니다.
            TxtNum.Text = "";
            TxtNum.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // 현재는 사용하지 않는 이벤트이므로 비워둡니다.
        }
    }
}