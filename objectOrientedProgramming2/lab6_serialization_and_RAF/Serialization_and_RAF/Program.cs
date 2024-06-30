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

            // Read the file using Random Access File (RAF)
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

            // (*1) Updating the size of the file after the newWord was added
            // fi = new FileInfo(filePath);
            // originalFileSize = fi.Length;

            // Read the newWord using RAF
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                // We will read into the file as many bytes as the string newWord consumes of memory
                byte[] buffer = new byte[(int)originalFileSize + System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord)];

                // bufferRead represents the size of the file added the newWord
                //int bufferRead = fs.Read(buffer, 0, buffer.Length);
                fs.Seek(-System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord), SeekOrigin.End);
                int bufferRead = fs.Read(buffer, 0, System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord));

                /* -------------------------------------------------------------------------------------
                // Why would the following offset value send us out of bounds for the array or count is
                // greater than the number of elements from index to the end of the source collection? (*1)

                // int bufferRead = fs.Read(buffer, (int)originalFileSize - System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord), buffer.Length);
                // int bufferRead = fs.Read(buffer, (int)originalFileSize, buffer.Length);
                // -------------------------------------------------------------------------------------


                // Instead of 'System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord)', we could have had
                // created two FileInfo(filePath) fi and have calculated the difference between them.
                
                // If I overwrite the buffer with less than its full size, then the remaining data remains.
                 */

                // Display into the console
                Console.WriteLine("Tech Competition");
                Console.WriteLine($"In Word: \"{Encoding.UTF8.GetString(buffer).ToUpper()}\"");


                // Define a new buffer
                byte[] buffer1 = new byte[(int)originalFileSize + System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord)];
                // Reposition the fs pointer
                fs.Seek(-System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord), SeekOrigin.End);
                // Writes on the buffer
                int bufferRead1 = fs.Read(buffer1, 0, System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord));
                Console.WriteLine($"The First Character is: \"{Encoding.UTF8.GetString(buffer1)[0]}\"");


                // Define a new buffer
                byte[] buffer2 = new byte[(int)originalFileSize + System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord)];
                // Reposition the fs pointer
                fs.Seek((-System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord)/2)-1, SeekOrigin.End);
                // Writes on the buffer
                int bufferRead2 = fs.Read(buffer2, 0, System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord));
                Console.WriteLine($"The Middle Character is: \"{Encoding.UTF8.GetString(buffer2)[0]}\"");


                // Define a new buffer
                byte[] buffer3 = new byte[(int)originalFileSize + System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord)];
                // Reposition the fs pointer
                fs.Seek(-1, SeekOrigin.End);
                // Writes on the buffer
                int bufferRead3 = fs.Read(buffer3, 0, System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord));
                Console.WriteLine($"The Last Character is: \"{Encoding.UTF8.GetString(buffer3)[0]}\"");

                /*
                Console.WriteLine("Tech Competition");
                Console.WriteLine($"In Word: {Encoding.UTF8.GetString(buffer).ToUpper()}");

                fs.Seek(-System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord), SeekOrigin.End);
                bufferRead = fs.Read(buffer, 0, buffer.Length);
                Console.WriteLine($"The First Character is: {Encoding.UTF8.GetString(buffer).ToUpper()}");

                fs.Seek(-System.Text.ASCIIEncoding.ASCII.GetByteCount(newWord) / 2, SeekOrigin.End);
                bufferRead = fs.Read(buffer, 0, buffer.Length);
                Console.WriteLine($"The Middle Character is: {Encoding.UTF8.GetString(buffer).ToUpper()}");

                fs.Seek(-1, SeekOrigin.End);
                bufferRead = fs.Read(buffer, 0, buffer.Length);
                Console.WriteLine($"The Last Character is: {Encoding.UTF8.GetString(buffer).ToUpper()}");
                */
            }
        }
    }
}
