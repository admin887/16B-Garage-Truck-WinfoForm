using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Garage_Truck_WinfoForms
{
    public class Load
    {
        private static Load instance;
        public List<float> m_saveList { get; set; }
        static Stream m_stream;
        static FileMode m_fileMode;
        static String m_String = "TruckFile.bin";
        static StreamReader m_sr;
        private Load()
        {
        }
        public static void OpenFile()
        {
            if (!File.Exists(m_String))
            {
                m_fileMode = FileMode.Create;
            }
            else
            {
                m_fileMode = FileMode.Open;
            }
            m_stream = new FileStream(m_String, m_fileMode, FileAccess.ReadWrite);
            m_sr = new StreamReader(m_stream);

        }
        public static Load Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Load();
                }
                OpenFile();
                return instance;
            }
        }

        public List<int> LoadList()
        {
            List<int> list = new List<int>();
            while (!m_sr.EndOfStream)
            {
                list.Add(int.Parse(m_sr.ReadLine()));
            }
            m_stream.Close();
            return list;
        }
    }
}
