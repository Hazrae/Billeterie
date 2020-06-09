using Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.User.Mapper
{
    public static class EditMapper
    {
        public static EditUser ToLocal(this Models.User.User u)
        {
            return new EditUser
            {
                UserID = u.UserID,
                Login = u.Login,
                Mail = u.Mail,
                BirthDate = u.BirthDate,
                SelectedCountry = u.Country
            };
        }
    }
}
