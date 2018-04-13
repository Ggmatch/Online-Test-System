using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministratorSystem.Models;

namespace UnitTestProject
{
    [TestClass]
    public class TestPaperTest
    {
        [TestMethod]
        public void UpdateByIDTest()
        {
            // arrange
            int id = 1;
            testpaper tp = new testpaper
            {
                TestPaperName = "操作系统"
            };
            ManageTestPaperRepository model = new ManageTestPaperRepository();
            // act
            bool result = model.UpdateByID(id, tp);
            // assert
            Assert.IsTrue(result);
        }
    }
}
