using Models.Errors;
using Models.User;

namespace DAL_Billeterie.Repositories
{
    public interface IUser : IRepository<User>
    {    
        void AddCard(UserCard uc);
        UserCheckOut GetCheckOutInfo(int id);
        User Login(LoginUser lu);
        int UpdatePassword(int id,UserPassword up);
        void Create(RegisterUser ru);
    }
}