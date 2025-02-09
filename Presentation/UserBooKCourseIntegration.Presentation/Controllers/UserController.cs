using Microsoft.AspNetCore.Mvc;
using UserBooKCourseIntegration.Application.Repository;
using UserBooKCourseIntegration.Domain.Models.Concretes;
using UserBooKCourseIntegration.Presentation.Models;

namespace UserBooKCourseIntegration.Presentation.Controllers;

public class UserController(IUserRepository userRepository,ISpecialityRepository specialityRepository) : Controller
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ISpecialityRepository _specialityRepository = specialityRepository;
    
    [HttpGet]
    public IActionResult GetUsers()
    {
       
        var getAllUser = _userRepository.GetAll().ToList();
        var getAllSpeciality= _specialityRepository.GetAll().ToList();
        var newAddUserViewModel = new AddUserViewModel()
        {
            Users=getAllUser,
            Specialities=getAllSpeciality,
            User= new()
        };
        
        return View(newAddUserViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await _userRepository.RemoveAsync(id);
        return RedirectToAction("GetUsers");
    }

    [HttpPost]
    public async Task<IActionResult> EditUser(User user)
    {
        await _userRepository.UpdateAsync(user);
        return RedirectToAction("GetUsers");
    }

    [HttpPost] 
    public async Task<IActionResult> AddUser(User User)
    {
        await _userRepository.AddAsync(User);
        return RedirectToAction("GetUsers");
    }



}
