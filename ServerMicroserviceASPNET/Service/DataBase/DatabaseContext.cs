using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Service.DataBase.Entities;

namespace Service.DataBase
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"data source=DESKTOP-26GQVUP; 
                initial catalog=UserMicroService;
                persist security info=True;
                user id=YazanGh;
                password=Coldzero123123;"
            );
        }

    }
}
