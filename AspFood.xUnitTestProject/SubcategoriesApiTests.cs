using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace AspFood.xUnitTestProject
{
    public partial class SubcategoriesApiTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public SubcategoriesApiTests(
            ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
    }
}
