using bee_healthy_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bee_healthy_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GyartoController : ControllerBase
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
                        return Ok(await cx.Gyartos.ToListAsync());
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

        public IActionResult Post(string token, Gyarto gyartoadatok)
        {
            if (Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].PermissionId == 9)
            {
                try
                {
                    using (var cx = new BeeHealthyContext())
                    {
                        cx.Gyartos.Add(gyartoadatok);
                        cx.SaveChanges();
                        return Ok("Új gyártó adatai rögzítve.");
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

        public IActionResult Put(string token, Gyarto gyartoadatok)
        {
            if (Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].PermissionId == 9)
            {
                try
                {
                    using (var cx = new BeeHealthyContext())
                    {
                        cx.Gyartos.Update(gyartoadatok);
                        cx.SaveChanges();
                        return Ok("A gyártó adatai módosítva.");
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
                        cx.Gyartos.Remove(new Gyarto { Id = id });
                        cx.SaveChanges();
                        return Ok("A gyártó adatai törölve.");
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
