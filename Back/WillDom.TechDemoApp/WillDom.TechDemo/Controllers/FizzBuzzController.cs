using Microsoft.AspNetCore.Mvc;
using System;
using WillDom.TechDemo.Common;
using WillDom.TechDemo.Interfaces;
using WillDom.TechDemo.Mdels;

namespace WillDom.TechDemo.Controllers
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
            var wordex = new Wordex();
            var result = wordex.GetWordex(input);
            var requestInfo = new RequestInfo { RequestData = String.Join(",", result) };
            _dbService.Create(requestInfo);
            return Ok(result);
        }
    }
}
