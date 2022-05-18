using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.DataAccess
{
    public class CartRepository
    {
        public CartRepository()
        {
            CartItems = new List<CartItem>();
        }
        private IList<CartItem> CartItems;
        public IList<CartItem> GetAll()
        {
            return CartItems;
        }
        public void Add(string sku, int quantity)
        {
            var existingItem = CartItems.FirstOrDefault(i => i.SKU == sku);
            if (existingItem == null)
                CartItems.Add(new CartItem(sku, quantity));
            else
                existingItem.Quantity += quantity;
        }
        public void DeleteAll()
        {
            CartItems.Clear();
        }
    }
}
