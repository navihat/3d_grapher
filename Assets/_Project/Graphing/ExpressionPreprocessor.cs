using System;
using System.Collections.Generic;
using System.Globalization;

namespace Grapher.Graphing
{
    /// <summary>
    /// Chuyển biểu thức kiểu sách giáo khoa (2x, sin x, x², -2^2, |x|, √x, 0,5x) sang cú pháp NCalc 1.3.8.
    /// Chuỗi kết quả luôn đóng ngoặc đầy đủ nên thứ tự phép tính do lớp này quyết định, không phụ thuộc NCalc
    /// (trong NCalc 1.3.8, ^ là XOR nên luỹ thừa được đổi thành Pow).
    /// Lỗi cú pháp ném FormatException với thông báo tiếng Việt.
    /// </summary>
    /// <remarks>
    /// Thứ tự ưu tiên, từ thấp đến cao:
    ///   + -  →  * / và nhân ngầm (2x, x(x+1))  →  dấu âm  →  ^ (kết hợp phải)  →  ², ³  →  số, biến, hàm, ( ), | |
    /// Vì dấu âm thấp hơn ^ nên -2^2 = -(2^2) = -4.
    /// Hàm viết không có ngoặc nhận đối số là tích ngầm phía sau, dừng trước hàm kế tiếp:
    ///   sin 2x = sin(2x), sin x cos x = sin(x)·cos(x), sin x + 1 = sin(x) + 1, sin²x = (sin x)².
    /// </remarks>
    internal static class ExpressionPreprocessor
    {
        public const string Variable = "x";

        private const string SupportedNames = "biến x và các hàm sin, cos, tan, cot, sqrt, ln, log, exp, abs";

        private static readonly Dictionary<string, Func<string, string>> Functions =
            new Dictionary<string, Func<string, string>>
            {
                { "sin", a => "Sin(" + a + ")" },
                { "cos", a => "Cos(" + a + ")" },
                { "tan", a => "Tan(" + a + ")" },
                { "tg", a => "Tan(" + a + ")" },
                { "cot", a => "(1.0 / Tan(" + a + "))" },
                { "cotg", a => "(1.0 / Tan(" + a + "))" },
                { "sqrt", a => "Sqrt(" + a + ")" },
                { "ln", a => "Log(" + a + ", " + Literal(Math.E) + ")" },
                { "log", a => "Log10(" + a + ")" },
                { "exp", a => "Exp(" + a + ")" },
                // Abs của NCalc 1.3.8 trả về decimal, trộn với double sẽ lỗi, nên dùng if.
                { "abs", a => "if(" + a + " < 0.0, (-" + a + "), " + a + ")" },
            };

        private static readonly Dictionary<string, double> Constants = new Dictionary<string, double>
        {
            { "pi", Math.PI },
            { "e", Math.E },
        };

        public static string ToNCalc(string input, ICollection<string> parameterNames)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw Error("Chưa nhập biểu thức.");
            }

            var parameters = new HashSet<string>();
            if (parameterNames != null)
            {
                foreach (var name in parameterNames)
                {
                    parameters.Add(name.ToLowerInvariant());
                }
            }

