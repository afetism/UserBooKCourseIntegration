using Microsoft.AspNetCore.Mvc;
using UserBooKCourseIntegration.Application.BusinessService;
using UserBooKCourseIntegration.Application.Repository;
using UserBooKCourseIntegration.Domain.Models.Concretes;
using UserBooKCourseIntegration.Presentation.Models;

namespace UserBooKCourseIntegration.Presentation.Controllers;

public class CourseController(ICourseRepository courseRepository,IYouTubeService youTubeService) : Controller
{
    private readonly ICourseRepository _courseRepository= courseRepository;
    private readonly IYouTubeService _youTubeService= youTubeService;

    [HttpGet]
    public IActionResult GetCourses()
    {


        var cources = new CourseViewModel() { Courses =_courseRepository.GetAll().ToList() };
        return View(cources);
    }
}
