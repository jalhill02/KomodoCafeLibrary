using System;
using System.Collections.Generic;
using System.Text;

namespace _03_KomodoInsuranceLibrary
{
    class PossibleDictionary
    {
        private static Dictionary<string, object> DictionaryItems;
        private static void Add(string strKey, object datatType)
        {
            if (!DictionaryItems.ContainsKey(strKey))
            {
                DictionaryItems.Add(strKey, datatType);
            }
            else
            {
                DictionaryItems[strKey] = datatType;
            }
        }

        private static T GetAnyValue<T>(string strKey)
        {
            object obj;
            T retType;
            DictionaryItems.TryGetValue(strKey, out obj);
            try
            {
                return  (T)obj;
                    
            }
            catch
            {
                retType = default(T);

            }
            return retType;

        }

        static void Main(string[] vs)
        {
            DictionaryItems = new Dictionary<string, object>();

            Add("Badge1", 23456);
            Add("Badge2", 23456);
            Add("Badge3", 23456);
            Add("Badge4", 23456);

            Console.WriteLine("Badge1" + GetAnyValue<int>("Badge1"));

            Console.ReadLine();

        }
    }
}
