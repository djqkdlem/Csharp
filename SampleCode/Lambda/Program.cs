using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class Program
    {

        // 타입
        public class Info
        {
            public string name { get; set; }
            public int[] score { get; set; }
        }

        // 타입
        public class Person
        {
            public string sex { get; set; }
            public string name { get; set; }
        }

        // 배열
        static Info[] infoArr =
        {
            new Info(){name="아라", score=new int[]{88,75,190,67}},
            new Info(){name="도희", score=new int[]{90,70,20,111}},
            new Info(){name="현아", score=new int[]{89,87,68,22}}
        };

        // 리스트
        static List<Info> infoList = new List<Info>()
        {
            new Info(){name="AAA",score=new int[]{142,2,3}},
            new Info(){name="BBB",score=new int[]{1,2,3}}
        };

        // 리스트
        static List<Person> personList = new List<Person>
        {
            new Person() { sex = "여자", name = "아라" },
            new Person() { sex = "남자", name = "쓰레기" },
            new Person() { sex = "여자", name = "민희" },
            new Person() { sex = "남자", name = "삼천포" },
        };


        static void Main(string[] args)
        {
            //배열, 리스트에 대해서 각각 함수 샘플만들기


            // INDEX
            int index = infoList.Select((item, i) => new { Item = item.name, Index = i })
               .First(x => x.Item == "BBB").Index;
            Console.WriteLine(index);

            // FIND
            Info info = infoList.Find(c => c.name == "AAA");
            Console.WriteLine(info.name);

            //name에 '현'포함
            IEnumerable<string> result = from lInfo in infoArr where lInfo.name.Contains("현") orderby lInfo.name select lInfo.name;

            Console.WriteLine(result.Single());
          

            //
            IEnumerable <Info> rs = from lInfo in infoList
                         where lInfo.name.Contains("AAA")
                         select lInfo;
            foreach (var i in rs)
            {
                Console.WriteLine(i.score[0]);
            }

            //
            var inf = from i in infoList
                      where i.name =="AAA"
                      select new
                      {
                          Name = i.name,
                          Score = i.score[0]
                      };

            foreach (var item in inf)
            {
                Console.WriteLine(item);
            }

            // group
            var Group = from person in personList
                        group person by person.sex == "남자" into data
                        //select personList;
                        select new
                        {
                            sexCheck = data.Key,
                            Person = data
                        };

            foreach (var item in Group)
            {

                if (item.sexCheck)
                {
                    Console.WriteLine("남자들");
                    foreach (var i in item.Person)
                    {
                        Console.WriteLine("이름 : "+i.name);
                    }
                }
                else
                {
                    Console.WriteLine("여자들");
                    foreach (var i in item.Person)
                    {
                        Console.WriteLine("이름 : " + i.name);
                    }
                }
            }
        }
    }
}
