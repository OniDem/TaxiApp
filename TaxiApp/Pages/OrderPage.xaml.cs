using TaxiApp.Const;
using TaxiApp.Entity.Orders;
using TaxiApp.Entity.Users;
using CommunityToolkit.Maui.Alerts;

namespace TaxiApp.Pages;



public partial class OrderPage : ContentPage
{
    UserSessionInfoItemDatabase db = new();
    private OrderTypeEnum orderType;
    List<OrderEntity> orders = new();
    
    int id = 0;

    public OrderPage()
	{
        InitializeComponent();
        UserNotAuth();
    }



    private async void Check_Clicked(object sender, EventArgs e)
    {
        List<UserSessionEntity> entity = new();
        await Task.Run(async () =>
        {
            entity = await db.GetItemsAsync();
        });
        foreach (UserSessionEntity user in entity)
        {
            await DisplayAlert("Dev Info", user.Id + ", " + user.FIO + ", " + user.Gender + ", " + user.Phone + ", " + user.Role + ", " + user.Rating, "OK");
            
        }

        Task.Delay(1000).Wait();

        foreach (OrderEntity order in orders)
        {
            await DisplayAlert("Dev Info", order.OrderId + ", " + order.OrderType + ", " + order.OrderFrom + ", " + order.OrderTo + ", " + order.OrderDate + ", " + order.OrderPassengers + ", " + order.OrderComment + ", " + order.OrderPrice, "OK");
        }
    }

    private void DefautButton_Clicked(object sender, EventArgs e)
    {
        DefautButton.BorderColor = Color.FromArgb("#6df263s");
        InterCityButton.BorderColor = Color.FromArgb("#f6f6f6");
        CargoButton.BorderColor = Color.FromArgb("#f6f6f6");
        Title = DefautButton.Text;
        orderType = OrderTypeEnum.Default;
    }

    private void InterCityButton_Clicked(object sender, EventArgs e)
    {
        DefautButton.BorderColor = Color.FromArgb("#f6f6f6");
        InterCityButton.BorderColor = Color.FromArgb("#6df263s");
        CargoButton.BorderColor = Color.FromArgb("#f6f6f6");
        Title = InterCityButton.Text;
        orderType = OrderTypeEnum.InterCity;
    }

    private void CargoButton_Clicked(object sender, EventArgs e)
    {
        DefautButton.BorderColor = Color.FromArgb("#f6f6f6");
        InterCityButton.BorderColor = Color.FromArgb("#f6f6f6");
        CargoButton.BorderColor = Color.FromArgb("#6df263s");
        Title = CargoButton.Text;
        orderType = OrderTypeEnum.Cargo;
    }

    private async void Order_Clicked(object sender, EventArgs e)
    {
        var toast = Toast.Make("", CommunityToolkit.Maui.Core.ToastDuration.Short);
        if (orderType != 0)
        {
            if (FromEntry.Text != null && FromEntry.Text != "")
            {
                if (ToEntry.Text != null && ToEntry.Text != "")
                {
                    if (ChoiceDatePicker.Date >= DateTime.Now.Date)
                    {
                        if (Convert.ToInt32(PassengersEntry.Text) >= 1 && PassengersEntry.Text != null && PassengersEntry.Text != "")
                        {
                            OrderEntity order = new()
                            {
                                OrderId = id,
                                OrderType = orderType,
                                OrderFrom = FromEntry.Text,
                                OrderTo = ToEntry.Text,
                                OrderDate = ChoiceDatePicker.Date,
                                OrderPassengers = Convert.ToInt32(PassengersEntry.Text),
                                OrderComment = CommentEntry.Text,
                                OrderPrice = Convert.ToInt32(PriceEntry.Text)
                            };
                            orders.Add(order);
                            id++;
                            

                            toast = Toast.Make("Успешно", CommunityToolkit.Maui.Core.ToastDuration.Short, 10);
                            await toast.Show();
                        }
                        else
                        {
                            toast = Toast.Make("Пасажиров не может быть меньше 1!", CommunityToolkit.Maui.Core.ToastDuration.Short, 10);
                            await toast.Show();
                        }

                    }
                    else
                    {
                        toast = Toast.Make("Вы не можете путешествовать в прошлое!", CommunityToolkit.Maui.Core.ToastDuration.Short, 10);
                        await toast.Show();
                    }
                }
                else
                {
                    toast = Toast.Make("Введите точку назначения!", CommunityToolkit.Maui.Core.ToastDuration.Short, 10);
                    await toast.Show();
                }
            }
            else
            {
                toast = Toast.Make("Введите точку отправления!", CommunityToolkit.Maui.Core.ToastDuration.Short, 10);
                await toast.Show();
            }
        }
        else
        {
            toast = Toast.Make("Выберите тип такси!", CommunityToolkit.Maui.Core.ToastDuration.Short, 10);
            await toast.Show();
        }
    }
    
    private async void UserNotAuth()
    {
        List<UserSessionEntity> entity = new();
        await Task.Run(async () =>
        {
            entity = await db.GetItemsAsync();
        });
        if (entity.Count == 0)
            await Navigation.PushModalAsync(new MainPage());
    }
}