using OnionCamp.Application.Abstractions;
using OnionCamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCamp.Persistance.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()

            => new()
            {
                new() {Id = Guid.NewGuid(), Name="Bardak", Price=4, Stock=56 },
                new() {Id = Guid.NewGuid(), Name="Sürahi", Price=25, Stock=9 },
                new() {Id = Guid.NewGuid(), Name="Borcam", Price=15, Stock=12 },
                new() {Id = Guid.NewGuid(), Name="Tabak", Price=10, Stock=50 },
                new() {Id = Guid.NewGuid(), Name="Kepçe", Price=5, Stock=25 }
            };

    }
}
