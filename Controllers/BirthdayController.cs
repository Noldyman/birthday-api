using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Birthday_Api.Models;

namespace Birthday_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirthdayController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Birthday>>> GetAllBirthdays()
        {
            using (var db = new BirthdayContext())
            {
                var birthdays = db.Birthdays.ToList();
                return birthdays;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Birthday>> GetBirthday(int id)
        {
            using (var db = new BirthdayContext())
            {
                var birthday = await db.Birthdays.FindAsync(id);
                if (birthday == null)
                {
                    return NotFound();
                }
                return birthday;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Birthday>> CreateBirthday(Birthday newBirthday)
        {
            using (var db = new BirthdayContext())
            {
                await db.AddAsync(newBirthday);
                db.SaveChanges();
                return newBirthday;
            }
        }

        [HttpPut]
        public async Task<ActionResult<Birthday>> UpdateBirthday(Birthday updatedBirthday)
        {
            using (var db = new BirthdayContext())
            {
                db.Update(updatedBirthday);
                await db.SaveChangesAsync();
                return updatedBirthday;
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Birthday>> DeleteBirthday(int id)
        {
            using (var db = new BirthdayContext())
            {
                var birthday = await db.Birthdays.FindAsync(id);
                if (birthday == null)
                {
                    return NotFound();
                }

                db.Remove(birthday);
                await db.SaveChangesAsync();
                return birthday;
            }
        }
    }
}