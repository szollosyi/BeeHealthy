using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bee_healthy_backend.Models;

namespace bee_healthy_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaciensekController : ControllerBase
    {
        [HttpGet("{token}")]

        public async Task<IActionResult> GetFull(string token)
        {
            if (Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].PermissionId == 9)
            {
                try
                {
                    using (var cx = new BeeHealthyContext())
                    {
                        return Ok(await cx.Pacienseks.ToListAsync());
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.InnerException?.Message);
                }
            }
            else
            {
                return BadRequest("Nincs Jogod hozzá!");
            }
        }




        [HttpPost("{token}")]

        public IActionResult Post(string token, Paciensek paciensadatok)
        {
            if (Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].PermissionId == 9)
            {
                try
                {
                    using (var cx = new BeeHealthyContext())
                    {
                        cx.Pacienseks.Add(paciensadatok);
                        cx.SaveChanges();
                        return Ok("Új páciens adatai rögzítve.");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.InnerException?.Message);
                }
            }
            else
            {
                return BadRequest("Nincs Jogod hozzá!");
            }
        }

        [HttpPut("{token}")]

        public IActionResult Put(string token, Paciensek paciensadatok)
        {
            if (Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].PermissionId == 9)
            {
                try
                {
                    using (var cx = new BeeHealthyContext())
                    {
                        cx.Pacienseks.Update(paciensadatok);
                        cx.SaveChanges();
                        return Ok("A páciens adatai módosítva.");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.InnerException?.Message);
                }
            }
            else
            {
                return BadRequest("Nincs Jogod hozzá!");
            }
        }

        [HttpDelete("{token}, {id}")]

        public IActionResult Delete(string token, int id)
        {
            if (Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].PermissionId == 9)
            {
                try
                {
                    using (var cx = new BeeHealthyContext())
                    {
                        cx.Pacienseks.Remove(new Paciensek { Id = id });
                        cx.SaveChanges();
                        return Ok("A páciens adatai törölve.");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.InnerException?.Message);
                }
            }
            else
            {
                return BadRequest("Nincs Jogod hozzá!");
            }
        }
    }
}
