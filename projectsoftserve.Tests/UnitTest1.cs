using System.Collections.Generic;
using System.Linq;
using Xunit;
using projectsoftserve;

namespace projectsoftserve.Tests
{
    public class JewelryTests
    {
        [Fact]
        public void CalculateTotalSum_ShouldReturnCorrectValue()
        {
            var shop = new JewelryShop
            {
                Address = "Test St",
                Items = new List<JewelryItem>
                {
                    new JewelryItem { Name = "Ring", Price = 200 },
                    new JewelryItem { Name = "Chain", Price = 350 }
                }
            };

            double actualSum = shop.Items.Sum(x => x.Price);

            Assert.Equal(550, actualSum);
        }
    }
}