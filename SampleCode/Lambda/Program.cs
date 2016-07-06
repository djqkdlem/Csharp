using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class Program
    {

        public class Woman
        {
            public string name { get; set; }
            public int[] score { get; set; }
        }

        static Woman[] womanArray =
        {
            new Woman(){name="아라", score=new int[]{88,75,190,67}},
            new Woman(){name="도희", score=new int[]{90,70,20,111}},
            new Woman(){name="현아", score=new int[]{89,87,68,22}}
        };

        static List<Woman> collectionList = new List<Woman>()
        {
            new Woman(){name="AAA",score=new int[]{156,2,3}},
            new Woman(){name="BBB",score=new int[]{1,2,3}}
        };


        static void Main(string[] args)
        {
            // INDEX
            int index = collectionList.Select((item, i) => new { Item = item.name, Index = i })
               .First(x => x.Item.ToString() == "BBB").Index;
            Console.WriteLine(index);

            // FIND
            var a = collectionList.Find(c => c.name == "AAA");
            Console.WriteLine(a.name);

            //name에 '현'포함
            var result = from woman in womanArray where woman.name.Contains("현") orderby woman.name select woman.name;

            Console.WriteLine(result.Single());
            //foreach (var i in result)
            //{
            //    Console.WriteLine(i);
            //}

            var rs = from woman in collectionList
                         where woman.name.Contains("AAA")
                         select woman;
            foreach (var i in rs)
            {
                Console.WriteLine(i.score[0]);
            }


            collectionList.RemoveAll(x => x.name == "BBB");

            foreach (var item in collectionList)
            {
                Console.WriteLine(item.name);
            }
        }
    }
}
