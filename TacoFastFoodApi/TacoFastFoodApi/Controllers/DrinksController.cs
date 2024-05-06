using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacoFastFoodApi.DAL;
using TacoFastFoodApi.Models;

namespace TacoFastFoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private readonly DrinksRepository _repo;

        public DrinksController(DrinksRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAllDrinks()
        {
            List<Drink> drinks = _repo.GetAllDrinks();
            return Ok(drinks);
        }

        [HttpGet("{id}")]
        public IActionResult GetDrinkById(int id)
        {
            Drink drink = _repo.GetDrinkById(id);
            if (drink != null)
            {
                return Ok(drink);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddDrink([FromBody] DrinkCreationDto drink)
        {
            Drink newDrink = new Drink
            {
                Name = drink.Name,
                Cost = drink.Cost,
                Slushie = drink.Slushie,
            };
            _repo.AddDrink(newDrink);
            return CreatedAtAction("GetDrinkById", new { id = newDrink.Id }, newDrink);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDrink(int id, [FromBody]DrinkUpdateDto drink)
        {
            Drink updatedDrink = _repo.GetDrinkById(id);
            if (updatedDrink == null)
            {
                return NotFound();
            }
            updatedDrink.Name = drink.Name;
            updatedDrink.Cost = drink.Cost;
            updatedDrink.Slushie = drink.Slushie;

            _repo.UpdateDrink(updatedDrink);
            return NoContent();

        }

    }
}
