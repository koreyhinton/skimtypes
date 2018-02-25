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

        //NOT REALLY SUPPORTED OPERATION:
        public override int GetHashCode()
        {
            return _intVal;
        }
    }
}
