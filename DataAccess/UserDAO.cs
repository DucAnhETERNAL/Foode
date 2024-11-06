﻿using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDAO : SingletonBase<UserDAO>
    {
        public async Task<IEnumerable<User>> GetUserAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            return user;
        }

        public async Task Add(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            var existingItem = await GetUserById(user.UserId);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(user);
            }
            else
            {
                _context.Users.Add(user);
            }
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var user = await GetUserById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}