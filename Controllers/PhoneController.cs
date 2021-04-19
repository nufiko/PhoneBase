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
    public class PhoneController : ODataController
    {
        private readonly PhoneDbContext _context;

        public PhoneController(PhoneDbContext context)
        {
            _context = context;
        }

        [EnableQuery]
        [ODataRoute("phones")]
        public ActionResult<IEnumerable<Phone>> Get()
        {
            return _context.Phones;
        }

        [EnableQuery]
        [ODataRoute("phones({id})")]
        public ActionResult<Phone> Get([FromODataUri] int id)
        {
            return _context.Phones.Include(p => p.User).FirstOrDefault(p => p.Id == id);
        }

        [EnableQuery]
        [ODataRoute("phones({userId})")]
        public async Task<IActionResult> Post([FromBody] Phone phone, [FromODataUri]int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            phone.User = _context.Users.Find(userId);
            _context.Phones.Add(phone);
            await _context.SaveChangesAsync();

            return Created(phone);
        }
    }
}
