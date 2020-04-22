using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalVariableScope
{
    public sealed class data
    {
        Dictionary<String, object> data_dict = new Dictionary<String, object>();
        private static data instance = null;
        public static data Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new data();
                }
                return instance;
            }
        }
        public void AddData(String key, object value)
        {
            if (data_dict.ContainsKey(key))
            {
                throw new Exception("Key already added");
            } else {
                data_dict.Add(key, value);
            }
        }
        public object RetrieveData(String key)
        {
            if (data_dict.ContainsKey(key) == false)
            {
                throw new Exception("Key don't exist");
            }

            return data_dict[key];
        }
        public void DeleteData(String key)
        {
            data_dict.Remove(key);
        }
        public void UpdateData(String key, object NewData)
        {
            data_dict[key] = NewData;
        }
        public String PrintData()
        {
            String text = null;
            foreach (KeyValuePair<String, object> kvp in data_dict)
            {
                text = text+","+kvp.Key;
            }
            return text;
        }
    }
}
