using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hextasy.Framework;
using Xunit;

namespace Hextasy.Test
{
    public class RNGTest
    {
        [Fact]
        public void ShouldGiveMe1()
        {
            var numbers = Enumerable.Repeat(1, 100).Select(p => RNG.Next(0, 1));
            Assert.True(numbers.Any(p => p == 1));
        }
    }
}
