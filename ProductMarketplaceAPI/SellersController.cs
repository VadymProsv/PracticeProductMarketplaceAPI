using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProductMarketplaceAPI
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SellersController : ControllerBase
    {
        private readonly ISellerService _sellerService;

        public SellersController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _sellerService.GetAllSellersAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var seller = await _sellerService.GetSellerByIdAsync(id);
            if (seller == null) return NotFound();
            return Ok(seller);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Seller seller)
        {
            await _sellerService.CreateSellerAsync(seller);
            return CreatedAtAction(nameof(GetById), new { id = seller.Id }, seller);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Seller seller)
        {
            if (id != seller.Id) return BadRequest();
            await _sellerService.UpdateSellerAsync(seller);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _sellerService.DeleteSellerAsync(id);
            return NoContent();
        }
    }

}
