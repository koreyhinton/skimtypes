using System;
using System.Diagnostics;

namespace skimtypes
{
    public class InvalidBitException : Exception
    {
        public InvalidBitException(string msg):base(msg){}
    }
    //TODO: Parse, TryParse
    [DebuggerDisplay("{_intVal}")]
    public struct bit
    {
        private int _intVal;//starts as 0, and can only ever be 0 or 1

        // bit b = 1
        public static implicit operator bit(int v)
        {
            bit b = new bit();
            b._intVal = v;
            /*
                1 Right-shift will chop off the right-most bit.
                Only cases where v=1 or v=0 will the result end up being 0

                v=1
                    1 >> 1
                           0001
                        => 000|1
                        => 000
                v=0
                    0 >> 1
                           0000
                        => 000|0
                        => 000
                v>1
                    ..1. >> 1
                           ..1.
                        => ..1|.
                        => ..1
                v<1
                    1... >> 1
                           1...
                        => 1..|.
                        => 1..
            */
            if (0x0 == v >> 0x1)//if(v==0||v==1)
                return b;
            throw new InvalidBitException("bit type can only be a 0 or 1, value given was " + v);
        }

        // bit b = (boolExp);
        public static implicit operator bit(bool v)
        {
            bit b = new bit();
            if (v)
                b.Flip();
            return b;
        }

        // bool myBool = myBit;
        public static implicit operator bool(bit b)
        {
            return (b._intVal == 1) ? true : false;
        }

        // (trueBit ...boolExp)
        public static bool operator true(bit b)
        {
            return b._intVal == 1;
        }

        // (falseBit ...boolExp)
        public static bool operator false(bit b)
        {
            return b._intVal == 0;
        }

        // In-place flip
        public void Flip()
        {
            /*
                _intVal can only be a 0 or 1 at this point in the code
                v=1
                    0001 ^ 1
                            0001
                        XOR 0001
                        =>  0000
                v=0
                    0000 ^ 1
                            0000
                        XOR 0001
                        =>  0001
            */
            _intVal ^= 0x1;//_intVal = (_intVal + 1) % 2;
        }

        // b1 == b2
        public static bool operator ==(bit b1, bit b2)
        {
            return b1._intVal == b2._intVal;
        }

        // b1 != b2
        public static bool operator !=(bit b1, bit b2)
        {
            return b1._intVal != b2._intVal;
        }

        public override string ToString()
        {
            return (this) ? "1" : "0";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is bit val))
                return false;
            return this._intVal == val._intVal;
        }

        public bool Equals(bit obj)
        {
            return obj._intVal == this._intVal;
        }

        // Parse Methods:

        public static bit Parse(string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            bit parsed;
            if (TryParse(str, out parsed))
                return parsed;
            throw new FormatException("Unable to parse as bit, string given: " + str);
        }

        public static bit TryParse(string str, out bit outBit)
        {
            outBit = default(bit);
            if (str == null)
                return 0;

            int strLen = str.Length;

            // skip leading whitespace
            int i = 0;
            for (; i<strLen; i++)
            {
                if (!char.IsWhiteSpace(str[i]))
                    break;
            }

            strLen -= (i);

            const string trueStr = "true";
            const string falseStr = "false";
            int trueLen = trueStr.Length;
            int falseLen = falseStr.Length;

            if (strLen >= trueLen && str.Substring(i, trueLen).ToLower() == trueStr)
            {
                i += trueLen;
                strLen -= trueLen;
                string remainingStr = str.Substring(i, strLen);
                if (string.IsNullOrWhiteSpace(remainingStr))
                {
                    outBit = 1;
                    return 1;
                }
                return 0;
            }

            if (strLen >= falseLen && str.Substring(i, falseLen).ToLower() == falseStr)
            {
                i += falseLen;
                strLen -= falseLen;
                string remainingStr = str.Substring(i, strLen);
                if (string.IsNullOrWhiteSpace(remainingStr))
                {
                    outBit = 0;
                    return 1;
                }
                return 0;
            }

            // at this point only whitespace, 0, or 1 is allowed but 1 has to be the last number
            strLen = str.Length;//reset it back to the full length of the string to satisfy for condition
            int lastNumber = 0;
            bool found0 = false;
            for (; i < strLen; i++)
            {
                char c = str[i];
                switch (c)
                {
                    case '0':
                    {
                        if (lastNumber==1)
                            return 0;//0 can't come after 1
                        found0 = true;
                        break;
                    }
                    case '1':
                    {
                        lastNumber = 1;
                        break;
                    }
                    default:
                    {
                        if (!char.IsWhiteSpace(c))
                            return 0;// any non-whitespace character that isn't a 1 or a 0 fails
                        break;
                    }
                }
            }
            // making it here assumes one of these happened:
            // (1) all whitespace characters => fail
            // (2) all 0s except for whitespace => pass
            // (3) last is a 1 (except for whitespace) with optional preceding 0s => pass
            if (!found0 && lastNumber !=1)
                return 0;//only whitespace fails
            outBit = lastNumber==1;
            return 1;
        }

        //NOT REALLY SUPPORTED OPERATION:
        public override int GetHashCode()
        {
            return _intVal;
        }
    }
}
