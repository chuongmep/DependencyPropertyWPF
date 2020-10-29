using System.Windows;
using System.Windows.Controls;

namespace Dependency_property.userControls
{

    /// <summary>
    ///     Interaction logic for MyuserControl.xaml
    /// </summary>
    public partial class MyuserControl : UserControl
    {
        public MyuserControl()
        {
            InitializeComponent();
        }

        public event RoutedEventHandler ButtonClick;

        private void ActionExecuting(object sender, RoutedEventArgs e)
        {
            if (ButtonClick != null)
            {
                ButtonClick.Invoke(this, new RoutedEventArgs());
            }
        }

        #region Dependency property

        public static readonly DependencyProperty
            ButtonContentproperty = DependencyProperty.Register(
                "ButtonContent", typeof (object), typeof (MyuserControl),
                new UIPropertyMetadata("Action"));

        public static readonly DependencyProperty
            TextBoxTextproperty = DependencyProperty.Register(
                "TextBoxText", typeof (string), typeof (MyuserControl),
                new UIPropertyMetadata("No text", OnValueChanged));

        public string TextBoxText
        {
            get { return (string) GetValue(TextBoxTextproperty); }
            set { SetValue(TextBoxTextproperty, value); }
        }

        public object ButtonContent
        {
            get { return GetValue(ButtonContentproperty); }
            set { SetValue(ButtonContentproperty, value); }
        }


        private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            // do something when property changes
        }

        #endregion
    }
}