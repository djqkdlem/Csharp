namespace Regex
{
    class Program
    {
        static void Main(string[] args)
        {

            string pattern = @"^01([0|1|6|7|8|9]?)-?([0-9]{3,4})-?([0-9]{4})$";

            //if (typeList.Where(x => Regex.IsMatch(x.MobileTel, pattern) != true).ToList().Count > 0)
            //{
            //    throw new Exception("형식에 맞지 않는 핸드폰번호가 존재합니다.");
            //}
        }
    }
}
