using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabClothingCollectionAPI.Models;
using LabClothingCollectionAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LabClothingCollectionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModeloController : Controller
    {
        private readonly Repository _repository;

        public ModeloController(Repository repository)
        {
            _repository = repository;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var modelos = await _repository.Modelos.ToListAsync().ConfigureAwait(true);
            return Ok(modelos);
        }



        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(int id)
        {
            //pesquisar pelo id e retornar se for verdadeiro
            Modelo? modelo = await _repository.Modelos
                                                    .FirstOrDefaultAsync(x => x.Id == id)
                                                    .ConfigureAwait(true);

            //erro 404 caso não exista
            if (modelo is null)
            {
                return NotFound();
            }
            // caso encontre, status 200
            return Ok(modelo);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] Modelo modelo)
        {
            _repository.Modelos.Add(modelo);

            await _repository.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = modelo.Id }, modelo);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] Modelo modelo)
        {
            bool existeModelo = await _repository.Modelos.AnyAsync(x => x.Id == id).ConfigureAwait(true);

            if (!existeModelo)
            {
                return NotFound();
            }

            _repository.Entry(modelo).State = EntityState.Modified;
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var modelo = await _repository.Modelos.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(true);

            if (modelo is null)
            {
                return NotFound();
            }

            _repository.Modelos.Remove(modelo);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}

