using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Disenchant.Music.Models
{
    public class LyricInfo
    {
        /// <summary>
        /// 歌曲
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 艺术家
        /// </summary>
        public string Artist { get; set; }
        /// <summary>
        /// 专辑
        /// </summary>
        public string Album { get; set; }
        /// <summary>
        /// 歌词作者
        /// </summary>
        public string LyricInfoBy { get; set; }
        /// <summary>
        /// 偏移量
        /// </summary>
        public string Offset { get; set; }

        /// <summary>
        /// 歌词
        /// </summary>
        public Dictionary<double, string> LyricInfoWord = new Dictionary<double, string>();

        /// <summary>
        /// 获得歌词信息
        /// </summary>
        /// <param name="LyricInfoPath">歌词路径</param>
        /// <returns>返回歌词信息(LyricInfo实例)</returns>
        public LyricInfo(string lyric)
        {
            string[] lines = lyric.Split('\n');
            foreach(string line in lines)
            { 
                if (line != null)
                {
                    if (line.StartsWith("[ti:"))
                    {
                        Title = SplitInfo(line);
                    }
                    else if (line.StartsWith("[ar:"))
                    {
                        Artist = SplitInfo(line);
                    }
                    else if (line.StartsWith("[al:"))
                    {
                        Album = SplitInfo(line);
                    }
                    else if (line.StartsWith("[by:"))
                    {
                        LyricInfoBy = SplitInfo(line);
                    }
                    else if (line.StartsWith("[offset:"))
                    {
                        Offset = SplitInfo(line);
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
                                double time = TimeSpan.Parse("00:" + item.Groups[1].Value).TotalSeconds;
                                LyricInfoWord.Add(time, word);
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }
            LyricInfoWord = LyricInfoWord.OrderBy(t => t.Key).ToDictionary(t => t.Key, p => p.Value);
        }
        public LyricInfo() { }
        /// <summary>
        /// 处理信息(私有方法)
        /// </summary>
        /// <param name="line"></param>
        /// <returns>返回基础信息</returns>
        static string SplitInfo(string line)
        {
            return line.Substring(line.IndexOf(":") + 1).TrimEnd(']');
        }
    }
}
