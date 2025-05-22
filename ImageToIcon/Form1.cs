using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ImageToIcon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            testIcon(@"D:\Icons\icontest.ico");
            //testIcon(@"D:\Icons\icontest1.ico");
            testPng();
            //testBmp();

            saveIcon();
        }

        private void testIcon(string path) {
            byte[] bytes = File.ReadAllBytes(path);

            Debug.WriteLine("Header:");
            for (int i = 0; i < 6; i++) {
                Debug.Write(GetByteString(bytes[i]));
            }

            Debug.WriteLine("\nInformation:");
            for (int i = 6; i < 22; i++){
                Debug.Write(GetByteString(bytes[i]));
            }

            Debug.WriteLine("\nRest:");
            for (int i = 22; i < bytes.Length; i++) {
                Debug.Write(GetByteString(bytes[i]));

                if ((i - 21) % 20 == 0) {
                    Debug.WriteLine("");
                }
            }


            Debug.WriteLine("");
            //File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\iconTest.ico", bytes);
        }
        private void testPng() {
            byte[] bytes = File.ReadAllBytes(@"D:\Icons\compressedPng.png");

            Debug.WriteLine("\n\n\nPNG - Rest:");
            for (int i = 0; i < bytes.Length; i++){
                Debug.Write(GetByteString(bytes[i]));

                if ((i + 1) % 20 == 0)
                {
                    Debug.WriteLine("");
                }
            }


            Debug.WriteLine("");
            //File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\iconTest.ico", bytes);
        }
        private void testBmp()
        {
            byte[] bytes = File.ReadAllBytes(@"D:\Icons\bmpIconTest.bmp");

            Debug.WriteLine("\n\n\nBMP - Rest:");
            for (int i = 0; i < bytes.Length; i++)
            {
                Debug.Write(GetByteString(bytes[i]));

                if ((i + 1) % 20 == 0)
                {
                    Debug.WriteLine("");
                }
            }


            Debug.WriteLine("");
            //File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\iconTest.ico", bytes);
        }

        private void saveIcon() {
            string[] allBytes = Properties.Resources.TextFile.Replace("\r\n", "").Trim().Split(
                new[] { "-" }, StringSplitOptions.RemoveEmptyEntries
            );

            byte[] bytes = new byte[allBytes.Length];
            for (int i = 0; i < bytes.Length; i++) {
                bytes[i] = Convert.ToByte(allBytes[i]);
            }

            File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\iconTest.ico", bytes);
        }

        private string GetByteString(byte byte1) {
            string text = byte1.ToString() + " ";

            if (byte1 > 9 && byte1 < 100)
            {
                text += " ";
            }
            else if (byte1 < 10)
            {
                text += "  ";
            }

            return text;
        }
    }
}
