using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hijo_del_santo.Assets;
using Objects;

namespace hijo_del_santo
{

    class Context
    {
        public string error;
        public Stat stat;
        public int size;

        public string file;

        public Context()
        {
            error = "";
            stat = Stat.None;
            size = 0;
            file = "default.txt";
        }
    }

    interface Expression
    {
        string Text();
        bool Interpret(Context context);
    }

    class StringExpression : Expression
    {
        public string text;

        public StringExpression(string _text)
        {
            text = _text;
        }

        public string Text()
        {
            return text;
        }

        public bool Interpret(Context context)
        {
            switch(text)
            {
                default:
                {
                    return false;
                } break;
                case "strength":
                case "str":
                {
                    context.stat = Stat.Strength;
                } break;
                case "agility":
                case "agi":
                {
                    context.stat = Stat.Agility;
                } break;
                case "intelligence":
                case "int":
                {
                    context.stat = Stat.Intelligence;
                } break;
                case "all":
                {
                    context.stat = Stat.All;
                } break;
            }
            return true;
        }
    }

    class IntExpression : Expression
    {
        public string text;

        public IntExpression(string _text)
        {
            text = _text;
        }

        public string Text()
        {
            return text;
        }

        public bool Interpret(Context context)
        {
            if(!Int32.TryParse(text, out context.size))
            {
                context.size = 0;
                return false;
            }
            return true;
        }
    }

    class FileStringExpression : Expression
    {
        public string text;

        public FileStringExpression(string _text)
        {
            text = _text;
        }

        public string Text()
        {
            return text;
        }

        public bool Interpret(Context context)
        {
            context.file = text;
            return true;
        }
    }

    class SetExpression : Expression
    {
        Expression L;
        Expression R;

        public SetExpression(Expression _L, Expression _R)
        {
            L = _L;
            R = _R;
        }

        public string Text()
        {
            return "";
        }

        public bool Interpret(Context context)
        {
            if(!L.Interpret(context))
            {
                context.error = "Could not interpret \"" + L.Text() + "\" when setting stat.";
                return false;
            }

            if(!R.Interpret(context))
            {
                context.error = "Could not interpret \"" + R.Text() + "\" when setting stat.";
                return false;
            }
            return true;
        }
    }

    class AddExpression : Expression
    {
        Expression L;
        Expression R;

        public AddExpression(Expression _L, Expression _R)
        {
            L = _L;
            R = _R;
        }

        public string Text()
        {
            return "";
        }

        public bool Interpret(Context context)
        {
            if(!L.Interpret(context))
            {
                context.error = "Could not interpret \"" + L.Text() + "\" when adding stat.";
                return false;
            }

            if(!R.Interpret(context))
            {
                context.error = "Could not interpret \"" + R.Text() + "\" when adding stat.";
                return false;
            }
            return true;
        }
    }

    class SubExpression : Expression
    {
        Expression L;
        Expression R;

        public SubExpression(Expression _L, Expression _R)
        {
            L = _L;
            R = _R;
        }

        public string Text()
        {
            return "";
        }

        public bool Interpret(Context context)
        {
            if(!L.Interpret(context))
            {
                context.error = "Could not interpret \"" + L.Text() + "\" when subtracting stat.";
                return false;
            }

            if(!R.Interpret(context))
            {
                context.error = "Could not interpret \"" + R.Text() + "\" when subtracting stat.";
                return false;
            }
            return true;
        }
    }

    class LogExpression : Expression
    {
        Expression File;

        public LogExpression(Expression _File)
        {
            File = _File;
        }

        public string Text()
        {
            return "";
        }

        public bool Interpret(Context context)
        {
            if(!File.Interpret(context))
            {
                context.error = "Could not interpret \"" + File.Text() + "\" when logging console.";
                return false;
            }
            return true;
        }
    }

    class ConsoleInterpreter
    {
        public Expression expression;
        public Context context;

        public ConsoleInterpreter()
        {
        }

