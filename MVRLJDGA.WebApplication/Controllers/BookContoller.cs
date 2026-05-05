using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using MVRLJDGA.BusinessLogic.DTOs;
using MVRLJDGA.BusinessLogic.UseCases.Books.Commands.CreateBook;
using MVRLJDGA.BusinessLogic.UseCases.Books.Queries.GetBooks;
using System.Threading.Tasks;

namespace MVRLJDGA.WebApplication.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetBooksQuery();
            var model = await _mediator.Send(query);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookDto bookDto)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateBookCommand(bookDto);
                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(bookDto);
        }
    }
}