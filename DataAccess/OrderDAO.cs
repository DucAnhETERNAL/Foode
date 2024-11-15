﻿using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO :SingletonBase<OrderDAO>
    {
        public class OrderDAO : SingletonBase<OrderDAO>
        {
            public async Task<IEnumerable<Order>> GetOrderAll()
            {
                return await _context.Orders.ToListAsync();
            }

            public async Task<Order> GetOrderById(int id)
            {
                var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderDetailsId == id);
                return order;
            }

            public async Task Add(Order order)
            {
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
            }

            public async Task Update(Order order)
            {
                var existingItem = await GetOrderById(order.OrderDetailsId);
                if (existingItem != null)
                {
                    _context.Entry(existingItem).CurrentValues.SetValues(order);
                }
                else
                {
                    _context.Orders.Add(order);
                }
                await _context.SaveChangesAsync();
            }

            public async Task Delete(int id)
            {
                var order = await GetOrderById(id);
                if (order != null)
                {
                    _context.Orders.Remove(order);
                    await _context.SaveChangesAsync();
                }
            }
        }
}
