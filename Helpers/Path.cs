using System;

namespace SVN.IO.Helpers
{
    public static class Path
    {
        public static string ApplicationData
        {
            get => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }
    }
}