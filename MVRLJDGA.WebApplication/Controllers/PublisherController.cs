using Mapster;
using Microsoft.AspNetCore.Mvc;
using MVRLJDGA.BusinessLogic.DTOs;
using MVRLJDGA.DataAccess.Interfaces;
using MVRLJDGA.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVRLJDGA.WebApplication.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IEfRepository<Publisher> _publisherRepository;

        public PublisherController(IEfRepository<Publisher> publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task<IActionResult> Index()
        {
            var publishers = await _publisherRepository.ListAsync();
            var model = publishers.Adapt<List<PublisherDto>>();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PublisherDto publisherDto)
        {
            if (ModelState.IsValid)
            {
                var publisher = publisherDto.Adapt<Publisher>();
                await _publisherRepository.AddAsync(publisher);
                return RedirectToAction(nameof(Index));
            }
            return View(publisherDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _publisherRepository.GetByIdAsync(id.Value);
            if (publisher == null)
            {
                return NotFound();
            }

            var publisherDto = publisher.Adapt<PublisherDto>();
            return View(publisherDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PublisherDto publisherDto)
        {
            if (id != publisherDto.Id) 
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var publisher = await _publisherRepository.GetByIdAsync(id);
                if (publisher == null)
                {
                    return NotFound();
                }

                publisherDto.Adapt(publisher);

                await _publisherRepository.UpdateAsync(publisher);
                return RedirectToAction(nameof(Index));
            }

            return View(publisherDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _publisherRepository.GetByIdAsync(id.Value);
            if (publisher == null)
            {
                return NotFound();
            }

            var publisherDto = publisher.Adapt<PublisherDto>();
            return View(publisherDto);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publisher = await _publisherRepository.GetByIdAsync(id);
            if (publisher != null)
            {
                await _publisherRepository.DeleteAsync(publisher);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}