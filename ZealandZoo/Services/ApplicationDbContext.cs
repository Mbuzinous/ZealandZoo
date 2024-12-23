﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZealandZoo.Models;

namespace ZealandZoo.Services
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            var board = new IdentityRole("board");
            board.NormalizedName = "board";

            builder.Entity<IdentityRole>().HasData(admin, board);
        }
    }
}
