using bee_healthy_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities.Encoders;
using System.Collections.Generic;
using System.Linq;

namespace bee_healthy_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptekDTOController : ControllerBase
    {

        [HttpGet("{token}")]

        public ActionResult<List<ReceptDTO>> GetReceptek(string token)
        {
            if (Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].PermissionId == 9)
            {
                using (var cx = new BeeHealthyContext())
                {
                    try
                    {
                        var receptek = cx.Recepteks
                                .Include(r => r.Paciens)
                                .Include(r => r.Gyogyszer)
                                .Include(r => r.Orvos)
                                .Select(r => new ReceptDTO
                                {
                                    Id = r.Id,
                                    PaciensNev = r.Paciens.Nev,
                                    GyogyszerNev = r.Gyogyszer.GyogyszerNev,
                                    OrvosNev = r.Orvos.Nev,
                                    KezelesiIdopont = r.KezelesiIdopont,
                                    KezelesKezdete = r.KezelesKezdete,
                                    KezelesVege = r.KezelesVege,
                                    Adagolas = r.Adagolas
                                }).ToList();
                        return Ok(receptek);
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(400, ex.InnerException?.Message);

                    }
                }
            }
            else
            {
                return BadRequest("Nincs Jogod hozzá!");
            }

        }
    }
}