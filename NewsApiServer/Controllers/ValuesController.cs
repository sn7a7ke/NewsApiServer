using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace NewsApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly INewsService _newsService;
        public ValuesController(INewsService service)
        {
            _newsService = service;
        }

        // GET api/values
        [HttpGet]
        //public ActionResult<IEnumerable<NewsModel>> Get()
        //{
        //    var res = _newsService.GetAll(); // ASYNC ASYNC ASYNC ASYNC ASYNC ASYNC ASYNC ASYNC ASYNC ASYNC ASYNC ASYNC ASYNC ASYNC
        //    return res;
        //}
        public async Task<IEnumerable<NewsModel>> GetAsync()
        {
            var res = await _newsService.GetAllAsync();
            return res;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        //public ActionResult<NewsModel> Get(int id)
        //{
        //    return "value";
        //}
        public async Task<IActionResult> GetAsync(int id) //Task<NewsModel>
        {
            try
            {
                var res = await _newsService.GetAsync(id);
                return Ok(res);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}
        public async Task<NewsModel> PostAsync([FromBody] NewsModel news)
        {
            var res = await _newsService.AddAsync(news);
            return res;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}
        public async Task<IActionResult> PutAsync(int id, [FromBody] NewsModel news)
        {
            try
            {
                var res = await _newsService.UpdateAsync(news);
                return Ok(res);
            }
            catch (EntityNotFoundException)
            {
                return BadRequest();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _newsService.DeleteAsync(id);
                return Ok();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
