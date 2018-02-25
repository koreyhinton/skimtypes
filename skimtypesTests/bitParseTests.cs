using skimtypes;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace skimtypesTests
{
    [TestClass]
    public class bitParseTests
    {
        [TestMethod]
        public void Single0DigitStringParsesAsZero()
        {
            string zero = "0";
            bit b = bit.Parse(zero);
            AssertZero(b);
        }

        [TestMethod]
        public void Single1DigitStringParsesAsOne()
        {
            string one = "1";
            bit b = bit.Parse(one);
            AssertOne(b);
        }

        [TestMethod]
        public void LeadWsSingleDig0ParsesAsZero()
        {
            string zero = "     \t\n    0";
            bit b = bit.Parse(zero);
            AssertZero(b);
        }

        [TestMethod]
        public void LeadWsSingleDig1ParsesAsOne()
        {
            string one = "     \t\n    1";
            bit b = bit.Parse(one);
            AssertOne(b);
        }

        [TestMethod]
        public void SurroundWsSingleDig0ParsesAsZero()
        {
            string zero = "     \t\n    0     \t\n    ";
            bit b = bit.Parse(zero);
            AssertZero(b);
        }

        [TestMethod]
        public void SurroundWsSingleDig1ParsesAsOne()
        {
            string one = "     \t\n    1     \t\n    ";
            bit b = bit.Parse(one);
            AssertOne(b);
        }

        [TestMethod]
        public void SurroundWsAllZerosParsesAsZero()
        {
            string zero = " 0000 ";
            bit b = bit.Parse(zero);
            AssertZero(b);
        }

        [TestMethod]
        public void SurroundWsLeadingZerosEndsWith1ParsesAsOne()
        {
            string one = " 0001 ";
            bit b = bit.Parse(one);
            AssertOne(b);
        }

        [TestMethod]
        public void ZeroAfterOneThrows()
        {
            string invalid = " 0100 ";
            try
            {
                bit b = bit.Parse(invalid);
                throw new Exception("Fail");
            }
            catch(FormatException fe)
            {
                return;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void TrueCaseInsensitiveParsesAsOne()
        {
            string trueStr = " tRuE ";
            bit b = bit.Parse(trueStr);
            AssertOne(b);
        }

        [TestMethod]
        public void FalseCaseInsensitiveParsesAsZero()
        {
            string falseStr = " False ";
            bit b = bit.Parse(falseStr);
            AssertZero(b);
        }

        [TestMethod]
        public void ArgumentNullThrows()
        {
            try
            {
                bit.Parse(null);
                throw new Exception("Fail");
            }
            catch (ArgumentNullException argNullExc)
            {
                return;//PASS
            }
            catch (Exception e)
            {
                throw e;//FAIL
            }
        }

        // TryParse Tests:

        [TestMethod]
        public void TryParseValidReturnsTrue()
        {
            bit outBit1, outBit2, outBit3, outBit4, outBit5, outBit6;
            bit valid1 = bit.TryParse(" 0001 ", out outBit1);
            bit valid2 = bit.TryParse(" 0000 ", out outBit2);
            bit valid3 = bit.TryParse("True", out outBit3);
            bit valid4 = bit.TryParse("False", out outBit4);
            bit valid5 = bit.TryParse("1", out outBit5);
            bit valid6 = bit.TryParse("0", out outBit6);
            AssertOne(valid1);
            AssertOne(valid2);
            AssertOne(valid3);
            AssertOne(valid4);
            AssertOne(valid6);
        }

        [TestMethod]
        public void TryParseInvalidReturnsFalse()
        {
            bit outBit1, outBit2, outBit3, outBit4, outBit5, outBit6;
            bit inValid1 = bit.TryParse(" 0010 ", out outBit1);
            bit inValid2 = bit.TryParse(" 0f00 ", out outBit2);
            bit inValid3 = bit.TryParse("TrueBlue", out outBit3);
            bit inValid4 = bit.TryParse(null, out outBit4);
            bit inValid5 = bit.TryParse("18", out outBit5);
            bit inValid6 = bit.TryParse("30", out outBit6);
            AssertZero(inValid1);
            AssertZero(inValid2);
            AssertZero(inValid3);
            AssertZero(inValid4);
            AssertZero(inValid6);
        }

        [TestMethod]
        public void TryParseValidOutputsCorrectOutBit()
        {
            bit outBit1, outBit2, outBit3, outBit4, outBit5, outBit6;
            bit.TryParse(" 0001 ", out outBit1);
            bit.TryParse(" 0000 ", out outBit2);
            bit.TryParse("True", out outBit3);
            bit.TryParse("False", out outBit4);
            bit.TryParse("1", out outBit5);
            bit.TryParse("0", out outBit6);

            AssertOne(outBit1);
            AssertZero(outBit2);
            AssertOne(outBit3);
            AssertZero(outBit4);
            AssertOne(outBit5);
            AssertZero(outBit6);
        }

        private void AssertZero(bit b)
        {
            Assert.IsFalse(b);
            Assert.IsTrue(b==0);
            Assert.AreEqual(0, b);
            Assert.IsFalse(b==1);
            Assert.IsTrue(new bit().Equals(b));
        }
        private void AssertOne(bit b)
        {
            Assert.IsTrue(b);
            Assert.IsFalse(b==0);
            Assert.AreEqual(1, b);
            Assert.IsTrue(b==1);
            bit cmpBit = 1;
            Assert.IsTrue(cmpBit.Equals(b));
        }
    }
}
