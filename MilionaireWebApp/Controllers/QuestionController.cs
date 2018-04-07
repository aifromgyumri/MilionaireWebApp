using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilionaireWebApp.Models;
using MilionaireWebApp.ViewModels;

namespace MilionaireWebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Question")]
    public class QuestionController : Controller
    {
        private readonly Repository.QuestionRepository _questionRepository;
        public QuestionController(RestApiDbContext dbContext)
        {
            _questionRepository = new Repository.QuestionRepository(dbContext);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_questionRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var question = _questionRepository.GetById(id);
            if (question==null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpPost]
        public IActionResult Add([FromBody]QuestionViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var question = viewModel.ToModel();
                _questionRepository.Add(question);
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(long id,[FromBody]QuestionViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var oldQuestion = _questionRepository.GetById(id);
                if (oldQuestion==null)
                {
                    return NotFound();
                }
                var question = viewModel.ToModel();
                question.Id = id;
                _questionRepository.Edit(question);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var question = _questionRepository.GetById(id);
            if (question==null)
            {
                return NotFound();
            }
            _questionRepository.Delete(question);
            return Ok();
        }
    }
}