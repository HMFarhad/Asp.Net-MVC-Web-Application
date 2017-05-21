using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FKM_Diagnostic_Center
{
    public class DBSeeder: DropCreateDatabaseIfModelChanges<UserDBContext>
    {
        protected override void Seed(UserDBContext context)
        {
            User user = new User()
            {
                username="admin",
                password="admin",
                email="admin@fkm.com",
                address="18/A, Banani",
                phone="01808420420",
                type="admin"
            };
            context.Users.Add(user);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}