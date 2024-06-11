using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProductMarketplaceAPI
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RegisteredClientsController : ControllerBase
    {
        private readonly IRegisteredClientService _clientService;

        public RegisteredClientsController(IRegisteredClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _clientService.GetAllClientsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            if (client == null) return NotFound();
            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisteredClient client)
        {
            await _clientService.CreateClientAsync(client);
            return CreatedAtAction(nameof(GetById), new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, RegisteredClient client)
        {
            if (id != client.Id) return BadRequest();
            await _clientService.UpdateClientAsync(client);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _clientService.DeleteClientAsync(id);
            return NoContent();
        }
    }

}
