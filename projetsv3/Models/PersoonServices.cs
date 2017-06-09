using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetsv3.Models
{
    public class PersoonServices
    {
        public bool CheckLogin(String Login, String Paswoord)
        {
            bool res = false;
            using (var db = new INFO_c1035462Entities())
            {
                var list = db.Proj_pers.ToList();
                foreach (var item in list)
                {
                    if (item.login.Equals(Login) && item.password.Equals(Paswoord))
                    {
                        res = true;
                    }
                }

            }
            return res;
        }
        public projetsv3.persoon GetPersoon(string login)
        {
            projetsv3.persoon p;
            using (var db = new INFO_c1035462Entities())
            {
               p = db.Proj_pers.Where(x => x.login == login).First();
            }
            return p;
        }
    }
}