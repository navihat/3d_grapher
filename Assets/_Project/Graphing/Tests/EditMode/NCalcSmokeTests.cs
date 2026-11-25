using System;
using NCalc;
using NUnit.Framework;

namespace Grapher.Graphing.Tests
{
    // S2-08: kiểm tra NCalc.dll (1.3.8) được Unity nạp và gọi được.
    public class NCalcSmokeTests
    {
        [Test]
        public void Evaluate_BuiltInFunctions_ReturnsNumber()
        {
            var expression = new Expression("Sin(0) + Sqrt(4)");

            Assert.AreEqual(2.0, Convert.ToDouble(expression.Evaluate()), 1e-9);
        }

        [Test]
        public void Evaluate_WithParameterAndIgnoreCase_UsesParameterValue()
        {
            var expression = new Expression("pow(x, 2) + sqrt(x)", EvaluateOptions.IgnoreCase);
            expression.Parameters["x"] = 4.0;

            Assert.AreEqual(18.0, Convert.ToDouble(expression.Evaluate()), 1e-9);
        }

        [Test]
        public void HasErrors_IncompleteExpression_ReturnsTrue()
        {
            var expression = new Expression("2 *");

            Assert.IsTrue(expression.HasErrors());
        }
    }
}
