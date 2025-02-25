using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_4
    {
        public struct Team
        {
            private string _name;
            private int[] _scores;

            // свойства
            public string Name => _name;
            public int[] Scores
            {
                get
                {
                    if (_scores == null) return null;
                    int[] copy = new int[_scores.Length];
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        copy[i] = _scores[i];
                    }
                    return copy;
                }
            }
            public int TotalScore
            {
                get
                {
                    if (_scores == null) return 0;
                    return _scores.Sum();
                }
            }


            // конструктор
            public Team(string name)
            {
                _name = name;
                _scores = new int[0];
            }
            public void PlayMatch(int result)
            {
                if (_scores == null) return;
                int[] newscores = new int[_scores.Length + 1];
                for (int i = 0; i < _scores.Length; i++)
                {
                    newscores[i] = _scores[i];
                }
                newscores[newscores.Length - 1] = result;
                _scores = newscores;
            }
            public void Print()
            {
                Console.WriteLine(Name + " " + TotalScore);
            }
        }

        public struct Group
        {
            private string _name;
            private Team[] _teams;
            private int _cnt;

            
            public string Name => _name;
            public Team[] Teams
            {
                get
                {
                    if (_teams == null) return null;
                    Team[] copy = new Team[_teams.Length];
                    for (int i = 0; i < _teams.Length; i++)
                    {
                        copy[i] = _teams[i];
                    }
                    return copy;
                }
            }


            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                _cnt = 0;
            }


            public void Add(Team team)
            {
                if (_teams == null) return;

                if (_cnt < _teams.Length)
                {
                    _teams[_cnt] = team;
                    _cnt++;
                }
            }
            public void Add(Team[] teams)
            {
                if (_teams == null || teams.Length == 0 || teams == null) return;
                int i = 0;
                _teams[_cnt++] = teams[i++];
            }
            public void Sort()
            {
                if (_teams == null || _teams.Length == 0) return;
                for (int i = 0; i < _teams.Length; i++)
                {
                    for (int j = 0; j < _teams.Length - i - 1; j++)
                    {
                        if (_teams[j].TotalScore < _teams[j + 1].TotalScore)
                        {
                            var temp= _teams[j];
                            _teams[j]= _teams[j + 1];
                            _teams[j+1]= temp;
                        }
                    }
                }
            }
            public static Group Merge(Group group1, Group group2, int size)
            {
                Group result = new Group("Финалисты");
                int i = 0, k = 0, h = 0, j = 0;
                while (i < size && j < size)
                {
                    if (group1.Teams[i].TotalScore >= group2.Teams[j].TotalScore)
                    {
                        result.Add(group1.Teams[i]);
                        i++;
                    }
                    else
                    {
                        result.Add(group2.Teams[j]);
                        j++;
                    }
                }
                while (k < size)
                {
                    result.Add(group1.Teams[k]);
                    k++;
                }
                while (h < size)
                {
                    result.Add(group2.Teams[h]);
                    h++;
                }
                return result;
            }

            public void Print()
            {
                Console.WriteLine(_name);
                foreach (Team x in _teams)
                {
                    x.Print();
                }
                Console.WriteLine();
            }
        }
    }
}
