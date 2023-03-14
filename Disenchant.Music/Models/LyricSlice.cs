using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Disenchant.Music.Models
{
    public class LyricSlice : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private double _time;
        public double Time { get { return _time; } set { _time = value; OnPropertyChanged(nameof(Time)); } }
        private string _content;
        public string Content { get { return _content; } set { _content = value; OnPropertyChanged(nameof(Content)); } }
        public LyricSlice(double time, string content)
        {
            Time = time;
            Content = content;
        }

        public static ObservableCollection<LyricSlice> GetLyricSlices(string lyric)
        {
            List<LyricSlice> lyricSlices = new List<LyricSlice>();

            string[] lines = lyric.Split('\n');
            foreach (string line in lines)
            {
                if (line != null)
                {
                    if (line.StartsWith("[ti:"))
                    {
                        continue;
                    }
                    else if (line.StartsWith("[ar:"))
                    {
                        continue;
                    }
                    else if (line.StartsWith("[al:"))
                    {
                        continue;
                    }
                    else if (line.StartsWith("[by:"))
                    {
                        continue;
                    }
                    else if (line.StartsWith("[offset:"))
                    {
                        continue;
                    }
                    else
                    {
                        try
                        {
                            Regex regexword = new Regex(@".*\](.*)");
                            Match mcw = regexword.Match(line);
                            string word = mcw.Groups[1].Value;
                            Regex regextime = new Regex(@"\[([0-9.:]*)\]", RegexOptions.Compiled);
                            MatchCollection mct = regextime.Matches(line);
                            foreach (Match item in mct)
                            {
                                double time = TimeSpan.Parse("00:" + item.Groups[1].Value).TotalMilliseconds;
                                lyricSlices.Add(new LyricSlice(time, word));
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }
            return new ObservableCollection<LyricSlice>(lyricSlices.OrderBy(t => t.Time));
        }
    }
}
