using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Tickets.Services;

namespace Tickets.UnitTests
{
    public class TaskTest
    {
        /// <summary>
        /// I just created 2 simple test because I had some problems with the nuget.
        /// </summary>
        [Fact]
        public void GetWorking()
        {
            var tickService = new Tickets.Services.Controllers.TicketsController();
            var okResult = false;
            try
            {
                var ass = tickService.Get(1);
                okResult = true;
            }
            catch (Exception)
            {
            }

            Assert.True(okResult, "Ok");
        }

        [Fact]
        public void GetAllWorking()
        {
            var tickService = new Tickets.Services.Controllers.TicketsController();
            var okResult = false;
            try
            {
                var ass = tickService.Get(page: 1);
                okResult = true;
            }
            catch (Exception)
            {
            }

            Assert.True(okResult, "Ok");
        }
    }
}
