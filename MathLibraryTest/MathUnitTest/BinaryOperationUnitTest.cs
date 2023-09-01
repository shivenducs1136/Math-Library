using MathLibrary.BinaryOperations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MathUnitTest
{



	[TestClass]
	public class BinaryOperationUnitTest
	{

		[TestMethod]
		public void TestAddOperation1()
		{
			AddOperation addOpp = new AddOperation(1);
			Assert.AreEqual(addOpp.Evaluate(new List<double> { -9999, -9999 }), -19998);
		}
		[TestMethod]
		public void TestAddOperation2()
		{
			AddOperation addOpp = new AddOperation(1);
			Assert.AreEqual(addOpp.Evaluate(new List<double> { -9999, 9999 }), 0);
		}
		[TestMethod]
		public void TestAddOperation3()
		{
			AddOperation addOpp = new AddOperation(1);
			Assert.AreEqual(addOpp.Evaluate(new List<double> { 9999, 9999 }), 19998);
		}
		[TestMethod]
		public void TestAddOperation4()
		{
			AddOperation addOpp = new AddOperation(1);
			Assert.AreEqual(addOpp.Evaluate(new List<double> { 9999, 99999999999 }), 99999999999 + 9999);
		}
		[TestMethod]
		public void TestSubtractOperation1()
		{
			SubtractOperation subOpp = new SubtractOperation(1);
			Assert.AreEqual(subOpp.Evaluate(new List<double> { -9999, -9999 }), 0);
		}
		[TestMethod]
		public void TestSubtractOperation2()
		{
			SubtractOperation subOpp = new SubtractOperation(1);
			Assert.AreEqual(subOpp.Evaluate(new List<double> { 9999, -9999 }), 19998);
		}
		[TestMethod]
		public void TestSubtractOperation3()
		{
			SubtractOperation subOpp = new SubtractOperation(1);
			Assert.AreEqual(subOpp.Evaluate(new List<double> { -9999, -99999999999999 }), -9999 + 99999999999999);
		}
		[TestMethod]
		public void TestSubtractOperation4()
		{
			SubtractOperation subOpp = new SubtractOperation(1);
			Assert.AreEqual(subOpp.Evaluate(new List<double> { 0, 0 }), 0);
		}
		[TestMethod]
		public void TestDivideOperation1()
		{
			DivideOperation divOpp = new DivideOperation(1);
			Assert.ThrowsException<DivideByZeroException>(() => divOpp.Evaluate(new List<double> { 0, 0 }));
		}
		[TestMethod]
		public void TestDivideOperation2()
		{
			DivideOperation divOpp = new DivideOperation(1);
			double ans = divOpp.Evaluate(new List<double> { 4, -2 });
			Assert.AreEqual(ans, -2);
		}
		[TestMethod]
		public void TestDivideOperation3()
		{
			DivideOperation divOpp = new DivideOperation(1);
			double ans = divOpp.Evaluate(new List<double> { -2, -2 });
			Assert.AreEqual(ans, Convert.ToDouble(1));
		}
		[TestMethod]
		public void TestDivideOperation4()
		{
			DivideOperation divOpp = new DivideOperation(1);
			double ans = divOpp.Evaluate(new List<double> { -4, 2 });
			Assert.AreEqual(ans, -2);
		}
		[TestMethod]
		public void TestDivideOperation5()
		{
			DivideOperation divOpp = new DivideOperation(1);
			double ans = divOpp.Evaluate(new List<double> { 2, 2 });
			Assert.AreEqual(ans, Convert.ToDouble(1));
		}

		[TestMethod]
		public void TestProductOperation1()
		{
			ProductOperation prodOpp = new ProductOperation(1);
			double ans = prodOpp.Evaluate(new List<double> { 2, 2 });
			Assert.AreEqual(ans, 4);
		}
		[TestMethod]
		public void TestProductOperation2()
		{
			ProductOperation prodOpp = new ProductOperation(1);
			double ans = prodOpp.Evaluate(new List<double> { -2, -2 });
			Assert.AreEqual(ans, 4);
		}
		[TestMethod]
		public void TestPercentageOperation2()
		{
			PercentageOperation prodOpp = new PercentageOperation(1);
			double ans = prodOpp.Evaluate(new List<double> { 30, 100 });
			Assert.AreEqual(ans, 30);
		}
	}
}