        public bool SetCharacterStat(Context context)
        {
            var adapt = new HttpAdapter();
            var cheatResult = adapt.SetCheatStat(Screen.sessionId, context.stat, context.size).Result;
            if(cheatResult.ResponseCode != HttpStatusCode.OK)
            {
                context.error = "\nFailed to set character stat \"" + context.stat.ToString() + "\" to value \"" + context.size.ToString() +"\"";
                return false;
            }

            context.error = "\nCharacter stat \"" + context.stat.ToString() + "\" set to \"" + context.size + "\"";
            Screen.character = cheatResult.Result;
            return true;
        }

        public bool DiffCharacterStat(Context context, bool addition)
        {
            var adapt = new HttpAdapter();
            int initial_size = 0;
            switch(context.stat)
            {
                case Stat.Strength:
                {
                    initial_size = Screen.character.Strength;
                } break;
                case Stat.Agility:
                {
                    initial_size = Screen.character.Agility;
                } break;
                case Stat.Intelligence:
                {
                    initial_size = Screen.character.Intelligence;
                } break;
            }

            if(!addition)
            {
                context.size = -context.size;
            }

            var cheatResult = adapt.SetCheatStat(Screen.sessionId, context.stat, initial_size + context.size).Result;

            if(cheatResult.ResponseCode != HttpStatusCode.OK)
            {
                context.error = "\nFailed to set character stat \"" + context.stat.ToString() + "\" to value \"" + context.size.ToString() +"\"";
                return false;
            }
            
            context.error = "\nCharacter stat \"" + context.stat.ToString() + "\" set to \"" + (initial_size + context.size) + "\"";
            Screen.character = cheatResult.Result;
            return true;
        }

        public bool LogToFile(Context context, string text)
        {
            string directory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string file = directory + "\\" + context.file;
            context.error = "Console log written to file \"" + file + "\"";
            System.IO.File.WriteAllText(file, text);
            return true;
        }

        public void Interpret(ConsoleOutputField output, string text)
        {
            string[] words = text.Split(' ');

            if(words.Length < 1)
            {
                return;
            }

            context = new Context();

            switch(words[0])
            {
                default:
                {
                    output.AddText("\nUndefined command \"" + text + "\"");
                } break;
                case "set":
                {
                    if(words.Length != 3)
                    {
                        output.AddText("\nset command usage: set STAT AMOUNT");
                        break;
                    }

                    Expression stat = new StringExpression(words[1]);
                    Expression size = new IntExpression(words[2]);
                    expression = new SetExpression(stat, size);

                    if(expression.Interpret(context))
                    {
                        SetCharacterStat(context);
                    }
                    output.AddText("\n" + context.error);
                } break;
                case "add":
                {
                    if(words.Length != 3)
                    {
                        output.AddText("\nadd command usage: add STAT AMOUNT");
                        break;
                    }

                    Expression stat = new StringExpression(words[1]);
                    Expression size = new IntExpression(words[2]);
                    expression = new AddExpression(stat, size);

                    if(expression.Interpret(context))
                    {
                        DiffCharacterStat(context, true);
                    }
                    output.AddText("\n" + context.error);
                } break;
                case "sub":
                {
                    if(words.Length != 3)
                    {
                        output.AddText("\nsub command usage: sub STAT AMOUNT");
                        break;
                    }

                    Expression stat = new StringExpression(words[1]);
                    Expression size = new IntExpression(words[2]);
                    expression = new SubExpression(stat, size);

                    if(expression.Interpret(context))
                    {
                        DiffCharacterStat(context, false);
                    }
                    output.AddText("\n" + context.error);
                } break;
                case "log":
                {
                    if(words.Length != 2)
                    {
                        output.AddText("\nlog command usage: sub FILE");
                        break;
                    }

                    Expression file = new StringExpression(words[1]);
                    expression = new LogExpression(file);

                    if(expression.Interpret(context))
                    {
                        LogToFile(context, output.text);
                    }
                    output.AddText("\n" + context.error);
                } break;
                case "cls":
                {
                    output.UpdateText("");
                } break;
                case "exit":
                case "quit":
                {
                    Application.Exit();
                } break;
            }
        }
    }
}
