using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Runtime.CompilerServices;
using UserBooKCourseIntegration.Application.Repository;
using UserBooKCourseIntegration.Domain.Models.Concretes;
using UserBooKCourseIntegration.Presentation.Models;

namespace UserBooKCourseIntegration.Presentation.Controllers;

public class BookController(IBookRepository bookRepository,IGenreRepository genreRepository,
    IAuthorRepository authorRepository):Controller
{

    private readonly IBookRepository _bookRepository=bookRepository;
    private readonly IGenreRepository _genreRepository=genreRepository;
    private readonly IAuthorRepository _authorRepository=authorRepository;

    [HttpGet]
    public IActionResult GetBooks()
    {
     

        var bookViewModel = new BookViewModel()
        {
            Books = _bookRepository.GetAll().ToList(),
                     
                       
            Genres= _genreRepository.GetAll().ToList(),
            Authors = _authorRepository.GetAll().ToList(),
            Book=new()
        
        };


        return View(bookViewModel);
    }


}
