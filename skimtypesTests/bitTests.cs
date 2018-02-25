using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using skimtypes;

namespace skimtypesTests
{
    [TestClass]
    public class bitTests
    {
        [TestMethod]
        public void NewBitEvaluatesFalse()
        {
            // Arrange
            bit b = new bit();
            // Act
            bool boolVal = b;
            // Assert
            Assert.IsFalse(boolVal);
        }

        [TestMethod]
        public void FlipBitOnceEvaluatesTrue()
        {
            // Arrange
            bit b = new bit();
            // Act
            b.Flip();
            // Assert
            Assert.IsTrue(b);
        }

        [TestMethod]
        public void BitFlippedEvenNumTimesEvaluatesFalse()
        {
            // Arrange
            bit b = new bit();
            // Act
            for (int i = 0; i < 4; i++)
                b.Flip();
            // Assert
            Assert.IsFalse(b);
        }

        [TestMethod]
        public void BitFlippedOddNumTimesEvaluatesTrue()
        {
            // Arrange
            bit b = new bit();
            // Act
            for (int i = 0; i < 5; i++)
                b.Flip();
            // Assert
            Assert.IsTrue(b);
        }

        [TestMethod]
        public void BitAssigned0EvaluatesFalse()
        {
            // Arrange, Act
            bit b = 0;
            // Assert
            Assert.IsFalse(b);
        }

        [TestMethod]
        public void BitAssigned1EvalutesTrue()
        {
            // Arrange, Act
            bit b = 1;
            // Assert
            Assert.IsTrue(b);
        }

        [TestMethod]
        public void BitAssigned0ThenFlipEvaluatesTrue()
        {
            // Arrange
            bit b = 0;
            // Act
            b.Flip();
            Assert.IsTrue(b);
        }

        [TestMethod]
        public void BitAssigned1ThenFlipEvaluatesFalse()
        {
            // Arrange
            bit b = 1;
            // Act
            b.Flip();
            Assert.IsFalse(b);
        }

        [TestMethod]
        public void BitAssigned0ThenFlippedEvenNumTimesEvaluatesFalse()
        {
            // Arrange
            bit b = 0;
            // Act
            for (int i = 0; i<10; i++)
                b.Flip();
            // Assert
            Assert.IsFalse(b);
        }

        [TestMethod]
        public void BitAssigned0ThenFlippedOddNumTimesEvaluatesTrue()
        {
            // Arrange
            bit b = 0;
            // Act
            for (int i = 0; i<15; i++)
                b.Flip();
            // Assert
            Assert.IsTrue(b);
        }

        [TestMethod]
        public void BitAssigned1ThenFlippedEvenNumTimesEvaluatesTrue()
        {
            // Arrange
            bit b = 1;
            // Act
            for (int i = 0; i<10; i++)
                b.Flip();
            // Assert
            Assert.IsTrue(b);
        }

        [TestMethod]
        public void BitAssigned1ThenFlippedOddNumTimesEvaluatesFalse()
        {
            // Arrange
            bit b = 1;
            // Act
            for (int i = 0; i<15; i++)
                b.Flip();
            // Assert
            Assert.IsFalse(b);
        }

        [TestMethod]
        public void BitAssignedGreaterThan1Throws()
        {
            try
            {
                // Arrange, Act
                bit b = 2;
                throw new Exception("Fail");
            }
            catch(InvalidBitException e)
            {
                // Assert (getting InvalidBitException means it passed)
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void BitAssignedLessThan0Throws()
        {
            try
            {
                // Arrange, Act
                bit b = -1;
                throw new Exception("Fail");
            }
            catch(InvalidBitException e)
            {
                // Assert (getting InvalidBitException means it passed)
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void ConvertFromFalseBoolEvalsFalse()
        {
            // Arrange, Act
            bit b = (false);
            // Assert
            Assert.IsFalse(b);
        }

        [TestMethod]
        public void ConvertFromTrueBoolEvalsTrue()
        {
            // Arrange, Act
            bit b = (true);
            // Assert
            Assert.IsTrue(b);
        }

        [TestMethod]
        public void ConvertFromFalseBoolThenFlipEvalsTrue()
        {
            // Arrange
            bit b = (false);
            // Act
            b.Flip();
            // Assert
            Assert.IsTrue(b);
        }

        [TestMethod]
        public void ConvertFromTrueBoolThenSet0EvalsFalse()
        {
            // Arrange
            bit b = (true);
            // Act
            b = 0;
            // Assert
            Assert.IsFalse(b);
        }

        [TestMethod]
        public void AssignsByValue()
        {
            // Arrange
            bit a = 0;
            bit b = a;
            // Act
            a = 1;
            Assert.IsFalse(b);
        }

        [TestMethod]
        public void BitAssigned1EvalsIf()
        {
            // Arrange
            bit b = 1;
            // Act
            if (b)
                return;//Assert
            else
                throw new Exception("Fail");
        }

        [TestMethod]
        public void BitAssigned0EvalsElse()
        {
            // Arrange
            bit b = 0;
            // Act
            if (b)
                throw new Exception("Fail");
            else
                return;//Assert
        }

        [TestMethod]
        public void BitAssigned1EqualsOpEvalsTrue()
        {
            // Arrange
            bit b = 1;
            // Act, Assert
            Assert.IsTrue(b==1);
        }

        [TestMethod]
        public void BitAssigned0EqualsOpEvalsFalse()
        {
            // Arrange
            bit b = 0;
            // Act, Assert
            Assert.IsFalse(b==1);
        }

        [TestMethod]
        public void BitAssigned1NotEqualsOpEvalsFalse()
        {
            // Arrange
            bit b = 1;
            // Act, Assert
            Assert.IsFalse(b!=1);
        }

        [TestMethod]
        public void BitAssigned0NotEqualsOpEvalsTrue()
        {
            // Arrange
            bit b = 0;
            // Act, Assert
            Assert.IsTrue(b!=1);
        }

        [TestMethod]
        public void Bit0ToString0()
        {
            // Arrange
            bit b = 0;
            // Act
            string val = b.ToString();
            // Assert
            Assert.AreEqual(expected: "0", actual: val);
        }

        [TestMethod]
        public void Bit1ToString1()
        {
            // Arrange
            bit b = 1;
            // Act
            string val = b.ToString();
            // Assert
            Assert.AreEqual(expected: "1", actual: val);
        }

        [TestMethod]
        public void BitTrueEquality()
        {
            // Arrange
            bit a = 1;
            bit b = 1;
            // Act, Assert
            Assert.AreEqual(a, b);
            Assert.IsTrue(a == b);
        }

        [TestMethod]
        public void BitFalseEquality()
        {
            // Arrange
            bit a = new bit();
            bit b = new bit();
            // Act, Assert
            Assert.AreEqual(a, b);
            Assert.IsTrue(a == b);
        }

        [TestMethod]
        public void BitInequality()
        {
            // Arrange
            bit a = new bit();
            bit b = new bit();
            a.Flip();
            a.Flip(); b.Flip();
            // Act, Assert
            Assert.AreNotEqual(a, b);
            Assert.IsTrue(a != b);
            Assert.IsFalse(a == b);
        }
    }
}
