using System;

namespace Asignment_3
{
    class Tools
    {
        public String[] words(String line)
        {
            return line.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
