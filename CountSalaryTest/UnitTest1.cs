using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CountSalaryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValueCorrect()
        {
            List<double> list = new List<double>() {250,250 };
            double ex =130.5;
            double res = BarberKarpNaz.ClassHelper.CountSalary.Salary(list);
            Assert.AreEqual(res,ex);
        }
        [TestMethod]
        public void ValueZero()
        {
            List<double> list = new List<double>() { };
            double ex =0;
            double res = BarberKarpNaz.ClassHelper.CountSalary.Salary(list);
            Assert.AreEqual(res,ex);
        }
        
    }
}
