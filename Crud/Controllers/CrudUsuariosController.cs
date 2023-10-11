using Crud.Models.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudUsuariosController : ControllerBase
    {
        public readonly CrudContext _context;

        public CrudUsuariosController(CrudContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return _context.Usuarios.ToList();
        }

        [HttpGet("/{id}")]
        public async Task<Usuario?> GetById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        [HttpPost]
        public async Task<IActionResult> Get(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            var result = _context.SaveChanges();

            if(result > 0)
            {
                return Ok(usuario);
            }

            return BadRequest();

        }


        [HttpPut]
        public async Task<IActionResult> update(Usuario usuario)
        {
            var result = _context.Usuarios.Any(u => u.Id == usuario.Id);

            if(result == false)
            {
                return BadRequest();
            }
            _context.Usuarios.Update(usuario);
            var resultUpdate = _context.SaveChanges();

            if (resultUpdate > 0)
            {
                return Ok(usuario);
            }

            return BadRequest();

        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _context.Usuarios.Find(id);

            if (result == null)
            {
                return BadRequest();
            }

            _context.Usuarios.Remove(result);

            return Ok();
        }
    }
}
