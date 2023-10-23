﻿using TaxiApp.Const;
using TaxiApp.Entity.Users;

namespace TaxiApp.Pages
{
    public partial class MainPage : ContentPage
    {
        private List<UserEntity> users = new() {
            new UserEntity {
                Id = 1, // эти данные устанавливаются по умолчанию
                FIO = "Иванов Иван Иванович",
                Gender= GenderEnum.MALE,
                Phone = "+7 (981) 111-11-11",
                Role=RoleEnum.CLIENT,  // эти данные устанавливаются по умолчанию
                Rating = 5.0F  // эти данные устанавливаются по умолчанию
            },
            new UserEntity {
                Id = 2, // эти данные устанавливаются по умолчанию
                FIO = "Джугашвили Иосиф Виссарионович",
                Gender= GenderEnum.MALE,
                Phone = "+7 (981) 222-22-22",
                Role=RoleEnum.CLIENT,  // эти данные устанавливаются по умолчанию
                Rating = 5.0F  // эти данные устанавливаются по умолчанию
            },
            new UserEntity {
                Id = 3, // эти данные устанавливаются по умолчанию
                FIO = "Иванов Иван Иванович",
                Gender= GenderEnum.MALE,
                Phone = "+7 (981) 333-33-33",
                Role=RoleEnum.CLIENT,  // эти данные устанавливаются по умолчанию
                Rating = 5.0F  // эти данные устанавливаются по умолчанию
            },
            new UserEntity {
                Id = 4, // эти данные устанавливаются по умолчанию
                FIO = "Случай Ольга Игоревна",
                Gender= GenderEnum.FEMALE,
                Phone = "+7 (981) 444-44-44",
                Role=RoleEnum.CLIENT,  // эти данные устанавливаются по умолчанию
                Rating = 5.0F  // эти данные устанавливаются по умолчанию
            },
            new UserEntity {
                Id = 5, // эти данные устанавливаются по умолчанию
                FIO = "Макс Илон Иванович",
                Gender= GenderEnum.MALE,
                Phone = "+7 (981) 555-55-55",
                Role=RoleEnum.CLIENT,  // эти данные устанавливаются по умолчанию
                Rating = 5.0F  // эти данные устанавливаются по умолчанию
            },
            new UserEntity {
                Id = 6, // эти данные устанавливаются по умолчанию
                FIO = "Масква Илона Ивановна",
                Gender= GenderEnum.FEMALE,
                Phone = "+7 (981) 666-66-66",
                Role=RoleEnum.CLIENT,  // эти данные устанавливаются по умолчанию
                Rating = 5.0F  // эти данные устанавливаются по умолчанию
            },

        };

        UserSessionInfoItemDatabase db = new();

        private string _phoneEntry { get; set; }

        private string _code = "000000";

        public MainPage()
        {
            InitializeComponent();
            UserAuth();
            PhoneEntry.TextChanged += (s, e) =>
            {
                if (e.NewTextValue.Length >= PhoneEntry.Mask.Length)
                {
                    PhoneEntry.CursorPosition = PhoneEntry.Mask.Length;
                }
                else
                {
                    PhoneEntry.CursorPosition = e.NewTextValue.Length;
                }
            };
        }

        private async void UserAuth()
        {
            UserSessionInfoItemDatabase db = new();
            List<UserSessionEntity> entity = new();
            await Task.Run(async () =>
            {
                entity = await db.GetItemsAsync();
            });
            if (entity.Count == 1)
                await Navigation.PopModalAsync();
        }

        private bool is_validPhoneNumber() 
        {
            if (_phoneEntry.Length < 18)
            {
                DisplayAlert("Ошибка ввода", "Неверный номер телефона!", "OK");
                return false;
            }
            return true;
        }

        private void Send_Clicked(object sender, EventArgs e)
        {
            _phoneEntry = PhoneEntry.Text;
            if (is_validPhoneNumber())
            {
                CodeEntry.IsVisible = true;
                SendButton.IsVisible = false;
                AuthButton.IsVisible = true;
            }

        }

        private async void AuthButton_Clicked(object sender, EventArgs e)
        {
            bool auth = false;
            foreach (UserEntity user in users)
            {
                if (user.Phone == _phoneEntry)
                {
                    if (_code == CodeEntry.Text)
                    {
                        auth = true;
                        UserSessionEntity sessionEntity = new()
                        {
                            Id = user.Id,
                            FIO = user.FIO,
                            Gender = user.Gender,
                            Phone = user.Phone,
                            Role = user.Role,
                            Rating = user.Rating
                        };
                        await db.DeleteAllItemsAsync();
                        await db.SaveItemAsync(sessionEntity);
                        await Navigation.PopModalAsync();
                        break;
                    }
                    else
                        await DisplayAlert("Ошибка ввода", "Неверный код!", "OK");
                }
            }
            if (auth == false)
                await DisplayAlert("Ошибка ввода", "Пользователя с таким номером не существует!", "OK");
        }
    }
}