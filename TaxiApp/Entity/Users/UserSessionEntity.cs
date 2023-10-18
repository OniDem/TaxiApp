using TaxiApp.Const;

namespace TaxiApp.Entity.Users
{
    public class UserSessionEntity
    {
        public int Id { get; set; }

        public string FIO { get; set; }

        //public string FirstName { get; set; }

        //public string LastName { get; set; }

        //public string SurName { get; set; }

        public GenderEnum Gender { get; set; }

        public string Phone { get; set; }
        public RoleEnum Role { get; set; }

        public float Rating { get; set; }
    }
}
