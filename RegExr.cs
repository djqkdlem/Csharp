using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Sample
{
    public class RegExr
    {
        public static void EXEC()
        {
            #region Regx 
            string pattern = @"^01([0|1|6|7|8|9]?)-?([0-9]{3,4})-?([0-9]{4})$";
            if (Common.InfoList.Where(x => Regex.IsMatch(x.PhoneNumber, pattern) != true).ToList().Count > 0)
            {
                throw new Exception("형식에 맞지 않는 핸드폰번호가 존재합니다.");
            }
            string str = @"Welcome to RegExr v2.0 by gskinner.com!
Edit the Expression & Text to see matches. Roll over matches or the expression for details.
Undo mistakes with ctrl-z. Save & Share expressions with friends or the Community.
A full Reference & Help is available in the Library, or watch the video Tutorial.
Sample text for testing: abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ 0123456789
_+-.,!@#$%^&*();\/|<>'12345 -98.7 3.141 .6180 9,000 +42555.123.4567	+1-800)-555-2468
foo@demo.net djqkdlem@gmail.com	bar.ba@test.co.uk www.demo.com http://foo.co.uk/http://regexr.com/foo.html?q=bar";

            /*
            [^ ]     => not
            ()       => 구분
            { }      => 수량
            \w       => 영문,숫자, _
            \W       => 영문,숫자,_ 제외, 공백포함
            \w+      => 연속
            \d       => 숫자
            \D       => 숫자제외
            .+       => 1 or more
            .*       => 0 or more
            \b       => 문단맨앞
            .*?      => 게으른 검출

            ex) <div>text</div> <div>hello</div>    <div> </div>로 구분해서 검출
                <div>.*?</div> 

            (?=내용 )    =>내용부분앞까지 검출
            ex> bjw @gmail.com     [\w]+(?=@)     bjw검출 
             */

            // 메일검출
            pattern = @"\w+@\w+\.(com|net)";
            Match match = Regex.Match(str, pattern, RegexOptions.IgnoreCase);
            if (match.Success)  //Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase)
            {
                Console.WriteLine("단일검출");
                Console.WriteLine("pattern : {0}", pattern);
                Console.WriteLine("result : {0}", match.Value);
            }
            else
            {
                Console.WriteLine("일치하지 않습니다.");
            }

            //영문,숫자,_ 를 제외한 나머지 제거
            //pattern = @"\W";
            //Regxs(str, pattern);

            //@앞까지의 영문,숫자,_
            pattern = @"\w+(?=@)";
            Regx(str, pattern);
            Regxs(str, pattern);

            //a로 시작하는 문자열
            pattern = @"\ba\w+";
            Regx(str, pattern);
            Regxs(str, pattern);

            //e로 끝나는 문자열
            pattern = @"\w+e\b";
            Regx(str, pattern);
            Regxs(str, pattern);


            var test = " <div>kkkkk<div>";
            test = Regex.Replace(test, "<", "&lt;");

            Console.WriteLine(test);

            // 문자열의 첫번째단어를 대문자로.
            str = "hello";
            Regex.Replace(str, @"\b[a-z]\w+", delegate (Match m)
            {
                string v = m.ToString();
                return char.ToUpper(v[0]) + v.Substring(1);
            });
            #endregion
        }
        public static void Regx(string str, string pattern)
        {
            Match match = Regex.Match(str, pattern, RegexOptions.IgnoreCase);
            if (match.Success)  //Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase)
            {
                Console.WriteLine("단일검출");
                Console.WriteLine("pattern : {0}", pattern);
                Console.WriteLine("result : {0}", match.Value);
            }
            else
            {
                Console.WriteLine("일치하지 않습니다.");
            }
            Console.WriteLine();
        }

        //다중검출
        public static void Regxs(string str, string pattern)
        {
            MatchCollection matches = Regex.Matches(str, pattern, RegexOptions.IgnoreCase);
            Console.WriteLine("다중검출");
            if (matches.Count == 0)
            {
                Console.WriteLine("일치하지 않습니다.");
            }
            else
            {
                Console.WriteLine("pattern : {0}", pattern);
                Console.WriteLine("count : {0}", matches.Count);
                foreach (Match match in matches)
                {
                    Console.WriteLine("result : {0}", match.Value);
                }
            }
        }
    }
}
