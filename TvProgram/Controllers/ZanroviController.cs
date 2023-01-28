using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvProgram.BAL.Interfaces;
using TvProgram.Models.ViewModels;

namespace TvProgram.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ZanroviController : Controller
    {
        private readonly IZanroviService _service;

        public ZanroviController(IZanroviService service)
        {
            _service = service;
        }

        [HttpGet("lista")]
        public IActionResult DohvatiZanrove(int TvPostajaId)
        {
            try
            {
                var result = _service.DohvatiZanrove(TvPostajaId);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest("Podaci nisu ispravni.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Došlo je do greške.");
            }
        }

        [HttpPost("dodaj")]
        public async Task<IActionResult> DodajZanr([FromForm] DodajIliUrediZanrVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = await _service.DodajZanr(model);
                    if (result)
                    {
                        return Ok(result);
                    }
                }
                return BadRequest("Podaci nisu ispravni.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Došlo je do greške.");
            }
        }

        [HttpPut("uredi")]
        public async Task<IActionResult> UrediZanr([FromForm] DodajIliUrediZanrVM model, int ZanrId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = await _service.UrediZanr(model, ZanrId);
                    if (result)
                    {
                        return Ok(result);
                    }
                }
                return BadRequest("Podaci nisu ispravni.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Došlo je do greške.");
            }
        }

        [HttpDelete("ukloni")]
        public async Task<IActionResult> UkloniZanr(int ZanrId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = await _service.UkloniZanr(ZanrId);
                    if (result)
                    {
                        return Ok(result);
                    }
                }
                return BadRequest("Podaci nisu ispravni.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Došlo je do greške.");
            }
        }
    }
}
