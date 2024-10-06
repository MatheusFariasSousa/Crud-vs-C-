using Microsoft.EntityFrameworkCore;
using User_Model;

namespace data;

public class User_Controller:DbContext
{
    public User_Controller(DbContextOptions<User_Controller> options) : base(options)
    { 
    }
    public DbSet<User> Users { get; set; }    
}

