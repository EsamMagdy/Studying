using MediatR;

namespace MediatRAndCQRS.Features.Students.Notifications;

public class LogStudentCreatedHandler : INotificationHandler<StudentCreatedNotification>
{
    private readonly ILogger<LogStudentCreatedHandler> _logger;

    public LogStudentCreatedHandler(ILogger<LogStudentCreatedHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(StudentCreatedNotification notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Student created: {Name}, Age: {Age}",
            notification.Student.Name, notification.Student.Age);

        return Task.CompletedTask;
    }
}
