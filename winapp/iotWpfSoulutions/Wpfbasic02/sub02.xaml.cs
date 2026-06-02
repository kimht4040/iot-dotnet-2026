using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpfbasic02
{
    /// <summary>
    /// sub02.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class sub02 : Page
    {
        List<Employee> employees;


        public Employee SelectedEmployee {  get; set; }
        // 생성자는 보통 클래스의 맨 위(변수 선언 아래)에 두는 것이 관례입니다.
        public sub02()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            employees = new List<Employee>()
            {
                new Employee
                {
                    Id = 1,
                    Name = "김철수",
                    Department = "개발팀",
                    Salary = 4200,
                    HireDate = new DateTime(2021, 3, 15),
                    IsActive = true
                },
                new Employee
                {
                    Id = 2,
                    Name = "이영희",
                    Department = "인사팀",
                    Salary = 5100,
                    HireDate = new DateTime(2019, 7, 1),
                    IsActive = true
                },
                new Employee
                {
                    Id = 3,
                    Name = "박민수",
                    Department = "영업팀",
                    Salary = 3300,
                    HireDate = new DateTime(2023, 1, 10),
                    IsActive = false
                },
                new Employee
                {
                    Id = 4,
                    Name = "최지은",
                    Department = "디자인팀",
                    Salary = 6200,
                    HireDate = new DateTime(2018, 11, 20),
                    IsActive = true
                },
                new Employee
                {
                    Id = 5,
                    Name = "홍길동",
                    Department = "경영팀",
                    Salary = 9000,
                    HireDate = new DateTime(2010, 1, 1),
                    IsActive = true
                }
            };
            dataGrid.ItemsSource = employees;
        }
    }
}