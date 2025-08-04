namespace API.Data
{
    public interface IAccountRepository
    {
        Task<UserEntity?> GetUserByCredentials(string username, string password);
        Task<UserEntity?> AddUser(string username, string email, string password);
    }
}
