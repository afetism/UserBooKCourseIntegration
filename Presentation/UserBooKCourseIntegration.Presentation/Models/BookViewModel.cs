using UserBooKCourseIntegration.Domain.Models.Concretes;

namespace UserBooKCourseIntegration.Presentation.Models;

public class BookViewModel
{
    public List<Book> Books { get; set; }
    public List<Genre>Genres { get; set; }
    public List<Author> Authors { get; set; }
    public Book Book { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }


}
