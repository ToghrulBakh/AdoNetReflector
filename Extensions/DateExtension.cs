using System.Globalization;

namespace AdoNetReflector.Extensions
{
    public static partial class Extension
    {
        public static string FillDate(this string date, string beginDate, string endDate, string lang)
        {
            try
            {
                if (beginDate.Equals(endDate))
                {
                    date = beginDate.Length == 11 ? beginDate.Substring(0, 6) + "</br>" : beginDate.Substring(0, 5) + "</br>";
                    date += "," + beginDate.ToFullDate(lang);
                }
                else
                {
                    string[] beginDt = beginDate.GetDayMonth();
                    string[] endDt = endDate.GetDayMonth();

                    if (beginDt[1].Equals(endDt[1]))
                    {
                        date = beginDt[0] + "-" + endDt[0] + "</br>" + beginDt[1];
                        date += "," + beginDt[0] + "-" + endDt[0] + " " + beginDate.ToFullDate(lang).Substring(2, beginDate.Length - 6);
                    }

                    else
                    {
                        date = beginDt[0] + " " + beginDt[1] + "</br>" + endDt[0] + " " + endDt[1];
                        date += "," + beginDate.ToFullDate(lang) + "-" + endDate.ToFullDate(lang);
                    }
                }
            }
            catch (Exception)
            {

                return string.Empty;
            }

            return date;
        }

        public static string ToFullDate(this string date, string lang)

        {
            string monthName = string.Empty;
            if (date.Length == 11)
            {
                monthName = date.Substring(3, 3);
                date = date.Remove(7, date.Length - 7);
            }
            else
            {
                monthName = date.Substring(2, 3);
                date = date.Remove(6, date.Length - 6);
            }

            if (monthName == "Iyl" || monthName == "Iyn") { monthName = monthName.Replace("I", "İ"); date = date.Replace("I", "İ"); }
            string newMonthName = string.Empty;
            string res = string.Empty;
            int month = 0;
            try
            {
                month = DateTime.ParseExact(monthName, "MMM", CultureInfo.GetCultureInfo("en")).Month;
                newMonthName = CultureInfo.GetCultureInfo(lang).DateTimeFormat.GetMonthName(month);

            }
            catch (Exception)
            {

                return res;
            }

            res = date.Replace(monthName, newMonthName);
            res = month != 6 || month != 7 ? res : res.Replace("I", "İ");
            return res;
        }

        public static string GetCustomDate(this string date, string lang)
        {
            if (!string.IsNullOrEmpty(date))
            {
                string month = string.Empty;
                DateTime convDate = Convert.ToDateTime(date);
                if (lang == "az" && convDate.Month == 6)
                    month = "İyn";
                else if (lang == "az" && convDate.Month == 7)
                    month = "İyl";
                else month = convDate.ToString("dd MMM yyyy", CultureInfo.GetCultureInfo(lang)).Substring(3, 3);
                return convDate.Day + " " + month.FirstCharToUpper() + " " + convDate.Year;
            }
            return string.Empty;

        }

        private static string[] GetDayMonth(this string dt)
        {
            string[] res = new string[2];
            if (dt.Length == 11)
            {
                res[0] = dt.Substring(0, 2);
                res[1] = dt.Substring(3, 3);

            }
            else if (dt.Length == 10)
            {
                res[0] = dt.Substring(0, 1);
                res[1] = dt = dt.Substring(2, 3);
            }
            return res;
        }
    }
}
