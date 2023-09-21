﻿using Microsoft.EntityFrameworkCore;
using StoredProcedurewithEFCore.Models;

namespace StoredProcedurewithEFCore.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
