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
    public class Car
    {
        public double Speed { get; set; }
        public Color Color { get; set; }
    }
    /// <summary>
    /// sub03.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class sub03 : Page
    {


        public Employee SelectedEmployee {  get; set; }
        // 생성자는 보통 클래스의 맨 위(변수 선언 아래)에 두는 것이 관례입니다.
        public sub03()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Car car = new Car
            {
                Speed = 120.5,
                Color = Colors.Red
            };
            //this.DataContext = car;
            GrbInfo.DataContext = car;
        }
    }
}