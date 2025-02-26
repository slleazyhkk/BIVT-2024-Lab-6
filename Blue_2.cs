using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Blue_2
    {
        public struct Participant
        {
            //polya
            private string _name;
            private string _surname;
            private int[,] _marks;

            //svoystva
            public string Name => _name;
            public string Surname => _surname;
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int[,] copyMarks = new int[2,5];
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            copyMarks[i, j] = _marks[i, j];
                        }
                    }
                    return copyMarks;
                }
            }
            public int TotalScore
            {
                get
                {
                    if (_marks==null) return 0;
                    int s = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            s += _marks[i, j];
                        }
                    }
                    return s;
                }
            }
            //construct
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[2,5];
            }
            //method
            public void Jump(int[] result)
            {
                if (result == null || _marks == null) return;
                for (int i = 0; i < 2; i++)
                {
                    if (_marks[i, 0] == 0)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            _marks[i, j] = result[j];
                        }
                        return;
                    }
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length==0) return;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                        {
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }
            //vyvod

            public void Print()
            {
                Console.WriteLine(_name + " " + _surname);
                for (int i = 0; i < _marks.GetLength(0); i++)
                {
                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        Console.WriteLine(_marks[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine(TotalScore);
            }
        }
    }
}
