using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacoFastFoodApi.DAL;

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


    }
}
