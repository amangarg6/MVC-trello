using ProjectTask.Identity;

namespace ProjectTask.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<bool> IsUnique(string userName);
        Task<ApplicationUser?> AuthenticateUser(string userName, string userPassword);
        Task<bool> RegisterUser(ApplicationUser user);
        Task<ApplicationUser?> CheckUserInDb(string userName);
    }
}
