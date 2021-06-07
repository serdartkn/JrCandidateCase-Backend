using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreetsController : ControllerBase
    {
        IStreetService _streetService;
        public StreetsController(IStreetService streetService)
        {
            _streetService = streetService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _streetService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _streetService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Street street)
        {
            var result = _streetService.Add(street);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Street street)
        {
            var result = _streetService.Update(street);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Street street)
        {
            var result = _streetService.Delete(street);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}