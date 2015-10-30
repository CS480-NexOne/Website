using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NexOneVS;
using NexOneVS.Controllers;
using NexOneVS.Models;
using NexOneVS.ViewModels;


namespace NexOneTest
{
    [TestClass]
    public class ControllerTest
    {
        private string movieID = "135397";

        [Owner("Chan")]
        [TestMethod]
        public void TestMovieView()
        {
            MoviesController mc = new NexOneVS.Controllers.MoviesController();

            ViewResult vr = mc.Title() as ViewResult;

            Assert.IsNotNull(vr);

        }

        [Owner("Chan")]
        [TestMethod]
        public void TestCreditParsing()
        {
            MoviesController mc = new NexOneVS.Controllers.MoviesController();
            Assert.IsNotNull(mc.getCredit(movieID));
        }

        [Owner("Chan")]
        [TestMethod]
        public void TestMovieParsing()
        {
            MoviesController mc = new NexOneVS.Controllers.MoviesController();
            Assert.IsNotNull(mc.getNew());
        }
        
    }
}
