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
    public class UsuarioController : Controller
    {
        private readonly Repository _repository;

        public UsuarioController(Repository repository)
        {
            _repository = repository;
        }


        // GET: api/values
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _repository.Usuarios.ToListAsync().ConfigureAwait(true);
            return Ok(usuarios);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(int id)
        {
            //pesquisar pelo id e retornar se for verdadeiro
            Usuario? usuario = await _repository.Usuarios
                                                    .FirstOrDefaultAsync(x => x.Id == id)
                                                    .ConfigureAwait(true);

            //erro 404 caso não exista
            if (usuario is null)
            {
                return NotFound();
            }
            // caso encontre, status 200
            return Ok(usuario);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            _repository.Usuarios.Add(usuario);

            await _repository.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);

        }



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] Usuario usuario)
        {
            bool existeUsuario = await _repository.Usuarios.AnyAsync(x => x.Id == id).ConfigureAwait(true);

            if (!existeUsuario)
            {
                return NotFound();
            }

            _repository.Entry(usuario).State = EntityState.Modified;
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _repository.Usuarios.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(true);

            if (usuario is null)
            {
                return NotFound();
            }

            _repository.Usuarios.Remove(usuario);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}

