using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacoFastFoodApi.DAL;

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


    }
}
