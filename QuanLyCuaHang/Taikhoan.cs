using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang
{
     class Taikhoan
    {
        private  string username;
        private string password;
        private string role;


        public  string Username { get => username; set => username = value; }
        public  string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }

        public Taikhoan()
        {
           
        }

        public Taikhoan(string username, string password,string role)
        {
            this.username = username;
            this.password = password;   
            this.role = role;
        }

    }
}
