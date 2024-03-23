using System.Reflection;

namespace BatchInsert.Example.MinimalAPI.Helpers.EndpointRouteHandler;

public static class EndpointRouteBuilderExtensions
{
    public static void MapEndpoints(
        this IEndpointRouteBuilder app,
        Assembly assembly)
    {
        _ = assembly ?? throw new ArgumentNullException(nameof(assembly));

        var endpointRouteHandlerInterfaceType = typeof(IEndpointRouteHandler);
        var endpointRouteHandlerTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && !t.IsGenericType
            && t.GetConstructor(Type.EmptyTypes) != null
            && endpointRouteHandlerInterfaceType.IsAssignableFrom(t));

        foreach (var endpointRouteHandlerType in endpointRouteHandlerTypes)
        {
            var instantiatedType = (IEndpointRouteHandler)Activator.CreateInstance(endpointRouteHandlerType)!;
            instantiatedType.MapEndpoints(app);
        }
    }
}
