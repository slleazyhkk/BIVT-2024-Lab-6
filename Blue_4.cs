using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_4
    {
        public struct Team // структура
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
                    return _scores;
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

            // методы 

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

            // свойства
            public string Name => _name;
            public Team[] Teams
            {
                get
                {
                    if (_teams == null) return null;
                    return _teams;
                }
            }

            // конструктор

            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                _cnt = 0;
            }

            //методы

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
                foreach (var team in teams)
                {
                    Add(team);
                }
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
                int group1Count = Math.Min(size / 2, group1.Teams.Length); 
                int group2Count = Math.Min(size - group1Count, group2.Teams.Length); 
                
                int i = 0, j = 0;
                while (i < group1Count && j < group2Count)
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
                while (i < group1Count)
                {
                    result.Add(group1.Teams[i]);
                    i++;
                }
                while (j < group2Count)
                {
                    result.Add(group2.Teams[j]);
                    j++;
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
