using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelim
{
    public class TuringStrip
    {
        private List<char[]> chars = new List<char[]>();
        private int index = 0;
        public TuringStrip(String input)
        {
            chars = new List<char[]>();
            for(int i = 0; i <= input.Length; i++)
            {
                if (i % 10 == 0)
                {
                    addToChars();
                    chars[0][0] = '_';
                    i++;
                }
                chars[i / 10][i % 10] = input.ToCharArray()[i-1];
            }
        }
        public TuringStrip(TuringStrip turingStrip)
        {
            chars = new List<char[]>();
            chars.AddRange(turingStrip.chars.ToArray());
        }

        public char getChar()
        {
            return chars[index / 10][index % 10];
        }
        public void setChar(char c)
        {
            chars[index / 10][index % 10] = c;
        }

        public void right()
        {
            index++;
            if(index > chars.Count * 10)
            {
                addToChars();
            }
        }

        public void left()
        {
            index--;
            if(index < 0)
            {
                index = 0;
            }
        }

        private void addToChars()
        {
            char[] cs = new char[10];
            for (int i = 0; i < 10; i++)
            {
                cs[i] = '<';
            }
            chars.Add(cs);
        }

        public string getAsString()
        {
            string output = "";
            for(int i = 0; i < chars.Count * 10; i++)
            {
                output += chars[i / 10][i % 10];
            }
            return output;
        }
    }
}
