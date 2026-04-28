using CategoryDAL;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICategoryRepository
{
    Task<bool> Regester(User user);
    Task<User> Login(string Email , string Password);
}