using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zespolonaa;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestujZespolone()
        {
            
            var z1 = new Zespolona(1,2);
            var z2 = new Zespolona(3, 4);
            var Oczekiwana = new Zespolona(4, 6);

            var z3 = Zespolona.DodajZesp(z1, z2);
            Console.WriteLine(z3.Rzeczywista + z3.Urojona);
            Assert.AreEqual(4, z3.Rzeczywista);
            Assert.AreEqual(6, z3.Urojona);
         

            var z4 = new Zespolona(1, 2);
            var z6 = new Zespolona(3, 4);
            var z5 = Zespolona.MnozenieZesp(z4, z6);
            Assert.AreEqual(-5, z5.Rzeczywista);
            Assert.AreEqual(10, z5.Urojona);




        }
    }
}
