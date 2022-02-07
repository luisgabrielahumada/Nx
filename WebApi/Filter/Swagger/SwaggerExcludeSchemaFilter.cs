
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace WebApi.Filter
{
    public class SwaggerExcludeSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            foreach (var item in context.SchemaRepository.Schemas.Keys.Where(r => r.Contains("Extensions") || r.Contains("Filter") || r.Contains("Activator") || r.Contains("Attribute") || r.Contains("State")))
            {
                if (!item.Contains("Dto"))
                    context.SchemaRepository.Schemas.Remove(item);
            }
        }
    }
}
