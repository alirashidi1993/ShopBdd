using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess;
using Shop.Entities;
using System.Collections.Generic;

namespace Shop.Controllers
{
    public class CartController:Controller
    {
        private readonly CartRepository repository;

        public CartController(CartRepository repository)
        {
            this.repository = repository;
        }

        public CartController()
        {
        }

        public ActionResult<IList<CartItem>> Index()
        {
            var items=repository.GetAll();
            return Ok(items);
        }
        public ActionResult Add(string sku,int quantity)
        {
            repository.Add(sku,quantity);
            return Ok();
        }
        public ActionResult Clear()
        {
            repository.DeleteAll();
            return Ok();
        }
    }
}
