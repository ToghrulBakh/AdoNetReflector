using System.ComponentModel;
using System.Data;

namespace AdoNetReflector.Extensions
{
    public static partial class Extension
    {
        public static string MakePureString(this string input)
        {

            string res = "";
            char def = ' ';
            foreach (char item in input.ToCharArray())
            {

                if (!char.IsLetter(item) && !char.IsNumber(item))
                {
                    def = ' ';
                }
                else def = item;
                res += def;
            }

            return res;
        }

        public static string FormatNameToTitle(this string newTitle, string name, string lang)
        {

            if (!string.IsNullOrEmpty(name))
            {
                Dictionary<string, string> letters = GetLetterDictionary(lang);
                name = name.MakePureString();
                string titles = string.Join("-", name.Split(' ').Where(g => g != "").Select(g => g.ToLowerInvariant()).ToArray());
                //string  = string.Join("-", words);
                string x;

                for (int i = 0; i < titles.Length; i++)
                {
                    x = titles[i].ToString();

                    if (letters.ContainsKey(x))
                    {
                        newTitle += letters[x];
                    }
                    else
                    {
                        newTitle += x;
                    }
                }
            }

            return newTitle;
        }
        //Utf8ToASCIIDictionary
        private static Dictionary<string, string> GetLetterDictionary(string lang)
        {
            Dictionary<string, string> letters = new Dictionary<string, string>();
            if (lang == "az")
            {
                letters.Add("ı", "i");
                letters.Add("ə", "e");
                letters.Add("ö", "o");
                letters.Add("ü", "u");
                letters.Add("ş", "s");
                letters.Add("ç", "c");
                letters.Add("ğ", "g");
            }
            else if (lang == "ru")
            {
                letters.Add("а", "a");
                letters.Add("б", "b");
                letters.Add("в", "v");
                letters.Add("г", "g");
                letters.Add("д", "d");
                letters.Add("е", "e");
                letters.Add("ё", "jo");
                letters.Add("ж", "zh");
                letters.Add("з", "z");
                letters.Add("и", "i");
                letters.Add("й", "j");
                letters.Add("к", "k");
                letters.Add("л", "l");
                letters.Add("м", "m");
                letters.Add("н", "n");
                letters.Add("о", "o");
                letters.Add("п", "p");
                letters.Add("р", "r");
                letters.Add("с", "s");
                letters.Add("т", "t");
                letters.Add("у", "u");
                letters.Add("ф", "f");
                letters.Add("х", "h");
                letters.Add("ц", "c");
                letters.Add("ч", "ch");
                letters.Add("ш", "sh");
                letters.Add("щ", "shh");
                letters.Add("ъ", "");
                letters.Add("ы", "y");
                letters.Add("ь", "");
                letters.Add("э", "je");
                letters.Add("ю", "ju");
                letters.Add("я", "ja");
            }

            return letters;
        }
        internal static string FirstCharToUpper(this string s)
        {

            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return s.First().ToString().ToUpper() + s.Substring(1);
        }

        public static DataTable ToDataTable<T>(IEnumerable<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {

                    table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
                }
                else
                {
                    table.Columns.Add(prop.Name, prop.PropertyType);
                }

            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
    }
}
