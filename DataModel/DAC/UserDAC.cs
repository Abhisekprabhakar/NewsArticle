using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DAC
{
    public class UserDAC
    {
        News_articleEntities db;
        public UserDAC()
        {
            db = new News_articleEntities();
        }

        public bool checkUsername(string username)
        {
            bool check = false;
            try
            {
                if (db.Users.FirstOrDefault(x => x.username == username) != default)
                    check = false;
                else
                    check = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception.", ex);
                check = false;
            }
            return check;
        }

        public string AddUser(User u)
        {
            string res = "False";
            try
            {
                u.role = "user";
                db.Users.Add(u);
                db.SaveChanges();
                res = "True";

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception.", ex);
                res = "False";
            }

            return res;
        }

        public int CheckUser(string username, string password)
        {
            int userId = 0;
            try
            {
                var testId = from x in db.Users
                             where (x.username == username) && (x.password == password)
                             select x.Id;

                if (testId != null)
                {
                    foreach (var item in testId)
                    {
                        userId = item;
                    }

                }
                else
                {
                    userId = 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception.", ex);
                userId = 0;
            }
            return userId;
        }

        public string getUserType(int userId)
        {
            string usertype;
            try
            {
                var user = db.Users.FirstOrDefault(x => x.Id == userId);
                if (user != null)
                {
                    usertype = user.role;
                }
                else
                {
                    usertype = null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception.", ex);
                usertype = null;
            }
            return usertype;
        }
    }
}

