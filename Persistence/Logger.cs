using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence
{
    public static class Logger
    {

        public static void Append(string text, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(text);
                }
            }
            catch(Exception e)
            {
                Thread.Sleep(1000);
                Append(text, path);
            }
            
            
        }

        public static void Write(string text, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(text);
                }
            }
            catch (Exception e)
            {
                Thread.Sleep(1000);
                Append(text, path);
            }
        }

    }
}
