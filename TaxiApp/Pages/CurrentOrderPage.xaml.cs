using TaxiApp.Entity.Users;

namespace TaxiApp.Pages;

public partial class CurrentOrderPage : ContentPage
{
	public CurrentOrderPage()
	{
		InitializeComponent();
        UserNotAuth();
	}

    private async void UserNotAuth()
    {
        UserSessionInfoItemDatabase db = new();
        List<UserSessionEntity> entity = new();
        await Task.Run(async () =>
        {
            entity = await db.GetItemsAsync();
        });
        if (entity.Count == 0)
            await Navigation.PushModalAsync(new MainPage());
    }
}