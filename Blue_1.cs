using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Blue_1
    {
        public struct Response
        {
            //поля
            private string _name;
            private string _surname;
            private int _votes;

            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public int Votes => _votes;

            //конструктор
            public Response(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _votes = 0;
            }
            //метод
            public int CountVotes(Response[] responses)
            {
                _votes = 0;
                foreach (var x in responses)
                {
                    if (x.Name == _name && x.Surname == _surname)
                    {
                        _votes++;
                    }
                }
                return _votes;
            }
            //вывод
            public void Print()
            {
                Console.WriteLine(_name + " " + _surname + " " + _votes);
            }
        }
    }
}
