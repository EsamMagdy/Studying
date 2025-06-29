using MediatR;
using MediatRAndCQRS.Data;
using MediatRAndCQRS.Features.Students.Notifications;
using MediatRAndCQRS.Models;

namespace MediatRAndCQRS.Features.Students;

public class CreateStudent : IEndpointDefinition
{
    public record Command(string Name, int Age) : IRequest<Student>;

    public class Handler : IRequestHandler<Command, Student>
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;

        public Handler(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Student> Handle(Command request, CancellationToken cancellationToken)
        {
            var student = new Student { Name = request.Name, Age = request.Age };
            _context.Students.Add(student);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new StudentCreatedNotification(student), cancellationToken);

            return student;
        }
    }

    public void RegisterEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost("/students", async (IMediator mediator, Command command) =>
        {
            var student = await mediator.Send(command);
            return Results.Created($"/students/{student.Id}", student);
        });
    }
}
