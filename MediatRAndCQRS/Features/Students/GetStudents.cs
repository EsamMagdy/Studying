using MediatR;
using MediatRAndCQRS.Data;
using MediatRAndCQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatRAndCQRS.Features.Students;

public class GetStudents : IEndpointDefinition
{
    public record Query() : IRequest<List<Student>>;

    public class Handler : IRequestHandler<Query, List<Student>>
    {
        private readonly AppDbContext _context;

        public Handler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _context.Students.ToListAsync(cancellationToken);
        }
    }
    public void RegisterEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/students", async (IMediator mediator) =>
        {
            var students = await mediator.Send(new Query());
            return Results.Ok(students);
        });
    }
}
