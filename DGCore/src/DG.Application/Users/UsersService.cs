using System;
using System.Collections.Generic;
using System.Text;
using DG.Application.Users.Dtos;
using DG.EntityFramework;
using DG.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DG.Application.Users
{
    public class UsersService : IUsersService
    {
        private readonly DGDbContext _dbContext;
        private readonly DbSet<UsersEntity> _dbSet;
        public UsersService(DGDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<UsersEntity>();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
