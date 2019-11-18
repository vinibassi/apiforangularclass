using DAL;
using DAL.Photo;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Web.Photos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class PhotosController : ControllerBase
    {
        private readonly IRepository<Photo> _repo;

        public PhotosController(IRepository<Photo> _repo)
        {
            this._repo = _repo;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public IActionResult Photos()
        {
            var list = _repo.All.ToList();
            if (list != null)
                return Ok(list);
            return BadRequest();
        }

        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Photo(int id)
        {
            var photo = _repo.Find(id);
            return Ok(photo);
        }

        [HttpGet("page/{index}")]
        [EnableCors("AllowOrigin")]
        public IActionResult PhotosByPage(int index)
        {
            var list = _repo.All.Skip((index -1) * 3).Take(3).ToList();

            if (list != null)
            {
                foreach (var item in list)
                {
                    item.Desc = $"{item.Desc}_{index}";
                }
                return Ok(list);
            }
            
            return BadRequest();
        }
    }
}