using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVRLJDGA.BusinessLogic.DTOs;
using MVRLJDGA.BusinessLogic.UseCases.Books.Commands.CreateBook;
using MVRLJDGA.BusinessLogic.UseCases.Books.Commands.UpdateBook;
using MVRLJDGA.BusinessLogic.UseCases.Books.Queries.GetBooks;
using MVRLJDGA.BusinessLogic.UseCases.Publishers.Queries;
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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var publishers = await _mediator.Send(new GetPublishersQuery());
            ViewBag.PublisherList = new SelectList(publishers, "Id", "PublisherName");
            return View();
        }

      
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookDto bookDto)
        {
            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                var command = new CreateBookCommand(bookDto);
                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

   
            var publishers = await _mediator.Send(new GetPublishersQuery());
            ViewBag.PublisherList = new SelectList(publishers, "Id", "PublisherName");

            return View(bookDto);
        }

        public async Task<IActionResult> Edit(long id)
        {
            var books = await _mediator.Send(new GetBooksQuery());
            var bookDto = books.FirstOrDefault(x => x.Id == id);

            if (bookDto == null) return NotFound();

            return View(bookDto);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BookDto bookDto)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new UpdateBookCommand(bookDto));
                return RedirectToAction(nameof(Index));
            }
            return View(bookDto);
        }
    }
}