using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICategoryService
{
    Task<bool> Regester(UserModel user);

    Task<UserModel> Login(string Email , string Password);
}