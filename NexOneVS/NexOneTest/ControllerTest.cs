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
        [TestMethod]
        public void TestMethod1()
        {
            MoviesController mc = new NexOneVS.Controllers.MoviesController();

            ViewResult vr = mc.Title() as ViewResult;

            Assert.IsNotNull(vr);

        }
    }
}
