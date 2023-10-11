using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Const;

namespace TaxiApp.Entity.Users
{
    public class UserEntity
    {
        public int Id {  get; set; }

        public string FIO { get; set; }

        //public string FirstName { get; set; }

        //public string LastName { get; set; }

        //public string SurName { get; set; }

        public GenderEnum Gender { get; set; }

        public string Phone {  get; set; }

        public string Code { get; set; }

        public RoleEnum Role { get; set; }

        public float Rating { get; set; }

        public string CarNumber { get; set; }

        public string CarModel { get; set; }

        public string CarColor { get; set; }

        public string CarClass { get; set; }

        public string BirthDate { get; set; }

        public string Disability { get; set; }

    }
}
