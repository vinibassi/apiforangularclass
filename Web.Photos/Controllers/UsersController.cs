using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.User;
using Microsoft.AspNetCore.Cors;

namespace Web.Photos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _repo;
        private readonly IUserRepository _user;

        public UsersController(IRepository<User> repo, IUserRepository _user)
        {
            this._user = _user;
            _repo = repo;
        }

        // GET: api/Users
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            //var list = _repo.All.ToList();
            var list = _user.GetList();

            if (list != null)
                return Ok(list);
            return BadRequest();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _repo.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [EnableCors("AllowOrigin")]
        [HttpPut("edit/{id}")]
        public IActionResult PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                _repo.Alterar(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Users
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [EnableCors("AllowOrigin")]
        [HttpPost("create")]
        public ActionResult<User> PostUser(User user)
        {
            _repo.Incluir(user);

            return Ok();
        }

        // DELETE: api/Users/delete/5
        [EnableCors("AllowOrigin")]
        [HttpDelete("delete/{id}")]
        public ActionResult<User> DeleteUser(int id)
        {
            var user = _repo.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _repo.Excluir(user);

            return Ok();
        }

        private bool UserExists(int id)
        {
            if (_repo.Find(id) != null)
            {
                return true;
            }
            return false;
        }
    }
}
