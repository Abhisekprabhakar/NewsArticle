using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using DataModel.DAC;

namespace businessLogic
{
    public class userLogic
    {
        UserDAC ud;
        public userLogic()
        {
            ud = new UserDAC();
        }



        public string AddUser(User u)
        {
            string res = "False";
            if (u.name.Length < 3 && u.username.Length < 8 && u.password.Length < 6)
            {
                res = "False";
            }
            else
            {
                if (ud.checkUsername(u.username))
                {
                    res = ud.AddUser(u);
                }
            }
            return res;
        }

        public int CheckUser(string username,string password)
        {
            int userId = 0;
            if (username.Length < 8 && password.Length < 6)
            {
                userId = 0;
            }
            else
            {
                userId = ud.CheckUser(username, password);
            }
            return userId;
        }

        public string getUserType(int uId)
        {
            if (uId <= 0)
            {
                return null;
            }
            else
            {
                return ud.getUserType(uId);
            }
        }
    }
}
