using System.Reflection;

namespace MediatRAndCQRS.Extensions;

public static class EndpointDefinitionExtensions
{
    public static void RegisterEndpointDefinitions(this IEndpointRouteBuilder app)
    {
        var definitions = Assembly.GetExecutingAssembly()
            .DefinedTypes
            .Where(t => typeof(IEndpointDefinition).IsAssignableFrom(t) && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IEndpointDefinition>();

        foreach (var def in definitions)
        {
            def.RegisterEndpoints(app);
        }
    }
}
