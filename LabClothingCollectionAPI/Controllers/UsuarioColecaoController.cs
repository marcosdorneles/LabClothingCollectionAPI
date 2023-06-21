using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LabClothingCollectionAPI.DTO;
using LabClothingCollectionAPI.Models;
using LabClothingCollectionAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LabClothingCollectionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioColecaoController : Controller
    {
        private readonly Repository _repository;

        public UsuarioColecaoController(Repository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioColecao>>> GetUsuarioColecao()
        {
            return await _repository.UsuarioColecaoModels.Include(x => x.Usuario).Include(y => y.Colecao).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioColecao>> GetUsuarioColecao(int id)
        {
            var colecaoUsuario = await _repository.UsuarioColecaoModels.FindAsync(id);

            if (colecaoUsuario == null)
            {
                return NotFound();
            }

            return colecaoUsuario;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioColecao>> PostUsuarioColecao(UsuarioColecaoDTO usuarioColecaoDTO)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<UsuarioColecaoDTO, UsuarioColecao>());

            var mapper = configuration.CreateMapper();

            UsuarioColecao usuarioColecao = mapper.Map<UsuarioColecao>(usuarioColecaoDTO);

            _repository.UsuarioColecaoModels.Add(usuarioColecao);
            await _repository.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioColecao", new { id = usuarioColecao.Id }, usuarioColecao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioColecao(int id, UsuarioColecao usuarioColecao)
        {
            if (id != usuarioColecao.Id)
            {
                return BadRequest();
            }

            _repository.Entry(usuarioColecao).State = EntityState.Modified;

            try
            {
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioColecaoExists(id))
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
        public async Task<IActionResult> DeleteUsuarioColecao(int id)
        {
            var usuarioColecao = await _repository.UsuarioColecaoModels.FindAsync(id);
            if (usuarioColecao == null)
            {
                return NotFound();
            }

            _repository.UsuarioColecaoModels.Remove(usuarioColecao);
            await _repository.SaveChangesAsync();

            return NoContent();
        }


        private bool UsuarioColecaoExists(int id)
        {
            return _repository.UsuarioColecaoModels.Any(e => e.Id == id);
        }
    }
}

