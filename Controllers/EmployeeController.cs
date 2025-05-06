using Abfirstapplicationapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Abfirstapplicationapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly Employeecontext _context;
        public EmployeeController(Employeecontext context)
        {
            _context = context;
        }
        [HttpGet("Country")]
        public IActionResult GetCountry()
        {
            var count = _context.countries.ToList();
            return Ok(count);
        }
        [HttpGet("states/{cid}")]
        public IActionResult Getstates(int cid)
        {
            var state = _context.States.Where(s => s.cid == cid).ToList();
            return Ok(state);
        }
        [HttpGet("city/{sid}")]
        public IActionResult GetCities(int sid)
        {
            var state = _context.cities.Where(c => c.sid == sid).ToList();
            return Ok(state);
        }
        [HttpGet]
        public IActionResult GetUser()
        {
            var user = (from u in _context.Employees
                        join ct in _context.cities on u.ctid equals ct.ctid
                        join s in _context.States on ct.sid equals s.sid
                        join cc in _context.countries on s.cid equals cc.cid
                        select new
                        {
                            u.uid,
                            u.fname,
                            u.lname,
                            u.email,
                            u.gender,
                            u.dob,
                            ct.ctname,
                            s.sname,
                            cc.cname,
                            u.address,
                            u.pincode
                        }).ToList();
            return Ok(user);
        }
        [HttpGet("{uid}")]
        public IActionResult GetUser(int uid)
        {
            var user = (from u in _context.Employees
                        join ct in _context.cities on u.ctid equals ct.ctid
                        join s in _context.States on ct.sid equals s.sid
                        join cc in _context.countries on s.cid equals cc.cid
                        select new
                        {
                            u.uid,
                            u.fname,
                            u.lname,
                            u.email,
                            u.gender,
                            u.dob,

                            ct.ctname,
                            s.sname,
                            cc.cname,
                            u.address,
                            u.pincode
                        }).ToList();
            return Ok(user);
        }
        
        [HttpGet("Employee/{fname}")]
        public IActionResult GetuserByName(string fname)
        {
            var user = _context.Employees.Find(fname);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Insert(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok(employee);
        }

        [HttpPut("{uid}")]
        public IActionResult Update(int uid, [FromBody] Employee employee)
        {
            if (employee == null || uid != employee.uid)
            {
               // return BadRequest(new { message = "Employee data is valid." });
            }

            var user = _context.Employees.Find(uid);
            if (user == null)
            {
                return NotFound(new { message = "Employee not found." });
            }

            // Update properties
            user.fname = employee.fname;
            user.lname = employee.lname;
            user.email = employee.email;
            user.gender = employee.gender;
            user.dob = employee.dob;
            user.cid = employee.cid;
            user.sid = employee.sid;
            user.ctid = employee.ctid;
            user.address = employee.address;
            user.pincode = employee.pincode;

            _context.SaveChanges();

            return Ok(new { message = "User updated successfully." }); 
        }


        [HttpDelete("{uid}")]
        public IActionResult Delete(int uid)
        {
            var user = _context.Employees.Find(uid);
            if (user == null)
            {
                return NotFound();
            }

            user.isDeleted = true;
            user.isActive = false;
            _context.SaveChanges();
            return Ok(new { message = "User soft-deleted successfully." });
        }
    }
}