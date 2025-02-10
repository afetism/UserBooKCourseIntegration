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
    public IActionResult GetUsers(int page=1,int pageSize=8)
    {
       
        var getAllUser = _userRepository.GetAll();
        var getAllSpeciality= _specialityRepository.GetAll().ToList();
        var totalUsers=getAllUser.Count();
        var paginatedUsers = getAllUser
                               .Skip((page - 1) * pageSize) 
                               .Take(pageSize) 
                               .ToList();

        var newAddUserViewModel = new AddUserViewModel()
        {
            Users=paginatedUsers,
            Specialities=getAllSpeciality,
            User= new(),
            CurrentPage = page,
            TotalPages = (int)Math.Ceiling((double)totalUsers / pageSize)
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
