using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using NSwag.Generation.AspNetCore;

namespace ElasticsearchTest.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddOpenApi(this IServiceCollection services)
        {
            services
                .AddOpenApiDocument(
                    options => InitializeOpenApiDocumentOptions(options, "v1"))
                .AddOpenApiDocument(
                    options => InitializeOpenApiDocumentOptions(options, "v2"));

        }

        public static void AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(
                options =>
                {
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.ReportApiVersions = true;
                    options.ApiVersionReader = new UrlSegmentApiVersionReader();
                });
            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstitutionFormat = "VVV";
                    options.SubstituteApiVersionInUrl = true;
                    options.ApiVersionParameterSource = new UrlSegmentApiVersionReader();
                });
        }

        private static void InitializeOpenApiDocumentOptions(AspNetCoreOpenApiDocumentGeneratorSettings options, string version)
        {
            options.DocumentName = version;
            options.Title = $"Elastic demo API {version}";
            options.ApiGroupNames = new[] { version };

            options.Description = "Elastic demo API";
            options.IgnoreObsoleteProperties = true;
        }

        public static void AddDiContainer(this IServiceCollection services)
        {
            
        }
    }
}
