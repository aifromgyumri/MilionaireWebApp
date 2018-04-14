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
    [Route("api/UserQuestions")]
    public class UserQuestionsController : Controller
    {
        private readonly Repository.QuestionRepository _questionRepository;
        private readonly Repository.UserRepository _userRepository;
        private readonly Repository.AnsweredQuestionsRepository _answeredQuestionsRepository;
        public UserQuestionsController(RestApiDbContext dbContext)
        {
            _questionRepository = new Repository.QuestionRepository(dbContext);
            _userRepository = new Repository.UserRepository(dbContext);
            _answeredQuestionsRepository = new Repository.AnsweredQuestionsRepository(dbContext);
        }

        [HttpGet]
        public IActionResult GetQuestion()
        {
            if (Request.Headers.ContainsKey("Username"))
            {
                var username = Request.Headers["Username"].FirstOrDefault();
                var userExists = _userRepository.UsernameExists(username);
                if (!userExists)
                {
                    ModelState.AddModelError("doesntExist", "Username doesnt exist");
                    return BadRequest(ModelState);
                }
                var user = _userRepository.GetUserByUsername(username);

                Random random = new Random();
                var questions = _questionRepository.GetUnansweredQuestion(user.Id);

                if (questions.Count() > 0)
                {
                    var index = random.Next(0, questions.Count());
                    var question = questions.ElementAt(index);
                    _answeredQuestionsRepository.Add(new AnsweredQuestions { Question = question, User = user });
                    return Ok(UserQuestionViewModel.ToUserQuestionViewModel(question));
                }
                else
                {
                    ModelState.AddModelError("noQuestions", "No Questions found");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("answer")]
        public IActionResult UserAnswer([FromBody]QuestionAnswerViewModel viewModel)
        {
            var question = _questionRepository.GetById(viewModel.QuestionId);
            if (question==null)
            {
                return NotFound();
            }
            if (viewModel.Answer.Trim()==question.RightAnswer.Trim())
            {
                return Ok(new { Message = "Answer is correct" });
            }
            else
            {
                return Ok(new { Message = "Answer is incorrect" });
            }
        }

        [HttpGet("endGame")]
        public IActionResult EndGame()
        {
            if (Request.Headers.ContainsKey("Username"))
            {
                var username = Request.Headers["Username"].FirstOrDefault();
                var userExists = _userRepository.UsernameExists(username);
                if (!userExists)
                {
                    ModelState.AddModelError("doesntExist", "Username doesnt exist");
                    return BadRequest(ModelState);
                }
                var user = _userRepository.GetUserByUsername(username);
                _answeredQuestionsRepository.DeleteAnsweredQuestions(user.Id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
            }
        }
}