using MediatR;
using MediatRAndCQRS.Models;

namespace MediatRAndCQRS.Features.Students.Notifications;

public class StudentCreatedNotification : INotification
{
    public Student Student { get; }

    public StudentCreatedNotification(Student student)
    {
        Student = student;
    }
}
