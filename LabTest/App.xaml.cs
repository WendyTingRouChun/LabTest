namespace LabTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Q3()); // Use NavigationPage for navigation
        }
    }
}