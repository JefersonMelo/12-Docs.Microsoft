using ContosoPets.Api.Models;
using System.Linq;

namespace ContosoPets.Api.Data
{
    public static class SeedData
    {
        public static void Initialize(ContosoPetsContext context)
        {
            if ( !context.Produtos.Any() )
            {
                context.Produtos.AddRange(
                    new Produto
                    {
                        Id = 0,
                        Nome = "Squeaky Bone",
                        Preco = 20.99m
                    },
                    new Produto
                    {
                        Id = 0,
                        Nome = "Knotted Rope",
                        Preco = 12.99m
                    }
                );

                context.SaveChanges();
            }
        }
    }
}