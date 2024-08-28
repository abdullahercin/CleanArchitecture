using NSwag;

namespace CleanArchitecture.WebApi.Modules;

public static class NSwagDependencyInjection
{
    public static void AddCustomOpenApiDocument(this IServiceCollection services)
    {
        services.AddOpenApiDocument(document =>
        {
            document.Title = "Clean Architecture API";
            document.Version = "v1";
            document.Description = "A simple example ASP.NET Core Web API";
            //document.AddSecurity("JWT", [], new OpenApiSecurityScheme
            //{
            //    Type = OpenApiSecuritySchemeType.ApiKey,
            //    Name = "Authorization",
            //    In = OpenApiSecurityApiKeyLocation.Header,
            //    Description = "Type into the textbox: Bearer {your JWT token}."
            //});
            //document.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
        });
    }
}