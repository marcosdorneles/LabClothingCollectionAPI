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
    public class UsuarioController : Controller
    {
        private readonly Repository _repository;

        public UsuarioController(Repository repository)
        {
            _repository = repository;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] StatusUsuario? status)
        {
            List<Usuario> usuarios = await _repository.Usuarios
                 .Where(x => status != null ? x.StatusUsuario == status : x.StatusUsuario != null).ToListAsync();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Usuario, UsuarioResponseDTO>();
            });
            var mapper = configuration.CreateMapper();
            List<UsuarioResponseDTO> usuarioResponseDTO =
                             mapper.Map<List<UsuarioResponseDTO>>(usuarios);
            return Ok(usuarioResponseDTO);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetId(int id)
        {
            var usuario = await _repository.Usuarios
                .FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(true);
            var configuration = new MapperConfiguration(
                   cfg => cfg.CreateMap<Usuario, UsuarioResponseDTO>());
            var mapper = configuration.CreateMapper();
            UsuarioResponseDTO usuarioResponseDTO =
                             mapper.Map<UsuarioResponseDTO>(usuario);
            if (usuario is null)
            {
                return NotFound("Usuário não encontrado");
            }
            return Ok(usuario);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            var UsuarioExiste = await _repository.Usuarios
                .FirstOrDefaultAsync(x => x.cpf == usuario.cpf).ConfigureAwait(true);
            if (UsuarioExiste is null)
            {
                _repository.Usuarios.Add(usuario);
                await _repository.SaveChangesAsync();
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<StatusUsuario, string>().ConvertUsing(su => su.ToString());
                    cfg.CreateMap<TipoUsuario, string>().ConvertUsing(tu => tu.ToString());
                    cfg.CreateMap<Usuario, UsuarioResponseDTO>();
                });
                var mapper = configuration.CreateMapper();
                UsuarioResponseDTO usuarioResponseDTO = mapper.Map<UsuarioResponseDTO>(usuario);
                return CreatedAtAction(nameof(Get),
                    new { id = usuarioResponseDTO.Id }, usuarioResponseDTO);
            }
            return Conflict("Usuário já cadastrado");
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

