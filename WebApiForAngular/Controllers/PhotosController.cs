using DALPhotos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApiForAngular.Model;

namespace WebApiForAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IRepository<Photo> _repo;

        public PhotosController()
        {

        }

        [HttpGet]
        public IActionResult Photos()
        {
            var list = _repo.All.Select(p => p).ToList();
            return Ok(list);
        }

        [HttpGet("photos/{id}")]
        public IActionResult Photo(int id)
        {
            var photo = _repo.Find(id);
            return Ok(photo);
        }

    }
}