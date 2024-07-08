using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialization_and_RAF
{
    internal class Program
    {
        // ------------------------ PROPERTIES -------------------------
        public long OriginalFileSize { get; set; }
        // --------------------------- MAIN ----------------------------
        static void Main(string[] args)
        {
            Event event1 = new Event(1, "Calgary");

            // SERIALIZATION
            BinaryFormatter bf = new BinaryFormatter();

            // Serialize
            using (FileStream fs = new FileStream(@"C:\temp\event.txt", FileMode.Create)) 
            {
                bf.Serialize(fs, event1);    
            }

            // Deserialize
            FileStream fs_event1_copy = new FileStream(@"C:\temp\event.txt", FileMode.Open, FileAccess.Read);
            Event event1_copy = (Event)bf.Deserialize(fs_event1_copy);
            fs_event1_copy.Close();

            // Display the values on the Console
            Console.WriteLine(event1_copy.EventNumber);
            Console.WriteLine(event1_copy.Location);

            // Read the file using RANDOM ACCESS FILE (RAF)
            ReadFromFile(@"C:\temp\event.txt", "Hackathon", event1);
        }

        // ------------------------------ METHODS ------------------------------
        public static void ReadFromFile(string filePath, string newWord, Event eventObject)
        {
            // Store the current file length to later set as an offset
            FileInfo fi = new FileInfo(filePath);
            long originalFileSize = fi.Length;         

            // Append the string newWord into the file.
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.Write(newWord);
            }

            // Read the newWord using RAF
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                // We will read into the file as many bytes as the string newWord consumes of memory
                byte[] buffer = new byte[(int)originalFileSize + System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord)];

                fs.Seek(-System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord), SeekOrigin.End);
                
                int bufferRead = fs.Read(buffer, 0, System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord));
                // bufferRead = fs.Read(buffer, (int)originalFileSize - System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord), System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord));

                // Display into the console
                Console.WriteLine("Tech Competition");
                Console.WriteLine($"In Word: {Encoding.UTF8.GetString(buffer)}");

                // Define a new buffer
                buffer = new byte[(int)originalFileSize + System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord)];
                // Reposition the fs pointer to the beginning of the newly added word
                fs.Seek(-System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord), SeekOrigin.End);
                // Writes on the buffer
                int bufferRead1 = fs.Read(buffer, 0, System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord));
                Console.WriteLine($"The First Character is: \"{Encoding.UTF8.GetString(buffer)[0]}\"");

                // Reinstanciate the buffer
                buffer = new byte[(int)originalFileSize + System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord)];
                // Reposition the fs pointer to the middle of the newly added word
                fs.Seek((-System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord)/2)-1, SeekOrigin.End);
                // Writes on the buffer
                bufferRead = fs.Read(buffer, 0, System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord));
                Console.WriteLine($"The Middle Character is: \"{Encoding.UTF8.GetString(buffer)[0]}\"");

                // Refine a new buffer
                buffer = new byte[(int)originalFileSize + System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord)];
                // Reposition the fs pointer to one character before the end of the newly added word
                fs.Seek(-1, SeekOrigin.End);
                // Writes on the buffer
                bufferRead = fs.Read(buffer, 0, System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord));
                Console.WriteLine($"The Last Character is: \"{Encoding.UTF8.GetString(buffer)[0]}\"");
            }
        }
    }
}
