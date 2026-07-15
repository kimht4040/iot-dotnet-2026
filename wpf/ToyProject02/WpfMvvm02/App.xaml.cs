using System.Configuration;
using System.Data;
using System.Windows;
using WpfMvvm02.ViewModels;

namespace WpfMvvm02
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {   
            MainView view = new MainView();
            view.DataContext = new MainViewModel();
            view.Show();
        }
    }

}
