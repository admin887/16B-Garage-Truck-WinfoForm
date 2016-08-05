using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Garage_Truck_WinfoForms
{
    public class Save
    {
        private static Save instance;
        public List<float> m_saveList { get; set; }
        static Stream m_stream;
        static StreamWriter m_sw;
        static FileMode m_fileMode;
        static String m_String = "TruckFile.bin";
        private Save()
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
            m_sw = new StreamWriter(m_stream);

        }
        public static Save Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Save();
                }
                OpenFile();
                return instance;
            }
        }

        public void SaveList(List<int> i_saveList)
        {
            m_stream.SetLength(0);
            foreach (int f in i_saveList)
            {
                m_sw.WriteLine(f);
            }
            m_sw.Flush();
            m_stream.Close();
        }
    }
}
