using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using iLit.Infrastructure;
using iLit.Core;

namespace iLit.API
{
    public static class SeedExtensions
    {
        public static IHost Seed(this IHost host) //IHost is a reference to where our program is hosted
        {
            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<iLitContext>();

                SeediLit(context);//Seeding the db
            }
            return host;
        }

        private static void SeediLit(IiLitContext context)
        {
            /*var edge1 = new Edge
            {
                fromNodeID = 1,
                toNodeID = 2
            };
            var edge2 = new Edge
            {
                fromNodeID = 3,
                toNodeID = 2
            };
            context.Edges.AddRange(edge1, edge2);

            var node1 = new Node
            {
                title = "Article1"
            };
            var node2 = new Node
            {
                title = "Article2"
            };
            var node3 = new Node
            {
                title = "Article3"
            };
            context.Nodes.AddRange(node1, node2, node3);

            context.SaveChanges();*/
        }
    }
}
