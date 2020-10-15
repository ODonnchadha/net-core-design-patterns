using Pattern.Domain.Specification;
using Pattern.Domain.Specification.Filters;
using Pattern.Domain.Specification.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace Domain.NUnitTest
{
    public class DomainSpecificationShould
    {
        private Product apple = new Product("Apple", Color.Green, Size.Medium);
        private Product house = new Product("House", Color.Blue, Size.Large);
        private Product tree = new Product("Tree", Color.Green, Size.Large);

        private Product[] products;
        private ProductFilter productFilter;
        private List<Product> filteredProducts;

        [SetUp()]
        public void Setup()
        {
            products = new Product[] { apple, house, tree };
            productFilter = new ProductFilter { };
            filteredProducts = new List<Product>();
        }

        [Test()]
        public void FilterByColor()
        {
            foreach(var product in productFilter.Filter(
                products, new ColorSpecification(Color.Green)))
            {
                filteredProducts.Add(product);
            }

            Assert.Contains(apple, filteredProducts);
            Assert.Contains(tree, filteredProducts);
            Assert.AreEqual(2, filteredProducts.Count);
        }

        [Test()]
        public void FilterBySize()
        {
            foreach (var product in productFilter.Filter(
                products, new SizeSpecification(Size.Large)))
            {
                filteredProducts.Add(product);
            }

            Assert.Contains(house, filteredProducts);
            Assert.Contains(tree, filteredProducts);
            Assert.AreEqual(2, filteredProducts.Count);
        }

        [Test()]
        public void FilterByColorAndSize()
        {
            foreach (var product in productFilter.Filter(
                products, new AndSpecification<Product>(
                    new ColorSpecification(Color.Green),
                    new SizeSpecification(Size.Large))))
            {
                filteredProducts.Add(product);
            }

            Assert.Contains(tree, filteredProducts);
            Assert.AreEqual(1, filteredProducts.Count);
        }
    }
}
