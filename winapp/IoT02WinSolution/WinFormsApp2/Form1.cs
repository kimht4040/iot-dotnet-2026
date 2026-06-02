using System;
using System.Data;
using System.Windows.Forms;
namespace WinFormsApp2
{
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        public Form1()
        {
            InitializeComponent();
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. 실행할 SQL 쿼리문 작성 (최근에 넣은 11~20번 데이터 조회)
                string query = "SELECT id AS '번호', title AS '제목', author AS '저자', publisher AS '출판사', publish_year AS '출판년도' FROM books ORDER BY id ASC;";

                // 2. DatabaseHelper를 통해 데이터 조회 후 DataTable에 저장
                DataTable dt = dbHelper.ExecuteSelect(query);

                // 3. DataGridView에 데이터 바인딩
                if (dt != null && dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;

                    // 그리드뷰 디자인 보기 좋게 자동 크기 조절 (선택 사항)
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("조회된 데이터가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터를 불러오는 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {

        }

        private void materialButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
