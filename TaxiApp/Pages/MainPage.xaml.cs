
namespace TaxiApp
{
    public partial class MainPage : ContentPage
    {
        private string _phoneEntry { get; set; }

        public MainPage()
        {
            InitializeComponent();
            PhoneEntry.Text = "";
        }
        private bool is_validPhoneNumber()
        {
            if (_phoneEntry.Length < 18 )
            {
                DisplayAlert("Ошибка ввода", "Неверный номер телефона!", "OK");
                return false;
            }
            return true;
        }

        private void Send_Clicked(object sender, EventArgs e)
        {
            _phoneEntry = PhoneEntry.Text;
            if(is_validPhoneNumber())
            {
                CodeEntry.IsVisible = true;
            }

        }
    }
}