            var parser = new Parser(Tokenize(input, parameters), parameters);
            return parser.ParseAll();
        }

        private static FormatException Error(string message)
        {
            return new FormatException(message);
        }

        private static string Literal(double value)
        {
            return value.ToString("0.0###############", CultureInfo.InvariantCulture);
        }

        private static string Pow(string baseValue, string exponent)
        {
            return "Pow(" + baseValue + ", " + exponent + ")";
        }

        // ---------- Tách token ----------

        private enum TokenKind
        {
            Number,
            Name,
            Operator,
            LeftParen,
            RightParen,
            Pipe,
            Root,
            Superscript,
            End
        }

        private struct Token
        {
            public TokenKind Kind;
            public string Text;

            public Token(TokenKind kind, string text)
            {
                Kind = kind;
                Text = text;
            }
        }

        private static List<Token> Tokenize(string input, HashSet<string> parameters)
        {
            var tokens = new List<Token>();
            var i = 0;
            while (i < input.Length)
            {
                var c = input[i];
                if (char.IsWhiteSpace(c))
                {
                    i++;
                }
                else if (char.IsDigit(c) || (c == '.' && i + 1 < input.Length && char.IsDigit(input[i + 1])))
                {
                    i = ReadNumber(input, i, tokens);
                }
                else if (c == 'π')
                {
                    tokens.Add(new Token(TokenKind.Name, "pi"));
                    i++;
                }
                else if (char.IsLetter(c))
                {
                    var start = i;
                    while (i < input.Length && char.IsLetter(input[i]) && input[i] != 'π')
                    {
                        i++;
                    }
                    SplitNames(input.Substring(start, i - start), parameters, tokens);
                }
                else
                {
                    tokens.Add(SymbolToken(c));
                    i++;
                }
            }
            tokens.Add(new Token(TokenKind.End, ""));
            return tokens;
        }

        // Đọc số; dấu phẩy giữa hai chữ số là dấu thập phân kiểu Việt Nam (0,5 = 0.5).
        private static int ReadNumber(string input, int start, List<Token> tokens)
        {
            var i = start;
            while (i < input.Length)
            {
                var c = input[i];
                var isSeparator = (c == '.' || c == ',') && i + 1 < input.Length && char.IsDigit(input[i + 1]);
                if (!char.IsDigit(c) && !isSeparator)
                {
                    break;
                }
                i++;
            }

            var text = input.Substring(start, i - start);
            var normalized = text.Replace(',', '.');
            if (normalized.IndexOf('.') != normalized.LastIndexOf('.'))
            {
                throw Error("Số không hợp lệ: '" + text + "'.");
            }

            // Giữ nguyên chữ người dùng gõ để thông báo lỗi hiện đúng; đổi sang dạng NCalc khi sinh biểu thức.
            tokens.Add(new Token(TokenKind.Number, text));
            return i;
        }

        // Tách chuỗi chữ liền nhau thành các tên đã biết, ưu tiên tên dài nhất: "sinx" → sin, x; "2xe" → x, e.
        private static void SplitNames(string run, HashSet<string> parameters, List<Token> tokens)
        {
            var lower = run.ToLowerInvariant();
            var pos = 0;
            while (pos < lower.Length)
            {
                var matched = 0;
                for (var length = lower.Length - pos; length > 0; length--)
                {
                    var candidate = lower.Substring(pos, length);
                    if (candidate == Variable || Functions.ContainsKey(candidate)
                        || Constants.ContainsKey(candidate) || parameters.Contains(candidate))
                    {
                        tokens.Add(new Token(TokenKind.Name, candidate));
                        matched = length;
                        break;
                    }
                }

                if (matched == 0)
                {
                    throw Error("Không nhận ra '" + run + "'. Chỉ dùng " + SupportedNames + ".");
                }
                pos += matched;
            }
        }

        private static Token SymbolToken(char c)
        {
            switch (c)
            {
                case '+':
                    return new Token(TokenKind.Operator, "+");
                case '-':
                case '−':
                case '–':
                    return new Token(TokenKind.Operator, "-");
                case '*':
                case '×':
                case '·':
                case '⋅':
                    return new Token(TokenKind.Operator, "*");
                case '/':
                case '÷':
                    return new Token(TokenKind.Operator, "/");
                case '^':
                    return new Token(TokenKind.Operator, "^");
                case '(':
                    return new Token(TokenKind.LeftParen, "(");
                case ')':
                    return new Token(TokenKind.RightParen, ")");
                case '|':
                    return new Token(TokenKind.Pipe, "|");
                case '√':
                    return new Token(TokenKind.Root, "√");
                case '²':
                    return new Token(TokenKind.Superscript, "2");
                case '³':
                    return new Token(TokenKind.Superscript, "3");
                case '=':
                    throw Error("Chỉ nhập vế phải của hàm số, ví dụ x^2 + 1 thay vì y = x^2 + 1.");
                default:
                    throw Error("Ký tự không hợp lệ: '" + c + "'.");
            }
        }

        // ---------- Phân tích cú pháp (đệ quy xuống) ----------

        private sealed class Parser
        {
            private readonly List<Token> _tokens;
            private readonly HashSet<string> _parameters;
            private int _pos;
            private int _absDepth;

            public Parser(List<Token> tokens, HashSet<string> parameters)
            {
                _tokens = tokens;
                _parameters = parameters;
            }

            private Token Current => _tokens[_pos];

            public string ParseAll()
            {
                var result = ParseExpression();
                switch (Current.Kind)
                {
                    case TokenKind.End:
                        return result;
                    case TokenKind.RightParen:
                        throw Error("Thừa dấu ngoặc đóng ')'.");
                    case TokenKind.Pipe:
                        throw Error("Thừa dấu '|'.");
                    case TokenKind.Number:
                        throw Error("Thiếu phép toán trước số '" + Current.Text + "'.");
                    default:
                        throw Error("Không hiểu phần '" + Current.Text + "'.");
                }
            }

            // expression := term (('+' | '-') term)*
            private string ParseExpression()
            {
                var left = ParseTerm();
                while (IsOperator("+") || IsOperator("-"))
                {
                    var op = Next().Text;
                    left = "(" + left + " " + op + " " + ParseTerm() + ")";
                }
                return left;
            }

            // term := unary (('*' | '/') unary | power)*   — vế sau "power" là nhân ngầm: 2x, x(x+1), 2sin x
            private string ParseTerm()
            {
                var left = ParseUnary();
                while (true)
                {
                    if (IsOperator("*") || IsOperator("/"))
                    {
                        var op = Next().Text;
                        left = "(" + left + " " + op + " " + ParseUnary() + ")";
                    }
                    else if (StartsImplicitFactor())
                    {
                        left = "(" + left + " * " + ParsePower() + ")";
                    }
                    else
                    {
                        return left;
                    }
                }
            }

            // unary := ('-' | '+') unary | power
            private string ParseUnary()
            {
                if (IsOperator("-"))
                {
                    Next();
                    return "(-" + ParseUnary() + ")";
                }
                if (IsOperator("+"))
                {
                    Next();
                    return ParseUnary();
                }
                return ParsePower();
            }

            // power := postfix ('^' unary)?   — kết hợp phải: 2^3^2 = 2^(3^2); cho phép x^-1
            private string ParsePower()
            {
                var baseValue = ParsePostfix();
                if (IsOperator("^"))
                {
                    Next();
                    return Pow(baseValue, ParseUnary());
                }
                return baseValue;
            }

            // postfix := primary ('²' | '³')*
            private string ParsePostfix()
            {
                var value = ParsePrimary();
                while (Current.Kind == TokenKind.Superscript)
                {
                    value = Pow(value, Literal(double.Parse(Next().Text, CultureInfo.InvariantCulture)));
                }
                return value;
            }

            private string ParsePrimary()
            {
                var token = Current;
                switch (token.Kind)
                {
                    case TokenKind.Number:
                        Next();
                        var value = double.Parse(token.Text.Replace(',', '.'), NumberStyles.Float,
                            CultureInfo.InvariantCulture);
                        return Literal(value);

                    case TokenKind.LeftParen:
                        Next();
                        var inner = ParseExpression();
                        Expect(TokenKind.RightParen, "Thiếu dấu ngoặc đóng ')'.");
                        return "(" + inner + ")";

                    case TokenKind.Pipe:
                        Next();
                        _absDepth++;
                        var absInner = ParseExpression();
                        Expect(TokenKind.Pipe, "Thiếu dấu '|' đóng giá trị tuyệt đối.");
                        _absDepth--;
                        return Functions["abs"](absInner);

                    case TokenKind.Root:
                        Next();
                        return ParseFunction("sqrt");

                    case TokenKind.Name:
                        Next();
                        if (token.Text == Variable || _parameters.Contains(token.Text))
                        {
                            return token.Text;
                        }
                        if (Constants.TryGetValue(token.Text, out var constant))
                        {
                            return Literal(constant);
                        }
                        return ParseFunction(token.Text);

                    case TokenKind.End:
                        throw _pos > 0 && _tokens[_pos - 1].Kind == TokenKind.Operator
                            ? Error("Thiếu số hoặc biến sau '" + _tokens[_pos - 1].Text + "'.")
                            : Error("Biểu thức chưa hoàn chỉnh.");

                    case TokenKind.RightParen:
                        throw Error("Thiếu số hoặc biến trước dấu ')'.");

                    default:
                        throw Error("Thiếu số hoặc biến trước '" + token.Text + "'.");
                }
            }

            // Tên hàm đã được đọc. Có ngoặc: sin(x). Không ngoặc: sin 2x, sin x^2, sin -x. Có thể có mũ: sin²x.
            private string ParseFunction(string name)
            {
                var exponents = new List<string>();
                while (Current.Kind == TokenKind.Superscript)
                {
                    exponents.Add(Literal(double.Parse(Next().Text, CultureInfo.InvariantCulture)));
                }

                string argument;
                if (Current.Kind == TokenKind.LeftParen)
                {
                    argument = ParsePrimary();
                }
                else if (Current.Kind == TokenKind.End || Current.Kind == TokenKind.RightParen
                         || Current.Kind == TokenKind.Pipe && _absDepth > 0
                         || Current.Kind == TokenKind.Operator && Current.Text != "-")
                {
                    throw Error("Hàm " + name + " thiếu đối số.");
                }
                else
                {
                    argument = ParseBareArgument();
                }

                var result = Functions[name](argument);
                foreach (var exponent in exponents)
                {
                    result = Pow(result, exponent);
                }
                return result;
            }

            private string ParseBareArgument()
            {
                if (IsOperator("-"))
                {
                    Next();
                    return "(-" + ParseBareArgument() + ")";
                }

                var argument = ParsePower();
                while (StartsImplicitFactor() && !StartsFunction())
                {
                    argument = "(" + argument + " * " + ParsePower() + ")";
                }
                return argument;
            }

            // Không nhân ngầm trước số ("x 2" là lỗi) và trước '|' khi đang ở trong | | (đó là dấu đóng).
            private bool StartsImplicitFactor()
            {
                switch (Current.Kind)
                {
                    case TokenKind.Name:
                    case TokenKind.LeftParen:
                    case TokenKind.Root:
                        return true;
                    case TokenKind.Pipe:
                        return _absDepth == 0;
                    default:
                        return false;
                }
            }

            private bool StartsFunction()
            {
                return Current.Kind == TokenKind.Root
                       || Current.Kind == TokenKind.Name && Functions.ContainsKey(Current.Text);
            }

            private bool IsOperator(string op)
            {
                return Current.Kind == TokenKind.Operator && Current.Text == op;
            }

            private Token Next()
            {
                return _tokens[_pos++];
            }

            private void Expect(TokenKind kind, string message)
            {
                if (Current.Kind != kind)
                {
                    throw Error(message);
                }
                Next();
            }
        }
    }
}
