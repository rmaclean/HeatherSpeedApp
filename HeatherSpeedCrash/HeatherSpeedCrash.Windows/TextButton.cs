namespace HSA.Controls
{
    using Windows.UI;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;

    public sealed class TextButton : Button
    {
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(TextButton), new PropertyMetadata(false));

        public static readonly DependencyProperty SelectedColourProperty = DependencyProperty.Register("SelectedColour", typeof(SolidColorBrush), typeof(TextButton), new PropertyMetadata(new SolidColorBrush(Colors.Red)));

        public TextButton()
        {
            this.DefaultStyleKey = typeof(TextButton);
        }

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public SolidColorBrush SelectedColour
        {
            get { return (SolidColorBrush)GetValue(SelectedColourProperty); }
            set { SetValue(SelectedColourProperty, value); }
        }
    }
}