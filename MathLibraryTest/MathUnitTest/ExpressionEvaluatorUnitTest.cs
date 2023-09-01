using MathLibrary.Evaluator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MathUnitTest
{
	[TestClass]
	public class ExpressionEvaluatorUnitTest
	{
		[TestMethod]
		public void TestExpression1()
		{
			ExpressionEvaluator ev = new ExpressionEvaluator();
			try
			{
				ev.EvaluateExpression("");
			}
			catch (Exception ex)
			{
				StringAssert.Contains(ex.Message, "failed");
			}
		}
		[TestMethod]
		public void TestExpression2()
		{
			ExpressionEvaluator ev = new ExpressionEvaluator();
			double result = ev.EvaluateExpression("5+5-(5*5)/5");
			Assert.AreEqual(result, 5);
		}
		[TestMethod]
		public void TestExpression3()
		{
			ExpressionEvaluator ev = new ExpressionEvaluator();
			double result = ev.EvaluateExpression("       2             +         2");
			Assert.AreEqual(result, 4);
		}
		[TestMethod]
		public void TestExpression4()
		{
			ExpressionEvaluator ev = new ExpressionEvaluator();
			try
			{
				double result = ev.EvaluateExpression("9**9");
			}
			catch (Exception ex)
			{
				StringAssert.Contains(ex.Message, "Binary");
			}
		}
		[TestMethod]
		public void TestExpression5()
		{
			ExpressionEvaluator ev = new ExpressionEvaluator();
			double result = ev.EvaluateExpression("5 + (  +  5)");
			Assert.AreEqual(result, 10);
		}
		[TestMethod]
		public void TestExpression6()
		{
			ExpressionEvaluator ev = new ExpressionEvaluator();
			double result = ev.EvaluateExpression("5+(-5)");
			Assert.AreEqual(result, 0);
		}
		[TestMethod]
		public void TestExpression7()
		{
			ExpressionEvaluator ev = new ExpressionEvaluator();
			double result = ev.EvaluateExpression("5+(log(60))");
			string a = result.ToString().Substring(0, 5);
			string b = Convert.ToString(5 + Math.Log10(60)).Substring(0, 5);
			Assert.AreEqual(a, b);
		}
		[TestMethod]
		public void TestExpression8()
		{
			ExpressionEvaluator ev = new ExpressionEvaluator();
			double result = ev.EvaluateExpression("5+(log(60))exp5");
			string a = result.ToString().Substring(0, 5);
			string b = Convert.ToString(5 + Math.Pow(Math.Log10(60), 5)).Substring(0, 5);
			Assert.AreEqual(a, b);
		}
		[TestMethod]
		public void TestExpression9()
		{
			ExpressionEvaluator ev = new ExpressionEvaluator();

			Assert.ThrowsException<FormatException>(() =>
			{
				double result = ev.EvaluateExpression("(+(-(-(-(3234242.2334)))))");

			});
		}

		[TestMethod]
		public void TestExpression10()
		{
			ExpressionEvaluator ev = new ExpressionEvaluator();
			double result = ev.EvaluateExpression("5min-4");
			string a = result.ToString();
			string b = Convert.ToString(9);
			Assert.AreEqual(a, b);
		}

		[TestMethod]
		public void TestExpression11()
		{
			ExpressionEvaluator ev = new ExpressionEvaluator();
			double result = ev.EvaluateExpression("(-6)-(-6)");
			string a = result.ToString();
			string b = Convert.ToString(0);
			Assert.AreEqual(a, b);
		}
        [TestMethod]
        public void TestExpression12()
        {
            ExpressionEvaluator ev = new ExpressionEvaluator();
            Assert.ThrowsException<DivideByZeroException>(() =>
            {
                double result = ev.EvaluateExpression("3/0");

            });
        }
    }
}
