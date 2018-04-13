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
    public class QuestionBankTest
    {
        [TestMethod]
        public void Get1Test()
        {
            // arrange
            QuestionBankRepository model = new QuestionBankRepository();
            int id = 1;
            // act
            IEnumerable<trueorfalse> result=model.Get1(id);
            // assert
            foreach(var i in result)
            {
                Console.WriteLine(i);
            }
        }
    }
}
