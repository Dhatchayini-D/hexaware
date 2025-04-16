using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionAssignment.Entities;

namespace CollectionAssignment.Services
{
    public class ProductSearchService
    {
        private List<Product> products;

        public ProductSearchService(List<Product> productList)
        {
            products = productList;
        }

        public List<Product> SearchByName(string name)
        {
            var results = products.Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();

            if (results.Count == 0)
                throw new Exception("No products found matching the name.");

            return results;
        }

        public List<Product> SearchByCategory(string category)
        {
            var results = products.Where(p => p.Category.ToLower() == category.ToLower()).ToList();

            if (results.Count == 0)
                throw new Exception("No products found in this category.");

            return results;
        }

        public List<Product> SortByPrice(bool ascending = true)
        {
            return ascending
                ? products.OrderBy(p => p.Price).ToList()
                : products.OrderByDescending(p => p.Price).ToList();
        }

        public List<Product> SortByName()
        {
            return products.OrderBy(p => p.Name).ToList();
        }
    }
}

