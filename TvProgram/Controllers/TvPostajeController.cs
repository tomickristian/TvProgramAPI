using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TvProgram.BAL.Interfaces;
using TvProgram.Models;
using TvProgram.Models.ViewModels;

namespace TvProgram.Controllers
{
    [Route("")]
    [Route("[controller]")]
    [ApiController]
    public class TvPostajeController : Controller
    {
        private readonly ITvPostajeService _service;

        public TvPostajeController(ITvPostajeService service)
        {
            _service = service;
        }

        [HttpGet("")]
        [HttpGet("lista")]
        public IActionResult DohvatiTvPostaje()
        {
            try
            {
                var result = _service.DohvatiTvPostaje();
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
        public async Task<IActionResult> DodajTvPostaju([FromForm] DodajIliUrediTvPostajuVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = await _service.DodajTvPostaju(model);
                    if (result)
                    {
                        return Ok(result);
                    }
                    return BadRequest($"Tv-postaja '{model.Naziv}' već postoji.");
                }
                return BadRequest("Podaci nisu ispravni.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Došlo je do greške.");
            }
        }

        [HttpPut("uredi")]
        public async Task<IActionResult> UrediTvPostaju([FromForm] DodajIliUrediTvPostajuVM model, int TvPostajaId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = await _service.UrediTvPostaju(model, TvPostajaId);
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
        public async Task<IActionResult> UkloniTvPostaju(int TvPostajaId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = await _service.UkloniTvPostaju(TvPostajaId);
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
