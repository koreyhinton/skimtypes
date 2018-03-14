using System;
namespace skimtypes.SkimTokenization
{
    public class Tokenizer
    {
        private readonly string _template;
        private readonly int _i;
        private readonly int _len;
        private Token _lastToken;
        public Tokenizer(string template)
        {
            _template = template;
            _i = 0;
            _len = template.Length;
            _lastToken = null;
        }
        // Returns 1 if there are more tokens else 0
        public bit GetToken(out Token token)
        {
            if (_lastToken != null && _lastToken.TokenType == TokenType.eos)
            {
                token = null;
                return 0;
            }
            throw new NotImplementedException();//todo: set token based on what exists at _i index of _template
            return 1;
        }
    }
}
