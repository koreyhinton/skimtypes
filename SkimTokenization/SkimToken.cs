using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skimtypes.SkimTokenization
{
    public enum TokenType
    {
        ws = 0, // whitespace
        nl = 1, // newline
        uc = 2, // uppercase
        lc = 3, // lowercase
        tab= 4, // tab
        es = 5, // empty string
        eos= 6, // end of string
    }
    public class Token
    {
        public TokenType TokenType { get; set; }
        public char Payload { get; set; }
        public bool Required { get; set; }
    }
}
