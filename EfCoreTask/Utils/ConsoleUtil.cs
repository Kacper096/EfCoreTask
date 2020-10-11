using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Castle.DynamicProxy.Internal;

namespace EfCoreTask.Utils
{
    public static class ConsoleUtil
    {
        public static T GetFieldFromUser<T>(string optionName)
        {
            bool isSuccess = false;

            while (!isSuccess)
            {
                Console.Write(optionName);
                var fromUser = Console.ReadLine();
                if (string.IsNullOrEmpty(fromUser) && !(default(T) == null))
                    continue;

                var result = fromUser.Convert<T>();
                if (((default(T) == null) && result == null) || result != null)
                {
                    isSuccess = true;
                    return result;
                }
            }

            return default;
        }
        
        public static T Convert<T>(this string input)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    return (T)converter.ConvertFromString(input);
                }
                return default;
            }
            catch (NotSupportedException)
            {
                return default;
            }
        }
    }
}
