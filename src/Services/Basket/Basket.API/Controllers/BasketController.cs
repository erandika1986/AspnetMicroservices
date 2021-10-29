using Basket.API.Entities;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
  [Route("api/v1/[controller]")]
  [ApiController]
  public class BasketController : ControllerBase
  {
    private readonly IBasketRepository _basketRepository;

    public BasketController(IBasketRepository basketRepository)
    {
      _basketRepository = basketRepository?? throw new ArgumentNullException(nameof(basketRepository));
    }


    [HttpGet("{userName}",Name ="GetBasket")]
    [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
    {
      var response = await _basketRepository.GetBasket(userName);

      return Ok(response?? new ShoppingCart(userName));
    }


    [HttpPost]
    [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
    {
      var response = await _basketRepository.UpdateBasket(basket);

      return Ok(response);
    }

    [HttpDelete("{userName}",Name ="DeleteBasket")]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteBasket(string userName)
    {
      await _basketRepository.DeleteBasket(userName);

      return Ok();
    }
  }
}
