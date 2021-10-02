using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ICT3101_Calculator
{
    public class FileReader : IFileReader
    {

        public string[] Read(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
