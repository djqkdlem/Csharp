using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sample
{
    public static class PasswordValidation
    {
        //2. 패스워드 조합 정책
        //영문, 숫자, 특수문자 세 항목의 문자 종류 중 2종류 이상을 조합하여 최소 10자리 이상 또는 3종류 이상을 조합하여 최소 8자리 이상의 길이로 구성합니다.
        public static bool Union_Rule(string data)
        {
            bool NumberCH = false;
            bool CharCH = false;
            bool SpecialCharCH = false;
            int DataLenght = data.Length;
            string chNumber = "0123456789";
            string chSpecialChar = "`~!@#$%^&*()_+|-=\\[]{};:'\",.<>/?";
            char[] chNumberArr = chNumber.ToCharArray(0, chNumber.Length);
            char[] chSpecialCharArr = chSpecialChar.ToCharArray(0, chSpecialChar.Length);

            for (int i = 0; i < data.Length; i++)
            {
                char[] temp = data.ToCharArray(0, data.Length);

                for (int j = 0; j < chNumberArr.Length; j++)
                {
                    if (chNumberArr[j] == temp[i])
                    {
                        NumberCH = true;
                    }
                }

                if (((temp[i] >= 'a') && (temp[i] <= 'z')) || ((temp[i] >= 'A') && (temp[i] <= 'Z')))
                {
                    CharCH = true;
                }

                for (int j = 0; j < chSpecialCharArr.Length; j++)
                {
                    if (chSpecialCharArr[j] == temp[i])
                    {
                        SpecialCharCH = true;
                    }
                }
            }

            if ((NumberCH == true) && (CharCH == true) && (SpecialCharCH == false) && (DataLenght >= 10))
            {
                return true;
            }
            else if ((NumberCH == true) && (CharCH == true) && (SpecialCharCH == true) && (DataLenght >= 8))
            {
                return true;
            }
            return false;
        }

        // 개인정보 및 아이디와 비슷한 패스워드 사용 금지
        public static bool Personal_Information(string data)
        {
            List<string> myInfo = new List<string>();
            string id = "djqkdlem";
            string joomin1 = "890305";
            string joomin2 = "1234567";
            string tel = "01093096116";
            string email = "bjw@miksystem.com";

            myInfo.Add(id);
            myInfo.Add(joomin1);
            myInfo.Add(joomin2);
            myInfo.Add(tel);
            myInfo.Add(email);
            foreach (string part in myInfo)
            {
                if (data.ToLower().Contains(part.ToLower()))
                {
                    return false;
                }
            }
            return true;
        }

        // 동일한 한 글자 연속성(세번이상 중복될 경우)
        public static bool oneString_Repetition(String data)
        {
            for (int i = 0; i < (data.Length - 2); i++)
            {
                String temp1 = data.Substring(i, 1);
                String temp2 = data.Substring(i + 1, 1);
                String temp3 = data.Substring(i + 2, 1);

                if (temp1.Equals(temp2))
                {
                    if (temp2.Equals(temp3))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //두 자 이상의 동일문자 연속성(두 번 이상 중복될 경우)
        public static bool twoString_Repetition(String data)
        {
            for (int i = 0; i <= data.Length - 2; i++)
            {
                int count = 0;
                String temp = data.Substring(i, 2);

                for (int j = 0; j < (data.Length - 1); j++)
                {
                    String temps = data.Substring(j, 2);
                    if (temps.Equals(temp))
                    {
                        count++;

                        if (count >= 2)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        //키보드  연속성 체크(특수문자 제외)
        public static bool Keyboard_Continuity(String data)
        {
            String[] KeyboardCH = {
                            //숫자 연속성 체크
                            "01234567890", "09876543210",
                            //문자 연속성 체크
                            "QWERTYUIOP", "ASDFGHJKL", "ZXCVBNM",
                            "POIUYTREWQ", "LKJHGFDSA", "MNBVCXZ",
                            "1QAZ", "2WSX", "3EDC", "4RFV", "5TGB", "6YHN", "7UJM",
                            "0OKM", "9IJN", "8UHB", "7YGV", "6TFC", "5RDX", "4ESZ",
                            "ZAQ1", "XSW2", "CDE3", "VFR4", "BGT5", "NHY6", "MJU7",
                            "MKO0", "NJI9", "BHU8", "VGY7", "CFT6", "XDR5", "ZSW4"
                            };
            for (int i = 0; i < KeyboardCH.Length; i++)
            {
                for (int j = 0; j < KeyboardCH[i].Length - 2; j++)
                {
                    int count = 0;
                    string temp = KeyboardCH[i].Substring(j, 3);
                    Match match = Regex.Match(data.ToUpper(), temp.ToUpper(), RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        count++;
                        if (count >= 1)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
