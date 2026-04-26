using CategoryDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

public class CategoryRepository : ICategoryRepository
{
    CategoryAuthenticationDbContext _context;

    public CategoryRepository(CategoryAuthenticationDbContext context)
    {
        _context = context;
    }

    public async Task<User> Login(string Email, string Password)
    {
        try
        {
             return await _context.Users.Include("Role").FirstOrDefaultAsync(x => x.Email == Email && x.Password == Password);

        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public async Task<bool> Regester(User user)
    {
        try
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
        catch(Exception ex)
        {
            return false;
        }
    }
}