using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBase.DAL;
using PhoneBase.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBase.Controllers
{
    [Route("[controller]")]
    public class UserController : ODataController
    {
        PhoneDbContext _context;

        public UserController(PhoneDbContext context)
        {
            _context = context;
        }

        [EnableQuery]
        [ODataRoute("users")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var result = _context.Users;
            return result;
        }

        [EnableQuery]
        [ODataRoute("users({id})")]
        public async Task<ActionResult<User>> Get([FromODataUri] int id)
        {
            var result = await _context.Users.Include(u => u.Phones).FirstOrDefaultAsync(u => u.Id == id);
            return result;
        }

        [EnableQuery]
        [ODataRoute("users")]
        public async Task<IActionResult> PostUser([FromBody] User newUser)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.Select(state => state.Errors));
            }
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return Created(newUser);
        }
    }
}
