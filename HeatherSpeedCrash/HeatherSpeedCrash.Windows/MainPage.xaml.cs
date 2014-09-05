namespace HeatherSpeedCrash
{
    using System;
    using System.Threading.Tasks;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
             App.RunCounter++;
            RunCounter.Text = "Run " + App.RunCounter;
            if (App.ThunderbirdsAreGo)
            {
                RunButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }

        protected async override void OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            if (App.ThunderbirdsAreGo)
            {
                await Task.Delay(TimeSpan.FromSeconds(new Random().NextDouble()));
                (Window.Current.Content as Frame).Navigate(typeof(MainPage));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.ThunderbirdsAreGo = true;
            (Window.Current.Content as Frame).Navigate(typeof(MainPage));
        }
    }
}