using System.Collections.Generic;
using System.Linq;
using MySqlConnector; // SQLite 대신 MySQL 라이브러리 사용
using Dapper;

namespace KioskPractice
{
    public class DatabaseService
    {
        // 본인의 MySQL 서버 정보에 맞게 수정해야 합니다. (서버주소, DB이름, 아이디, 비밀번호)
        private readonly string connectionString = "Server=localhost;Database=KioskDB;Uid=root;Pwd=root1234;";

        public void InitializeDatabase()
        {
            // MySqlConnection을 사용하여 MySQL 서버와 통신합니다.
            using (var connection = new MySqlConnection(connectionString))
            {
                // MySQL 문법에 맞게 테이블 생성 (문자열은 VARCHAR 사용)
                var createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Products (
                        Name VARCHAR(100) PRIMARY KEY,
                        Price INT,
                        Category VARCHAR(50)
                    )";
                connection.Execute(createTableQuery);

                var count = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Products");
                if (count == 0)
                {
                    connection.Execute("INSERT INTO Products (Name, Price, Category) VALUES ('아메리카노', 4500, 'Coffee')");
                    connection.Execute("INSERT INTO Products (Name, Price, Category) VALUES ('카페라떼', 5000, 'Coffee')");
                    connection.Execute("INSERT INTO Products (Name, Price, Category) VALUES ('초코케이크', 6500, 'Dessert')");
                  
                }
            }
        }

        public List<Product> GetProducts()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                // 데이터를 가져오는 Dapper 코드는 SQLite 때와 100% 동일합니다!
                return connection.Query<Product>("SELECT * FROM Products").ToList();
            }
        }
    }
}