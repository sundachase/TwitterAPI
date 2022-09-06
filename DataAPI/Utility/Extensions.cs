using System;
namespace DataAPI.Extensions
{
    public static class ExtensionMethods
    {
        public static void Skip(this StreamReader reader, int count)
        {
            while (count-- > 0)
            {
                reader.ReadLine();
            }
        }
    }
}

