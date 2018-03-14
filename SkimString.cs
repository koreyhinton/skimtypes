using skimtypes.SkimTokenization;
using System.Collections.Generic;
namespace skimtypes
{
    public static class SkimString
    {
        // Normal case-sensitive skim
        public static bit SkimsTo(this string str, string skimTemplate)
        {
            return SkimStringEval(str, skimTemplate, /*insensitive=*/ 0);
        }

        // Irregular case-insensitive skim
        public static bit iSkimsTo(this string str, string skimTemplate)
        {
            return SkimStringEval(str, skimTemplate, /*insensitive=*/ 1);
        }

        private static bit SkimStringEval(string str, string skimTemplate, bit insensitive)
        {
            bit eval = 0;
            var tokenizer = new Tokenizer(skimTemplate);

            Queue<Token> tokens = new Queue<Token>(3);
            while (tokenizer.GetToken(out Token tok))
                tokens.Enqueue(tok);
            //todo: process token queue
            //todo: parse str and compare to template
            return eval;
        }
    }
}
