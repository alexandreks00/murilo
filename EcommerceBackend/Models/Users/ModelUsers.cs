using DemoRestSharp.Models.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRestSharp.Models.Users
{
    class ModelUsers
    {
        public string Id { get; set; }

        public string Password { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public string DateOfBirth { get; set; }

        public string CityId { get; set; }

        public string StateId { get; set; }

        public string Phone1 { get; set; }

        public string CpfNf { get; set; }

        public string Message { get; set; }

        public ModelCity City { get; set; }

        public ModelMember Member { get; set; }

        public ModelAppInfo AppInfo { get; set; }

    }
}
