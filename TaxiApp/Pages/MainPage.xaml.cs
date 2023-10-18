
using TaxiApp.Const;
using TaxiApp.Entity.Users;

namespace TaxiApp
{
    public partial class MainPage : ContentPage
    {
        private List<UserEntity> users = new();
        private string _phoneEntry { get; set; }

        public MainPage()
        {
            InitializeComponent();
            users.Add(new UserEntity { 
                Id = 1, //
                FIO = "Иванов Иван Иванович",
                Gender= GenderEnum.MALE,
                Phone = "+7 (981) 111-11-11",
                Role=RoleEnum.CLIENT, //
                Rating = 3.14F //
            });
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