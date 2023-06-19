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
    public class ColecaoController : Controller
    {
        private readonly Repository _repository;

        public ColecaoController(Repository repository)
        {
            _repository = repository;
        }

        // GET: api/values
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var colecoes = await _repository.ColecaoModels.ToListAsync().ConfigureAwait(true);
            return Ok(colecoes);
        }

        // GET api/values/5
        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(int id)
        {
            //pesquisar pelo id e retornar se for verdadeiro
            Colecao? colecao = await _repository.ColecaoModels
                                                    .FirstOrDefaultAsync(x => x.Id == id)
                                                    .ConfigureAwait(true);

            //erro 404 caso não exista
            if (colecao is null)
            {
                return NotFound();
            }
            // caso encontre, status 200
            return Ok(colecao);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] Colecao colecao)
        {
            _repository.ColecaoModels.Add(colecao);

            await _repository.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = colecao.Id }, colecao);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] Colecao colecao)
        {
            bool existeColecao = await _repository.ColecaoModels.AnyAsync(x => x.Id == id).ConfigureAwait(true);

            if (!existeColecao)
            {
                return NotFound();
            }

            _repository.Entry(colecao).State = EntityState.Modified;
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var colecao = await _repository.ColecaoModels.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(true);

            if (colecao is null)
            {
                return NotFound();
            }

            _repository.ColecaoModels.Remove(colecao);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}

