using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Press
{
    public class User
    {
        public string Login { get; set; } 

        public string Password { get; set; }


        public User(string login, string password)
        {
            if (login == null || password == null) throw new ArgumentNullException("Данных нет ");
            if(login.Length > Parameters.MAX_LOGIN_LENGTH || password.Length > Parameters.MAX_PASSWORD_LENGTH )
                throw new ArgumentNullException("Слишком длинный логин или пароль ");
            Login = login;
            Password = password;

        }
    }
}
