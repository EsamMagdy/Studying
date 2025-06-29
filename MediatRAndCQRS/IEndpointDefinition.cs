namespace MediatRAndCQRS;

public interface IEndpointDefinition
{
    void RegisterEndpoints(IEndpointRouteBuilder app);
}
