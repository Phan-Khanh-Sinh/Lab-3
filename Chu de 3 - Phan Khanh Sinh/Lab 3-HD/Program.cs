using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Lab_3_HD
{
    class Program
    {
        public static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmDocTuFile());
        }
    }
}