﻿using DigitalReceipt.Data;
using DigitalReceipt.Data.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DigitalReceipt.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Exists(Expression<Func<User, bool>> expression) => context.Users.Any(expression);
    }
}
