using Microsoft.AspNetCore.Mvc;
using Sales.API.Data;
using Sales.Shared.Entities;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;
        public CountriesController(DataContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> Post(Country country)
        {
            _context.Countries.Add(country);

            await _context.SaveChangesAsync();
            return Ok(country);
        }
    }
}
