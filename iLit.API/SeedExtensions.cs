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
        public static async Task<IHost> SeedAsync(this IHost host)
        {
            using (var scope = host.Services.CreateScope()) {
                var context = scope.ServiceProvider.GetRequiredService<iLitContext>();

                await SeediLitAsync(context);
            }
            return host;
        }

        private static async Task SeediLitAsync(IiLitContext context)
        {
            if (!context.Nodes.Any() || !context.Edges.Any()) {
                var edge1 = new Edge {
                    fromNodeID = 1,
                    toNodeID = 2
                };
                var edge2 = new Edge {
                    fromNodeID = 3,
                    toNodeID = 2
                };
                context.Edges.AddRange(edge1, edge2);

                var node1 = new Node {
                    title = "No Silver Bullet"
                };
                var node2 = new Node {
                    title = "Object Oriented Software Engineering"
                };
                var node3 = new Node {
                    title = "The Hopes and Dreams of Programmers: Null"
                };
                context.Nodes.AddRange(node1, node2, node3);

                await context.SaveChangesAsync();
            }
        }
    }
}
