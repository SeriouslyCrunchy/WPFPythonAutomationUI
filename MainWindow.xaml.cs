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
            string InputValues1 = ValueText1.Text;
            string InputValues2 = ValueText2.Text;
            string InputValues3 = ValueText3.Text;
            string InputValues4 = ValueText4.Text;
            string[] InputValuesAll = new string[]{ InputValues1 , InputValues2 , InputValues3 , InputValues4 };
            if (InputValues1 != "")
            {
                NewAppSession.AddCommand(InputValuesAll);
            }
            
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

        //this activates every time the item in the list selected changed
        private void ListSelection_OnChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (TypeListBox.SelectedItem != null)
                NewAppSession.ListSelectText = TypeListBox.SelectedItem.ToString();
                NewAppSession.UpdateSelected();

        }

    }
}