using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVRLJDGA.BusinessLogic.DTOs;
using MVRLJDGA.BusinessLogic.UseCases.Books.Commands.CreateBook;
using MVRLJDGA.BusinessLogic.UseCases.Books.Commands.UpdateBook;
using MVRLJDGA.BusinessLogic.UseCases.Books.Queries.GetBooks;
using MVRLJDGA.BusinessLogic.UseCases.Publishers.Queries;
using MVRLJDGA.BusinessLogic.UseCases.Books.Commands.DeleteBook;
using MVRLJDGA.BusinessLogic.UseCases.Books.Queries.GetBookById;

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

        public async Task<IActionResult> Index(string searchTerm, string genreFilter)
        {
          
            var publishers = await _mediator.Send(new GetPublishersQuery());
            ViewBag.Genres = new SelectList(publishers, "Id", "PublisherName");

        
            ViewData["CurrentFilter"] = searchTerm;

       
            var query = new GetBooksQuery();
            var model = await _mediator.Send(query);

         
            if (!string.IsNullOrEmpty(searchTerm))
            {
                model = model.Where(b => b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var publishers = await _mediator.Send(new GetPublishersQuery());
            ViewBag.PublisherList = new SelectList(publishers, "Id", "PublisherName");
            return View();
        }

        [HttpPost] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookDto bookDto, IFormFile? imageFile)
        {
         
            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
              
                if (imageFile != null && imageFile.Length > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "books");
                    string filePath = Path.Combine(uploadPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    bookDto.ImageUrl = "/images/books/" + fileName;
                }
               
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
      
        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery(id));
            if (book == null) return NotFound();
            return View(book);
        }

       
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _mediator.Send(new DeleteBookCommand(id));
            return RedirectToAction(nameof(Index));
        }
    }
}

