using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LabClothingCollectionAPI.DTO;
using LabClothingCollectionAPI.Models;
using LabClothingCollectionAPI.Models.Enums;
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



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] StatusColecao? status, [FromQuery] Estacoes estacao)
        {
            List<Colecao> colecao = await _repository.ColecaoModels
                 .Where(x => x.Status == status && x.Estacao == estacao)
                 .ToListAsync();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Colecao, ColecaoControllerDTO>();
            });
            var mapper = configuration.CreateMapper();
            List<ColecaoControllerDTO> colecaoControllerDTO =
                             mapper.Map<List<ColecaoControllerDTO>>(colecao);
            return Ok(colecao);
        }


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


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Post([FromBody] Colecao colecao)
        {
            var ColecaoExiste = await _repository.ColecaoModels
                .FirstOrDefaultAsync(x => x.Nome == colecao.Nome).ConfigureAwait(true);
            if (ColecaoExiste is null)
            {
                _repository.ColecaoModels.Add(colecao);
                await _repository.SaveChangesAsync();
                var configuration = new MapperConfiguration(cfg =>
                {

                    cfg.CreateMap<Colecao, ColecaoControllerDTO>();
                });
                var mapper = configuration.CreateMapper();
                ColecaoControllerDTO colecaoController = mapper.Map<ColecaoControllerDTO>(colecao);
                return CreatedAtAction(nameof(Get),
                    new { id = colecaoController.Id }, colecaoController);
            }
            return Conflict("Coleção já cadastrada");
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

        [HttpPatch("{id}/status")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PatchStatus(int id, [FromBody] StatusColecao status)
        {
            var colecao = await _repository.ColecaoModels.FindAsync(id).ConfigureAwait(true);

            if (colecao == null)
            {
                return NotFound();
            }

            colecao.Status = status;
            await _repository.SaveChangesAsync();

            return Ok(colecao);
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

