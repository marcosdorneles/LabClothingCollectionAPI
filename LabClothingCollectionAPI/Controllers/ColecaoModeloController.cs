using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LabClothingCollectionAPI.DTO;
using LabClothingCollectionAPI.Models;
using LabClothingCollectionAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LabClothingCollectionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColecaoModeloController : Controller
    {
        private readonly Repository _repository;

        public ColecaoModeloController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColecaoModelo>>> GetColecaoModelo()
        {
            return await _repository.ColecaoModelos.Include(x => x.Colecao).Include(y => y.Modelo).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ColecaoModelo>> GetColecaoModelo(int id)
        {
            var colecaoModelo = await _repository.ColecaoModelos.FindAsync(id);

            if (colecaoModelo == null)
            {
                return NotFound();
            }

            return colecaoModelo;
        }


        [HttpPost]
        public async Task<ActionResult<ColecaoModelo>> PostUsuarioColecao(ColecaoModeloDTO colecaoModeloDTO)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<ColecaoModeloDTO, ColecaoModelo>());

            var mapper = configuration.CreateMapper();

            ColecaoModelo colecaoModelo = mapper.Map<ColecaoModelo>(colecaoModeloDTO);

            _repository.ColecaoModelos.Add(colecaoModelo);
            await _repository.SaveChangesAsync();

            return CreatedAtAction("GetColecaoModelo", new { id = colecaoModelo.Id }, colecaoModelo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutColecaoModelo(int id, ColecaoModelo colecaoModelo)
        {
            if (id != colecaoModelo.Id)
            {
                return BadRequest();
            }

            _repository.Entry(colecaoModelo).State = EntityState.Modified;

            try
            {
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColecaoModeloExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColecaoModelo(int id)
        {
            var colecaoModelo = await _repository.ColecaoModelos.FindAsync(id);
            if (colecaoModelo == null)
            {
                return NotFound();
            }

            _repository.ColecaoModelos.Remove(colecaoModelo);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        private bool ColecaoModeloExists(int id)
        {
            return _repository.ColecaoModelos.Any(e => e.Id == id);
        }
    }
}

