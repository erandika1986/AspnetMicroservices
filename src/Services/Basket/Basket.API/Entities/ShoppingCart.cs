using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Entities
{
  public class ShoppingCart
  {
    public ShoppingCart(string userName)
    {
      this.UserName = userName;
      Items = new List<ShoppingCartItem>();
    }
    public string UserName { get; set; }
    public List<ShoppingCartItem> Items { get; set; }

    public decimal TotalPrice
    {
      get
      {
        decimal totalPrice = 0;
        foreach(var item in Items)
        {
          totalPrice += item.Price * item.Quantity;
        }

        return totalPrice;
      }
    }
  }
}
