using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace פרויקט.Utilies
{
   public class ValidateUtil
    {
        //public static bool IsHebrew(string word)
        //{
        //    string pattern = @"\b[א-ת-\s ]+$";
        //    Regex reg = new Regex(pattern);
        //    return reg.IsMatch(word);
        //}
        //public static bool IsNum(string st)
        //{
        //    string pattern = @"\b[0-9-\s]+$";
        //    Regex reg = new Regex(pattern);
        //    bool a = reg.IsMatch(st);
        //    return a;
        //}
        public static bool Isalfa(string st)
        {
            string pattern = @"\b[A-Za-z א-ת]+\d+$";
            Regex reg = new Regex(pattern);
            return reg.IsMatch(st);
        }
        public static bool checkVisa(string numCard)
        {
            int c, result = 0;
            if (numCard == "")
                return false;
            if (numCard.IndexOf("0") == 0 || numCard.IndexOf("0") == numCard.Length - 1)
                return false;
            string check = "one";
            for (int i = numCard.Length - 1; i >= 0; i--)
            {
                if (check == "one")
                {
                    c = Convert.ToInt32(numCard[i].ToString()) * 1;
                    check = "two";
                }
                else
                {
                    c = Convert.ToInt32(numCard[i].ToString()) * 2;
                    check = "one";
                }
                if (c >= 10)
                {
                    result += c % 10 + c / 10;
                }
                else
                    result = result + c;
            }
            if (result % 10 == 0)
                return true;
            return false;
        }

        //public static bool IsGil(string st, int startGil, int endGil)
        //{
        //    if (st.Length == 0)
        //        return false;
        //    if (Convert.ToInt32(st.ToString()) < startGil || Convert.ToInt32(st.ToString()) > endGil)
        //        return false;
        //    return true;
        //}

        //public static bool LegalId(string s)
        //{
        //    int x;
        //    if (!int.TryParse(s, out x))
        //        return false;
        //    if (s.Length < 5 || s.Length > 9)
        //        return false;
        //    for (int i = s.Length; i < 9; i++)
        //        s = "0" + s;
        //    int sum = 0;
        //    for (int i = 0; i < 9; i++)
        //    {
        //        int k = ((i % 2) + 1) * (Convert.ToInt32(s[i]) - '0');
        //        if (k > 9)
        //            k -= 9;
        //        sum += k;
        //    }
        //    return sum % 10 == 0;
        //}
        //public static bool IsCellPhone(string pel)
        //{
        //    string pattren = @"\b05[0 1 2 3 4 5 6 7 8]-[2-9]\d{6}$";
        //    Regex reg = new Regex(pattren);
        //    return reg.IsMatch(pel);
        //}
        //public static bool IsTelPhone(string tel)
        //{
        //    string pattren = @"\b0[2 3 4  72 77 8 9]-[2-9]\d{6}$";
        //    Regex reg = new Regex(pattren);
        //    return reg.IsMatch(tel);
        //}
        //בדיקה אם הטקסט בעברית
        public static bool IsHebrew(string s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] < 'א' || s[i] > 'ת') && (s[i] != ' '))
                    return false;
            }

            return true;
        }
        //בדיקה אם הטקסט באנגלית
        public static bool IsEnglish(string s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] < 'a' || s[i] > 'z') && (s[i] != ' '))
                    return false;
            }

            return true;
        }
        //בדיקת תקינות מייל
        public static bool IsMail(string s)
        {
            int t = 0, c = 0;
            for (int i = 0; i < s.Length; i++)
            {//בדיקה שאין אותיות בעברית
                if ((s[i] < 'א' || s[i] >= 'ת') && (s[i] == ' '))
                    return false;
                if (s[i] == '@')
                {
                    c++;
                    if (c > 1)
                        return false;
                }

            }
            if (!s.Contains("@"))//@ בדיקה אם יש 
                return false;
            if (s.IndexOf('@') == 0)// לא ראשון @ בדיקה  
                return false;
            for (int i = s.IndexOf('@'); i < s.Length; i++)
            {
                if (s[i] == '.')
                {
                    if (t == 0)
                    {
                        t++;
                        if (s.IndexOf("@") + 1 >= i)//בדיקה שיש אחרי שטרודל נקודה אבל לא ברצף
                            return false;
                        if (i == s.Length - 1)//בדיקה שהנקודה לא אחרונה
                            return false;
                    }
                }
            }
            if (t == 0)//בדיקה אם יש נקודה
                return false;
            return true;

        }

        //בדיקה אם הטקסט מספר  
        public static bool IsNum(string s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                    return false;
            }

            return true;
        }

        //בדיקת תקינות טלפון  
        public static bool IsTel(string s)
        {

            if (s == "")
                return true;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                    return false;
            }
            if (s.IndexOf('0') != 0 || s.Length != 9)
                return false;
            return true;
        }
        //בדיקת תקינות פלפון  
        public static bool IsPelepon(string s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                    return false;
            }
            if (s.IndexOf('0') != 0 || s.Length != 10)
                return false;
            return true;
        }

        //בדיקת תקינות ת.ז
        public static bool LegalId(string d)
        {
            if (!ValidateUtil.IsNum(d))
                return false;
            while (d.Length < 9)
            {
                d = "0" + d;
            }


            int s = 0, t;
            for (int i = 0; i < d.Length; i++)
            {
                if (i % 2 == 0)// הראשון זוגי להכפיל ב1  
                {
                    s += Convert.ToInt32(d[i].ToString());
                }
                if (i % 2 != 0)
                {
                    t = Convert.ToInt32(d[i].ToString()) * 2;
                    if (t < 10)
                        s += t;
                    else
                        s += t % 10 + t / 10;
                }
            }
            if (s % 10 == 0)
                return true;
            return false;
        }
        public static int GetNumDay(string dayname)
        {
            string[] days = new string[] { "ראשון", "שני", "שלישי", "רביעי", "חמישי", "שישי" };
            for (int i = 0; i < days.Length; i++)
            {
                if (days[i] == dayname)
                    return i + 1;
            }
            return -1;
        }
        //public static bool isOneLeter(string word)
        //{
        //    if(word.ToString().Length==1)
        //    return false;
        //}
        public static bool IsNumDouble(string s)
        {
            int mone = 0;
            if (!IsNum(s[0].ToString()))
                return false;
            if (!IsNum(s[s.Length - 1].ToString()))
                return false;
            for (int i = 1; i < s.Length - 1; i++)
            {
                if (!IsNum(s[i].ToString()))
                    if (s[i] != '.')
                        return false;
                    else
                        mone++;
            }
            if (mone > 1)
                return false;
            return true;

        }
        public static string GetNameDay(int numDay)
        {
            string[] days = new string[] { "ראשון", "שני", "שלישי", "רביעי", "חמישי", "שישי" };
            return days[numDay];
        }
        //public static bool IsOneLeter(string word)
        //{
        //    if (word.ToString().Length == 1)
        //        return false;
        //}
    }
}
