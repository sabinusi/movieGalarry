using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class user
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public List<user> listuser = new List<user>();
        public List<user> ReturnUsers() {
            listuser.Add(new user()
            {
                Id = 1,
                username = "sabinusi",
                password = "sabinusi"
            });
            listuser.Add(new user()
            {
                Id = 2,
                username = "mlambo",
                password = "mlambo"
            });
            return listuser;
        }

    }
}