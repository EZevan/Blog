using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Evans.Blog.Swagger
{
    /// <summary>
    /// The filter of swagger document tags
    /// </summary>
    public class SwaggerDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var tags = new List<OpenApiTag>
            {
                new OpenApiTag
                {
                    Name = "HelloAbp",
                    Description = "Hello Abp corresponding service",
                    ExternalDocs = new OpenApiExternalDocs {Description = "This is a test Controller"}
                },
                new OpenApiTag
                {
                    Name = "Post",
                    Description = "Post corresponding service",
                    ExternalDocs = new OpenApiExternalDocs{Description = "Inclusion: posts/categories/tags/frient links"}
                },
                new OpenApiTag
                {
                    Name = "Category",
                    Description = "Category corresponding service",
                    ExternalDocs = new OpenApiExternalDocs{Description = "Shows the all of categories"}
                },
                new OpenApiTag
                {
                    Name = "Tag",
                    Description = "Tag corresponding service",
                    ExternalDocs = new OpenApiExternalDocs{Description = "Show the details of tags"}
                },
                new OpenApiTag
                {
                    Name = "PostTag",
                    Description = "Post tag corresponding service",
                    ExternalDocs = new OpenApiExternalDocs{Description = "Shows the post tag of post"}
                },
                new OpenApiTag
                {
                    Name = "FriendLink",
                    Description = "Friend-link corresponding service",
                    ExternalDocs = new OpenApiExternalDocs{Description = "Shows the friend-links of post"}
                }
            };
            
            swaggerDoc.Tags = tags.OrderBy(x => x.Name).ToList();
        }
    }
}