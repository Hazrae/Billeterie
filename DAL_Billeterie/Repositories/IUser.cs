using Models.User;

namespace DAL_Billeterie.Repositories
{
    public interface IUser : IRepository<User>
    {
        void AddAddress(UserAddress ua);
        void AddCard(UserCard uc);
        User Login(LoginUser lu);
        int UpdatePassword(UserPassword up);
    }
}