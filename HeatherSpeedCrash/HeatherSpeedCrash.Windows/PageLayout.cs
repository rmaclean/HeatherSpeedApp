namespace HSA.Controls
{
    using System.Windows.Input;
    using Windows.UI.ViewManagement;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed class PageLayout : ContentControl
    {
        public static readonly DependencyProperty FooterProperty = DependencyProperty.Register("Footer", typeof(object), typeof(PageLayout), new PropertyMetadata(new Grid()));// <- HERE IS THE PROBLEM. Change from Grid to a string and it never fails
        public static readonly DependencyProperty GoBackProperty = DependencyProperty.Register("GoBack", typeof(ICommand), typeof(PageLayout), new PropertyMetadata(null));
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(object), typeof(PageLayout), new PropertyMetadata(new Grid()));// <- HERE IS THE PROBLEM. Change from Grid to a string and it never fails
        public static readonly DependencyProperty LoadingPopupOpenProperty = DependencyProperty.Register("LoadingPopupOpen", typeof(bool), typeof(PageLayout), new PropertyMetadata(false));
        public static readonly DependencyProperty PageExitProperty = DependencyProperty.Register("PageExit", typeof(ICommand), typeof(PageLayout), new PropertyMetadata(null));
        public static readonly DependencyProperty PageHelpProperty = DependencyProperty.Register("PageHelp", typeof(ICommand), typeof(PageLayout), new PropertyMetadata(null));
        public static readonly DependencyProperty PopupContentProperty = DependencyProperty.Register("PopupContent", typeof(object), typeof(PageLayout), new PropertyMetadata(null));
        public static readonly DependencyProperty PopupOpenProperty = DependencyProperty.Register("PopupOpen", typeof(bool), typeof(PageLayout), new PropertyMetadata(false));
        public static readonly DependencyProperty ShowBackButtonProperty = DependencyProperty.Register("ShowBackButton", typeof(bool), typeof(PageLayout), new PropertyMetadata(true));
        public static readonly DependencyProperty ShowExitProperty = DependencyProperty.Register("ShowExit", typeof(bool), typeof(PageLayout), new PropertyMetadata(true));
        public static readonly DependencyProperty ShowHelpProperty = DependencyProperty.Register("ShowHelp", typeof(bool), typeof(PageLayout), new PropertyMetadata(true));
        public static readonly DependencyProperty SubTitleProperty = DependencyProperty.Register("SubTitle", typeof(string), typeof(PageLayout), new PropertyMetadata(""));
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(PageLayout), new PropertyMetadata(""));
        private Viewbox fullMode;
        private Grid snappedMode;

        public PageLayout()
        {
            this.DefaultStyleKey = typeof(PageLayout);
            this.Unloaded += PageLayout_Unloaded;
            Window.Current.SizeChanged += Current_SizeChanged;
        }

        public object Footer
        {
            get { return (object)GetValue(FooterProperty); }
            set { SetValue(FooterProperty, value); }
        }

        public ICommand GoBack
        {
            get { return (ICommand)GetValue(GoBackProperty); }
            set { SetValue(GoBackProperty, value); }
        }

        public object Header
        {
            get { return (object)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public bool LoadingPopupOpen
        {
            get { return (bool)GetValue(LoadingPopupOpenProperty); }
            set { SetValue(LoadingPopupOpenProperty, value); }
        }

        public ICommand PageExit
        {
            get { return (ICommand)GetValue(PageExitProperty); }
            set { SetValue(PageExitProperty, value); }
        }

        public ICommand PageHelp
        {
            get { return (ICommand)GetValue(PageHelpProperty); }
            set { SetValue(PageHelpProperty, value); }
        }

        public object PopupContent
        {
            get { return (object)GetValue(PopupContentProperty); }
            set { SetValue(PopupContentProperty, value); }
        }

        public bool PopupOpen
        {
            get { return (bool)GetValue(PopupOpenProperty); }
            set { SetValue(PopupOpenProperty, value); }
        }

        public bool ShowBackButton
        {
            get { return (bool)GetValue(ShowBackButtonProperty); }
            set { SetValue(ShowBackButtonProperty, value); }
        }

        public bool ShowExit
        {
            get { return (bool)GetValue(ShowExitProperty); }
            set { SetValue(ShowExitProperty, value); }
        }

        public bool ShowHelp
        {
            get { return (bool)GetValue(ShowHelpProperty); }
            set { SetValue(ShowHelpProperty, value); }
        }

        public string SubTitle
        {
            get { return (string)GetValue(SubTitleProperty); }
            set { SetValue(SubTitleProperty, value); }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public void Popup(UserControl popupContent)
        {
            PopupContent = popupContent;
            PopupOpen = true;
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.snappedMode = GetTemplateChild("snappedMode") as Grid;
            this.fullMode = GetTemplateChild("fullMode") as Viewbox;
        }

        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            if (ApplicationView.GetForCurrentView().IsFullScreen)
            {
                fullMode.Visibility = Windows.UI.Xaml.Visibility.Visible;
                snappedMode.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
            else
            {
                fullMode.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                snappedMode.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
        }

        private void PageLayout_Unloaded(object sender, RoutedEventArgs e)
        {
            Window.Current.SizeChanged -= Current_SizeChanged;
        }
    }
}