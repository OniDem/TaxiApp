using TaxiApp.Entity.Users;

namespace TaxiApp.Pages;

public partial class OrderPage : ContentPage
{
    UserSessionInfoItemDatabase db = new();
    public OrderPage()
	{
		InitializeComponent();

        List <UserSessionEntity> sessionEntity = new();
        List <UserSessionEntity> sessionEntity = new();
        sessionEntity =  db.GetItemsAsync().Result;

        IDEntry.Text = sessionEntity;
    }
}