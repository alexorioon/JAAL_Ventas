﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared.Entities;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriasController : ControllerBase
    {
        private readonly DataContext _context;
        public CategoriasController(DataContext context)
        {
            _context = context;
        }

        //Método Post
        [HttpPost]
        public async Task<ActionResult> Post(Categoria categoria)
        {
            _context.Categorias.Add(categoria);

            await _context.SaveChangesAsync();
            return Ok(categoria);
        }

        //Método Get
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Categorias.ToListAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        //Método Put
        [HttpPut]
        public async Task<ActionResult> PutAsync(Categoria categoria)
        {
            _context.Update(categoria);
            await _context.SaveChangesAsync();
            return Ok(categoria);
        }

        //Método Delete
        [HttpDelete("(id:int)")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }
            _context.Remove(categoria);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
