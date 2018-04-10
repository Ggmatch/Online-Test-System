using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministratorSystem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class ManageStuModelTest
    {
        [TestMethod]
        public void AddStuTest()
        {
            // arrange
            ManageStuRepository model = new ManageStuRepository();
            string pwd = Tools.HashPassword("888888");
            DateTime dateTime = DateTime.Now;
            ordinaryuser user = new ordinaryuser
            {
                IDCard = "422130199612270015",
                PhoneNumber = "15927243293",
                Pwd = pwd,
                RealName = "龚赛",
                RegisterTime = dateTime
            };

            // act
            ordinaryuser result = model.AddStu(user);
            // assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddStuTest1()
        {
            // arrange
            ManageStuRepository model = new ManageStuRepository();
            string pwd = Tools.HashPassword("888888");
            DateTime dateTime = DateTime.Now;
            ordinaryuser user1 = new ordinaryuser
            {
                IDCard = "422130199612270015",
                PhoneNumber = "15927243293",
                Pwd = pwd,
                RealName = "龚赛",
                RegisterTime = dateTime
            };
            ordinaryuser user2 = new ordinaryuser
            {
                IDCard = "422130199612270015",
                PhoneNumber = "15927243293",
                Pwd = pwd,
                RealName = "龚赛",
                RegisterTime = dateTime
            };
            ordinaryuser[] user={ user1,user2};

            // act
            ordinaryuser[] result = model.AddStu(user);
            // assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UpdateStuTest()
        {
            // arrange
            ManageStuRepository model = new ManageStuRepository();
            string pwd = Tools.HashPassword("888888");
            ordinaryuser user = new ordinaryuser
            {
                IDCard = "422130199612270015",
                PhoneNumber = "13409842775",
                Pwd = pwd,
                RealName = "龚泽忠"
            };
            int id = 6;
            // act
            bool result = model.UpdateStu(id,user);
            // assert
            Assert.IsTrue(result);
        }
    }

}
