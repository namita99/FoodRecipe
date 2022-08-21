using System;
using System.Collections.Generic;
using System.Text;

using Xunit;
using Xunit.Abstractions;
using Moq;
using Microsoft.Extensions.Logging;
using AspFoodProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace AspFood.xUnitTestProject
{
    public partial class CategoriesApiTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public CategoriesApiTests(
            ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
    }
}
