using DALPhotos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Web.Photos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IRepository<Photo> _repo;

        public PhotosController(IRepository<Photo> _repo)
        {
            this._repo = _repo;
        }

        [HttpGet]
        public IActionResult Photos()
        {
            var list = _repo.All.Select(p => p).ToList();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult Photo(int id)
        {
            var photo = _repo.Find(id);
            return Ok(photo);
        }

    }
}