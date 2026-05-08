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
    }
}