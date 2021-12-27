using Microsoft.AspNetCore.Mvc;
using System;
using FizzBuzzQ.TechDemo.Common;
using FizzBuzzQ.TechDemo.Interfaces;
using FizzBuzzQ.TechDemo.Models;

namespace FizzBuzzQ.TechDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : ControllerBase
    {
        private readonly IDataService _dbService;

        public FizzBuzzController(IDataService dbService)
        {
           _dbService = dbService;
        }


        [HttpGet]
        public IActionResult FizzBuzzGet(int input)
        {
            if (input <= 0) return BadRequest("Debe Especificar un valor a procesar.");
            var wordex = new Wordex();
            var result = wordex.GetWordex(input);
            var requestInfo = new RequestInfo { RequestData = String.Join(",", result) };
            _dbService.Create(requestInfo);
            return Ok(result);
        }
    }
}
