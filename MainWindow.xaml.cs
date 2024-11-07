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

namespace AutomationUITest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //new instance of AppSession class (which handles the button clicks as it is an instance of INotifyPropertyChanged)
        AppSession NewAppSession = new AppSession();
        public MainWindow()
        {
            //set datacontext to AppSession class which is handling the vast majority of UI
            InitializeComponent();
            DataContext = NewAppSession;
        }
        //click events
        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            NewAppSession.AddCommand();
            
        }
        private void ButtonDel_OnClick(object sender, RoutedEventArgs e)
        {
            NewAppSession.DeleteCommand();

        }
        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            NewAppSession.SaveCommands();

        }
        private void ButtonLoad_OnClick(object sender, RoutedEventArgs e)
        {
            NewAppSession.LoadCommands();

        }
        private void ButtonRun_OnClick(object sender, RoutedEventArgs e)
        {
            NewAppSession.RunCommands();

        }
        private void ButtonClear_OnClick(object sender, RoutedEventArgs e)
        {
            NewAppSession.ClearCommands();

        }

    }
}