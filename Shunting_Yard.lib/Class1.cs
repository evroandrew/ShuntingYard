using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shunting_Yard.lib
{
    public class ShuntingYard
    {

        #region operators
        private int op_preced(string c)
        {
            switch (c)
            {
                case "!":
                    return 4;
                case "*":
                case "/":
                case "%":
                    return 3;
                case "+":
                case "-":
                    return 2;
                case "=":
                    return 1;
            }
            return 0;
        }

        private bool op_left_assoc(char c)
        {
            switch (c)
            {
                case '*':
                case '/':
                case '%':
                case '+':
                case '-':
                case '=':
                    return true;
                case '!':
                    return false;
            }
            return false;
        }

        private int op_arg_count(char c)
        {
            switch (c)
            {
                case '*':
                case '/':
                case '%':
                case '+':
                case '-':
                case '=':
                    return 2;
                case '!':
                    return 1;

                default:
                    return (c - 'A');
            }
        }
        #endregion

        #region checks
        private bool is_operator(string c)
        {
            if (c == "+" || c == "-" || c == "/" || c == "*" || c == "!" || c == "%" || c == "=")
                return true;
            return false;
        }
        private bool is_ident(string c)
        {
            if (c[0] >= '0' && c[0] <= '9')
                return true;
            return false;
        }
        #endregion

        public ShuntingYard(string input, ref double output)
        {
            string test = Convert(input);
            Console.WriteLine(test);
            if (test != "0000")
                output = Calc(test);
        }

        private string Convert(string input)
        {
            List<string> inf = new List<string>(100);
            List<string> post = new List<string>(100);
            Stack<string> stack = new Stack<string>(100);
            string[] arr = (input + " $").Split(' ');
            for (int itt = 0; itt < arr.Length; itt++)
                inf.Add(arr[itt]);
            int status = 2;
            int i = 0;
            string first = "";
            while (status == 2)
            {
                if (stack.Count != 0)
                    first = stack.Peek();
                else
                    first = "-1";
                if (is_ident(inf[i]))
                {
                    post.Add(inf[i]);
                    i++;
                }
                if (op_preced(inf[i]) == 2)
                {
                    if (first == "-1" || first == "(") { stack.Push(inf[i]); i++; }
                    else if (is_operator(first)) post.Add(stack.Pop());
                }
                else if (op_preced(inf[i]) == 3)
                {
                    if (first == "-1" || first == "(" || op_preced(first) == 2)
                    { stack.Push(inf[i]); i++; }
                    else if (op_preced(first) == 3) post.Add(stack.Pop());
                }
                else
                    if (inf[i] == "(")
                { stack.Push(inf[i]); i++; }
                else if (inf[i] == ")")
                {
                    if (first == "-1") status = 0;
                    else if (is_operator(first)) post.Add(stack.Pop());
                    else if (first == "(") { stack.Pop(); i++; }
                }
                else if (inf[i] == "$")
                {
                    if (first == "-1") status = 1;
                    else if (is_operator(first)) post.Add(stack.Pop());
                    else if (first == "(") status = 0;
                }
                else if (inf[i][0] == '-')
                {
                    post.Add(inf[i]);
                    i++;
                }
                else status = 0;
            }
            if (status == 1)
            {
                StringBuilder sb = new StringBuilder();
                for (int isb = 0; isb < post.Count; isb++)
                {
                    sb.Append(post[isb] + " ");
                }
                return sb.ToString();
            }
            else return "0000";
        }
        private double Calc(string postf)
        {
            Console.WriteLine(postf);
            List<string> post = new List<string>();
            Stack<double> stack = new Stack<double>();
            string[] arr = postf.Split(' ');
            for (int itt = 0; itt < arr.Length; itt++)
                post.Add(arr[itt]);
            double var_1, var_2;
            for (int i = 0; i < post.Count - 1; i++)
            {
                if (is_ident(post[i]))
                {
                    Console.WriteLine(post[i]);
                    stack.Push(Double.Parse(post[i]));
                }
                else if (post[i] == "+") stack.Push(stack.Pop() + stack.Pop());
                else if (post[i] == "-")
                {
                    var_2 = stack.Pop();
                    var_1 = stack.Pop();
                    stack.Push(var_1 - var_2);
                }
                else if (post[i] == "*") stack.Push(stack.Pop() * stack.Pop());
                else if (post[i] == "/")
                {
                    var_2 = stack.Pop();
                    var_1 = stack.Pop();
                    stack.Push(var_1 / var_2);
                }
                else
                {
                    stack.Push(Double.Parse(post[i]));
                }
            }
            return stack.Pop();
        }
    }
}
