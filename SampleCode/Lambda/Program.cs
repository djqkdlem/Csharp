using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class Program
    {
        public class ContactInfo
        {
            public int ID { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public override string ToString() { return Email + "," + Phone; }
        }

        public class ScoreInfo
        {
            public double Average { get; set; }
            public int ID { get; set; }
        }

        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;
         
            public override string ToString()
            {
                return First + " " + Last + ":" + ID;
            }
        }


        // The primary data source
        static List<Student> students = new List<Student>()
        {
             new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int>() {97, 92, 81, 60}},
             new Student {First="Claire", Last="O'Donnell", ID=111, Scores= new List<int>() {75, 84, 91, 39}},
             new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int>() {88, 94, 65, 91}},
             new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int>() {97, 89, 85, 82}},
        };

        // Separate data source for contact info.
        static List<ContactInfo> contactList = new List<ContactInfo>()
        {
            new ContactInfo {ID=111, Email="SvetlanO@Contoso.com", Phone="206-555-0108"},
            new ContactInfo {ID=112, Email="ClaireO@Contoso.com", Phone="206-555-0298"},
            new ContactInfo {ID=113, Email="SvenMort@Contoso.com", Phone="206-555-1130"},
            new ContactInfo {ID=114, Email="CesarGar@Contoso.com", Phone="206-555-0521"}
        };

        public class Info
        {
            public string name { get; set; }
            public int[] score { get; set; }
        }

        public class Person
        {
            public string sex { get; set; }
            public string name { get; set; }
        }

        static Info[] infoArr =
        {
            new Info(){name="아라", score=new int[]{88,75,190,67}},
            new Info(){name="도희", score=new int[]{90,70,20,111}},
            new Info(){name="현아", score=new int[]{89,87,68,22}}
        };

        static List<Info> infoList = new List<Info>()
        {
            new Info(){name="AAA",score=new int[]{142,2,3}},
            new Info(){name="BBB",score=new int[]{1,2,3}}
        };

        static List<Person> personList = new List<Person>
        {
            new Person() { sex = "여자", name = "아라" },
            new Person() { sex = "남자", name = "쓰레기" },
            new Person() { sex = "여자", name = "민희" },
            new Person() { sex = "남자", name = "삼천포1" },
            new Person() { sex = "남자", name = "삼천포2" }
        };


        static void Main(string[] args)
        {

            //// Linq와 Lamda 나눠서


            //var studentQuery2 =
            //    from student in students
            //    group student by student.First into g
            //    orderby g.Key
            //    select g;

            //foreach (var studentGroup in studentQuery2)
            //{
            //    Console.WriteLine(studentGroup.Key);
            //    // Explicit type for student could also be used here.
            //    foreach (var student in studentGroup)
            //    {
            //        Console.WriteLine("   {0}, {1}", student.Last, student.First);
            //    }
            //}



            //// Group the pets using Age as the key value 
            //// and selecting only the pet's Name for each value.
            //IEnumerable<IGrouping<int, string>> query =
            //    students.GroupBy(st => st.ID, st => st.First);
        
            //// Iterate over each IGrouping in the collection.
            //foreach (IGrouping<int, string> petGroup in query)
            //{
            //    // Print the key value of the IGrouping.
            //    Console.WriteLine(petGroup.Key);
            //    // Iterate over each value in the 
            //    // IGrouping and print the value.
            //    foreach (string name in petGroup)
            //        Console.WriteLine("  {0}", name);
            //}


            IEnumerable<IGrouping<int, Student>> query2 =
              students.GroupBy(st => st.ID);

            foreach (IGrouping<int, Student> petGroup in query2)
            {
                Console.WriteLine(petGroup.Key);

                foreach (var name in petGroup)
                    Console.WriteLine("  {0}", name.First);
            }




            //personList = personList.OrderByDescending(x => x.sex).ToList();
            //List<Person> sortList = new List<Person>();
            //string initSex = personList[0].sex;
            //string postSex = "";
            //for (int i = 0; i < personList.Count; i++)
            //{
            //    postSex = personList[i].sex;
            //    if (initSex == postSex)
            //    {
            //        sortList.Add(personList[i]);
            //    }
            //    else
            //    {
            //        //여기서 모은거 메일발송
            //        foreach (var y in sortList)
            //        {
            //            Console.WriteLine(y.sex + " " + y.name);
            //        }

            //        initSex = personList[i].sex;
            //        sortList = new List<Person>();
            //        sortList.Add(personList[i]);
            //    }

            //    if (i == personList.Count - 1)
            //    {
            //        foreach (var y in sortList)
            //        {
            //            Console.WriteLine(y.sex + " " + y.name);
            //        }
            //    }
            //}



            //// INDEX
            //int index = infoList.Select((item, i) => new { Item = item.name, Index = i })
            //   .First(x => x.Item == "BBB").Index;
            //Console.WriteLine(index);

            //// FIND
            //Info info = infoList.Find(c => c.name == "AAA");
            //Console.WriteLine(info.name);

            ////name에 '현'포함
            //IEnumerable<string> result = from lInfo in infoArr where lInfo.name.Contains("현") orderby lInfo.name select lInfo.name;

            //Console.WriteLine(result.Single());


            ////
            //IEnumerable<Info> rs = from lInfo in infoList
            //                       where lInfo.name.Contains("AAA")
            //                       select lInfo;
            //foreach (var i in rs)
            //{
            //    Console.WriteLine(i.score[0]);
            //}

            ////
            //var inf = from i in infoList
            //          where i.name == "AAA"
            //          select new
            //          {
            //              Name = i.name,
            //              Score = i.score[0]
            //          };

            //foreach (var item in inf)
            //{
            //    Console.WriteLine(item);
            //}

            // group
            //var Group = from person in personList
            //            group person by person.sex == "남자" into data
            //            //select personList;
            //            select new
            //            {
            //                sexCheck = data.Key,
            //                Person = data
            //            };

            //foreach (var item in Group)
            //{

            //    if (item.sexCheck)
            //    {
            //        Console.WriteLine("남자들");
            //        foreach (var i in item.Person)
            //        {
            //            Console.WriteLine("이름 : " + i.name);
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("여자들");
            //        foreach (var i in item.Person)
            //        {
            //            Console.WriteLine("이름 : " + i.name);
            //        }
            //    }
            //}

            //List<int> numbers1 = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //List<int> numbers2 = new List<int>() { 15, 14, 11, 13, 19, 18, 16, 17, 12, 10 };
            //// Query #4.
            //double average = numbers1.Average();

            //Console.WriteLine(average);
            //// Query #5.
            //IEnumerable<int> concatenationQuery = numbers1.Concat(numbers2);

            //foreach (var item in concatenationQuery)
            //{
            //    Console.WriteLine(item);
            //}


            //List<LineMasterType> tempTypeList = typeList.GroupBy(elem => elem.LineNumber)
            //                                                   .Where(group => group.Count() > 1)
            //                                                   .Select(group => group.First()).ToList<LineMasterType>();




            ////List<Person> personList
            //Person p = null;
            //try
            //{
            //     p = (from person in personList
            //                where person.sex.Contains("남자")
            //                select person)
            //                .First(x => x.name.Contains("2"));

            //}catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //if (p != null)
            //{
            //    Console.WriteLine(p.name);
            //}
            //else
            //{
            //    Console.WriteLine("null");
            //}
        }
    }
}
