using UserBooKCourseIntegration.Domain.Models.Concretes;

namespace UserBooKCourseIntegration.Presentation.Models;

public class AddUserViewModel
{
    public List<User> Users { get; set; }
    public List<Speciality> Specialities { get; set; }
    public User User { get; set; }

}
