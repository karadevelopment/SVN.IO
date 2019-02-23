using Newtonsoft.Json;
using SVN.IO.Helpers;
using SVN.Reflection;
using SVN.Reflection.Helpers;

namespace SVN.IO.Class
{
    public class SavableClass
    {
        private static JsonSerializerSettings Settings
        {
            get => new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
            };
        }

        private static string Extension
        {
            get => ".txt";
        }

        private static string FilePath
        {
            get
            {
                var path = System.IO.Path.Combine(Path.ApplicationData, Assembly.GetCallingAssemblyName(3));

                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                
                return System.IO.Path.Combine(path, typeof(SavableClass).GetClassName() + SavableClass.Extension);
            }
        }

        protected SavableClass()
        {
        }

        public static T ReadFromFile<T>()
        {
            var json = System.IO.File.ReadAllText(SavableClass.FilePath);
            return JsonConvert.DeserializeObject<T>(json, SavableClass.Settings);
        }

        public void WriteToFile()
        {
            var json = JsonConvert.SerializeObject(this, SavableClass.Settings);
            System.IO.File.WriteAllText(SavableClass.FilePath, json);
        }
    }
}