using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySqlConnector;

namespace WinFormsApp2
{
    internal class DatabaseHelper
    {
        // 도커에 띄운 MySQL 접속 문자열
        private readonly string connStr = "Server=localhost;Database=bookrentalshop;User ID=root;Password=my123456;Charset=utf8mb4;";

        /// <summary>
        /// DB 연결 객체를 직접 가져올 때 사용합니다.
        /// </summary>
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connStr);
        }

        /// <summary>
        /// SELECT 쿼리를 실행하고 결과를 DataTable 형식으로 반환합니다.
        /// WinForms의 DataGridView 등의 DataSource로 바로 사용하기 좋습니다.
        /// </summary>
        public DataTable ExecuteSelect(string query)
        {
            DataTable dt = new DataTable();

            try
            {
                // using 문을 사용하면 자동으로 DB 연결을 닫아줍니다 (메모리 누수 방지)
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 실무에서는 이곳에 로그를 남기거나 MessageBox를 띄웁니다.
                Console.WriteLine($"DB Select 오류: {ex.Message}");
            }

            return dt;
        }

        /// <summary>
        /// INSERT, UPDATE, DELETE 쿼리를 실행합니다.
        /// </summary>
        /// <returns>영향을 받은 행(Row)의 개수를 반환합니다.</returns>
        public int ExecuteNonQuery(string query)
        {
            int affectedRows = 0;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        affectedRows = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DB NonQuery 오류: {ex.Message}");
            }

            return affectedRows;
        }
    }
}