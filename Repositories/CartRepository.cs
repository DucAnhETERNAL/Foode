﻿using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CartRepository : ICartRepository
    {
        public async Task Add(Cart cart)
        {
            await CartDAO.Instance.Add(cart);
        }

        public async Task Delete(int id)
        {
            await CartDAO.Instance.Delete(id);
        }

        public async Task<IEnumerable<Cart>> GetAllCarts()
        {
            return await CartDAO.Instance.GetCartAll();
        }

        public async Task<Cart> GetCartById(int id)
        {
            return await CartDAO.Instance.GetCartById(id);
        }

        public async Task Update(Cart cart)
        {
            await CartDAO.Instance.Update(cart);
        }
    }
}
