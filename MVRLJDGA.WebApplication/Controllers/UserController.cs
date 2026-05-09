using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVRLJDGA.BusinessLogic.DTOs;
using MVRLJDGA.DataAccess.Interfaces;
using MVRLJDGA.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVRLJDGA.WebApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IEfRepository<User> _userRepository;
        private readonly IEfRepository<Role> _roleRepository;

        public UserController(IEfRepository<User> userRepository, IEfRepository<Role> roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

       
        public async Task<IActionResult> Index()
        {
          
            var users = await _userRepository.ListAsync();

        
            var model = users.Adapt<List<UserDto>>();
            return View(model);
        }

     
        public async Task<IActionResult> Create()
        {
            var roles = await _roleRepository.ListAsync();
            ViewBag.Roles = new SelectList(roles, "Id", "Title");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                var user = userDto.Adapt<User>();
                await _userRepository.AddAsync(user);
                return RedirectToAction(nameof(Index));
            }

            var roles = await _roleRepository.ListAsync();
            ViewBag.Roles = new SelectList(roles, "Id", "Title", userDto.RoleId);
            return View(userDto);
        }
      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userRepository.GetByIdAsync(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            var userDto = user.Adapt<UserDto>();

            var roles = await _roleRepository.ListAsync();
            ViewBag.Roles = new SelectList(roles, "Id", "Title", userDto.RoleId);

            return View(userDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserDto userDto)
        {
            if (id != userDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var user = userDto.Adapt<User>();
                await _userRepository.UpdateAsync(user);
                return RedirectToAction(nameof(Index));
            }

            var roles = await _roleRepository.ListAsync();
            ViewBag.Roles = new SelectList(roles, "Id", "Title", userDto.RoleId);
            return View(userDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           
            var user = await _userRepository.GetByIdAsync(id.Value);
            if (user == null)
            {
                return NotFound();
            }

           
            var userDto = user.Adapt<UserDto>();
            return View(userDto);
        }

       
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
               
                await _userRepository.DeleteAsync(user);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}