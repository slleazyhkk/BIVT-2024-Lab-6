using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_5
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private int _place;
            private bool _placeSet;

            public string Name => _name;
            public string Surname => _surname;
            public int Place => _place;
            private bool PlaceSet => _placeSet;
            
            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 0;
                _placeSet = false;

            }

            public void SetPlace(int place)
            {
                if (!_placeSet)
                {
                    if (place > 0)
                    {
                        _place = place;
                        _placeSet = true;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine(_name + " " + _surname + " " + _place);
            }
        }

        public struct Team
        {
            private string _name;
            private Sportsman[] _sportsmen;
            private int _cnt;

            public string Name => _name;
            public Sportsman[] Sportsmen
            {
                get
                {
                    if (_sportsmen == null) return null;
                    return _sportsmen;
                }
            }
            

            public int SummaryScore
            {
                get
                {
                    if (_sportsmen == null || _sportsmen.Length==0) return 0;
                    int score = 0;
                    foreach(Sportsman sportsman in _sportsmen)
                    {
                        switch (sportsman.Place)
                        {
                            case 1: score += 5; break;
                            case 2: score += 4; break;
                            case 3: score += 3; break;
                            case 4: score += 2; break;
                            case 5: score += 1; break;
                        }
                    }
                    return score;
                }
            }

            public int TopPlace
            {
                get
                {
                    if (_sportsmen==null || Sportsmen.Length==0) return 0;
                    int topplace=int.MaxValue;
                    foreach(Sportsman sportsman in _sportsmen)
                    {
                        if (sportsman.Place>0 && sportsman.Place < topplace)
                        {
                            topplace = sportsman.Place;
                        }
                    }
                    if (topplace==int.MaxValue) return 18;
                    return topplace;
                }
            }

            //construct
            public Team(string name)
            {
                _name= name;
                _sportsmen=new Sportsman[6];
                _cnt = 0;
            }

            public void Add(Sportsman sportsman)
            {
                if (_sportsmen == null) return; ;
                if (_cnt < _sportsmen.Length)
                {
                    _sportsmen[_cnt++] = sportsman;
                }
                else return;
            }

            public void Add(Sportsman[] newSportsmen)
            {
                if (_sportsmen == null || _sportsmen.Length == 0) return;
                foreach (Sportsman sportsman in newSportsmen)
                {
                    Add(sportsman);
                }
            }

            public static void Sort(Team[] teams)
            {
                if (teams == null || teams.Length == 0) return;
                for (int i = 0; i < teams.Length; i++)
                {
                    for (int j = 0; j < teams.Length - i - 1; j++)
                    {
                        if (teams[j].SummaryScore < teams[j + 1].SummaryScore)
                        {
                            (teams[j], teams[j + 1]) = (teams[j + 1], teams[j]);
                        }
                        else if (teams[j].SummaryScore == teams[j + 1].SummaryScore)
                        {
                            if (teams[j].TopPlace > teams[j + 1].TopPlace)  (teams[j], teams[j + 1]) = (teams[j+1], teams[j]);
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine(_name);
                for (int i = 0; i < _cnt; i++)
                    _sportsmen[i].Print();
                Console.WriteLine();
            }
        }
    }
}
