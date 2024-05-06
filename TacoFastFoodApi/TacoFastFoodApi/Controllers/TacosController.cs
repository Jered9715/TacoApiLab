using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Runtime.InteropServices;
using TacoFastFoodApi.DAL;
using TacoFastFoodApi.Models;

namespace TacoFastFoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacosController : ControllerBase
    {
        private readonly TacosRepository _repo;

        public TacosController(TacosRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAllTacos(bool? softshell)
        {
            List<Taco> tacos = _repo.GetAllTacos();
            if (softshell == null)
            {
                return Ok(tacos);
            }
            else
            {
                List<Taco> softShellTacos = tacos.FindAll(t => (bool)(t.SoftShell== softshell));
                return Ok(softShellTacos);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetTacoById(int id)
        {
            Taco taco = _repo.GetTacoById(id);
            if (taco == null)
            {
                return NotFound();
            }
            return Ok(taco);
        }

        [HttpPost]
        public IActionResult PostTaco([FromBody] TacoCreationDto taco)
        {
            Taco newTaco = new Taco
            {
                Name = taco.Name,
                Cost = taco.Cost,
                Chips = taco.Chips,
                SoftShell = taco.SoftShell,
            };
            
            _repo.AddTaco(newTaco);
            return CreatedAtAction("GetTacoById", new { id = newTaco.Id}, newTaco);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTaco(int id)
        {
            Taco taco = _repo.GetTacoById(id);
            if (taco == null)
            {
                return NotFound();
            }
            _repo.DeleteTaco(id);
            return NoContent();
            
        }

    }
}
