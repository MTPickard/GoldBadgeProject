using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02_UnitTest
{
    [TestClass]
    public class ClaimsTest
    {
        



        [TestMethod]
        public void TestMethod1()
        {
            ClaimsClass claim = new ClaimsClass();
            ClaimsRepository _repoTest = new ClaimsRepository();

            bool success = _repoTest.AddClaim(claim);

            Assert.IsTrue(success);
        }

    }
}
