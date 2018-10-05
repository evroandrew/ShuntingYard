using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shunting_Yard.lib;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodAddition()
        {
            string input = "8 + 2";
            double output = 0;
            ShuntingYard s = new ShuntingYard(input, ref output);
            Assert.AreEqual(output, 10);
        }
        [TestMethod]
        public void TestMethodSubtraction()
        {
            string input = "8 - 2";
            double output = 0;
            ShuntingYard s = new ShuntingYard(input, ref output);
            Assert.AreEqual(output, 6);
        }
        [TestMethod]
        public void TestMethodMultiplication()
        {
            string input = "8 * 2";
            double output = 0;
            ShuntingYard s = new ShuntingYard(input, ref output);
            Assert.AreEqual(output, 16);
        }
        [TestMethod]
        public void TestMethodDivision()
        {
            string input = "8 / 2";
            double output = 0;
            ShuntingYard s = new ShuntingYard(input, ref output);
            Assert.AreEqual(output, 4);
        }
        [TestMethod]
        public void TestMethod()
        {
            string input = "2 + 2 * 2 / 2 - 2";
            double output = 0;
            ShuntingYard s = new ShuntingYard(input, ref output);
            Assert.AreEqual(output, 2);
        }
        [TestMethod]
        public void TestMethod_2()
        {
            string input = "( 2 + 2 )";
            double output = 0;
            ShuntingYard s = new ShuntingYard(input, ref output);
            Assert.AreEqual(output, 4);
        }
        [TestMethod]
        public void TestMethod_3()
        {
            string input = "( 2 * 2 )";
            double output = 0;
            ShuntingYard s = new ShuntingYard(input, ref output);
            Assert.AreEqual(output, 4);
        }
        [TestMethod]
        public void TestMethod_4()
        {
            string input = "( 2 / 2 )";
            double output = 0;
            ShuntingYard s = new ShuntingYard(input, ref output);
            Assert.AreEqual(output, 1);
        }
        [TestMethod]
        public void TestMethod_5()
        {
            string input = "( 2 - 2 )";
            double output = 0;
            ShuntingYard s = new ShuntingYard(input, ref output);
            Assert.AreEqual(output, 0);
        }
        [TestMethod]
        public void TestMethod_6()
        {
            string input = "7 - 16";
            double output = 0;
            ShuntingYard s = new ShuntingYard(input, ref output);
            Assert.AreEqual(output, -9);
        }
        [TestMethod]
        public void TestMethod_18()
        {
            string input = "-7 - 16";
            double output = 0;
            ShuntingYard s = new ShuntingYard(input, ref output);
            Assert.AreEqual(output, -23);
        }
        [TestMethod]
        public void TestMethod_7()
        {
            string input = "( 2 + 2 ) * ( 2 - 6 )";
            double output = 0;
            ShuntingYard s = new ShuntingYard(input, ref output);
            Assert.AreEqual(output, -16);
        }
        [TestMethod]
        public void TestMethod_1()
        {
            string input = "( 2 + 2 ) * ( 2 - 6 ) + 7";
            double output = 0;
            ShuntingYard s = new ShuntingYard(input, ref output);
            Assert.AreEqual(output, -9);
        }
    }
}
