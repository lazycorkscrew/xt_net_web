using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.ClassLibrary
{
    public class MyString : IEnumerable
    {
        private char[] chars;
        public int Length { get; }

        public MyString(string inputString)
        {
            Length = inputString.Length;
            chars = new char[Length];
            
            for (int i = 0; i < Length; i++)
            {
                chars[i] = inputString[i];
            }
        }

        public MyString(char [] inputChars)
        {
            chars = inputChars;
            Length = inputChars.Length;
        }

        public char this[int index]
        {
            get
            {
                return chars[index];
            }
            set
            {
                chars[index] = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return chars.GetEnumerator();
        }

        public char[] ToCharArray()
        {
            return chars;
        }

        public override string ToString()
        {
            return new string(chars);
        }

        public static MyString operator + (MyString str1, MyString str2)
        {
            char[] concated = new char[str1.Length + str2.Length];

            for (int i = 0; i < str1.Length; i++)
            {
                concated[i] = str1[i];
            }

            for (int i = str1.Length; i < concated.Length; i++)
            {
                concated[i] = str2[i - str1.Length];
            }

            return new MyString(concated);
        }

        public static bool operator == (MyString str1, MyString str2)
        {

            if (str1.Length != str2.Length)
            {
                return false;
            }

            for(int i = 0; i < str1.Length; i++)
            {
                if(str1[i] != str2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator !=(MyString str1, MyString str2)
        {
            if (str1.Length != str2.Length)
            {
                return true;
            }

            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    return true;
                }
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            return chars.Equals(obj);
        }

        public override int GetHashCode()
        {
            return chars.GetHashCode();
        }

        public int IndexOf(string s)
        {
            int matchCount = 0;

            try
            {

                for (int i = 0; i < chars.Length; i++)
                {
                    int tempi = i;
                    for (int j = 0; j < s.Length; j++)
                    {
                        if (chars[tempi] == s[j])
                        {

                            matchCount++;
                            tempi++;
                            if (s.Length == matchCount)
                            {
                                return i;
                            }
                        }
                        else
                        {
                            matchCount = 0;
                        }
                    }
                }
            }
            catch(IndexOutOfRangeException)
            {
                return -1;
            }

            return -1;
        }
    }
}
