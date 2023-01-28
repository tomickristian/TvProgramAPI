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
    public class EmisijeController : Controller
    {
        private readonly IEmisijeService _service;

        public EmisijeController(IEmisijeService service)
        {
            _service = service;
        }

        [HttpGet("lista")]
        public IActionResult DohvatiEmisije(int TvPostajaId, int ZanrId = 0)
        {
            try
            {
                var result = _service.DohvatiEmisije(TvPostajaId, ZanrId);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest("Podaci nisu ispravni.");
            }
            catch (Exception)
            {
                return BadRequest("Podaci nisu ispravni.");
            }
        }

        [HttpGet("detalji")]
        public IActionResult DohvatiEmisiju(int EmisijaId)
        {
            try
            {
                var result = _service.DohvatiEmisiju(EmisijaId);
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
        public async Task<IActionResult> DodajEmisiju([FromForm] DodajIliUrediEmisijuVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = await _service.DodajEmisiju(model);
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
        public async Task<IActionResult> UrediEmisiju([FromForm] DodajIliUrediEmisijuVM model, int EmisijaId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = await _service.UrediEmisiju(model, EmisijaId);
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
        public async Task<IActionResult> UkloniEmisiju(int EmisijaId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = await _service.UkloniEmisiju(EmisijaId);
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
