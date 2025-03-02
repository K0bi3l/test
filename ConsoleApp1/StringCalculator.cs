using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class StringCalculator
    {
        public int Calculate(string arg)
        {
            if (arg == "")
            {
                return 0;
            }
            List<string> separations = new List<string> { ",","\n"};
            List<String> coeff = new List<string>();
            String[]? coefficients;
            if (arg.StartsWith("//"))
            {
                var strings = arg.Split('\n');

                if (strings[0][2] == '[')
                {
                    int i = 2;
                    char c = strings[0][2];
                    while (c == '[')
                    {
                        String del = "";
                        c = strings[0][++i];

                        while (c != ']')
                        {
                            del += c;
                            c = strings[0][++i];
                        }
                        separations.Add(del);

                        if (i != strings[0].Length - 1)
                        {
                            c = strings[0][++i];
                        }

                    }
                }
                else
                {
                    var delimiter = strings[0][2];

                    separations.Add(delimiter.ToString());
                }
                String s = "";

                foreach (var str in strings[1..strings.Length])
                {
                    s += str;
                    coeff.AddRange(str.Split(separations.ToArray(), StringSplitOptions.None));
                }
                arg = s;
                coefficients = coeff.ToArray();
            }
            else
            {
                coefficients = arg.Split(separations.ToArray(), StringSplitOptions.None);
            }
            List<int> numbers = new List<int>();
            foreach (var number in coefficients)
            {
                bool success = int.TryParse(number, out int negCheckRes);
                if (success && negCheckRes < 0)
                {
                    throw new NotImplementedException();
                }
                if(success && negCheckRes <= 1000)
                {
                    numbers.Add(negCheckRes);
                }
            }

            if (numbers.Count == 0)
            {
                return 0;
            }
            if (numbers.Count == 1)
            {
                return numbers[0];
            }
            
            if(numbers.Count == 3)
            {
                return numbers[0] + numbers[1] + numbers[2];
            }
            if (numbers.Count == 2)
            {
                return numbers[0] + numbers[1];
            }    
            throw new NotImplementedException(arg);
        }
    }
}
