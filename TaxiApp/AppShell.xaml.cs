using TaxiApp.Entity.Users;
using TaxiApp.Pages;

namespace TaxiApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

        }

        private async void SessionUser_Clicked(object sender, EventArgs e)
        {
            
            
                //SessionUser.Text = user.FIO;
            
        }

        private async void SessionExit_Clicked(object sender, EventArgs e)
        {
            UserSessionInfoItemDatabase db = new();
            await db.DeleteAllItemsAsync();
            await Navigation.PushModalAsync(new MainPage());
        }
    }
}