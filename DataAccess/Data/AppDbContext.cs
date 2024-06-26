﻿using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options) { }
        
        public DbSet<User> Users {  get; set; }   
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
}
}
