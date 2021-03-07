using System;
using System.IO;

namespace MethodTraining
{
    class Program
    {
        void MethodWriting(string fileName)                //This method is for writing data
        {
            FileStream File = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            {
                Console.WriteLine("Will be writing 0x64(100) bytes to file. Press any key to start.");
                Console.ReadKey();
                int t = 0;
                for (byte i = 0x00; i < 0x64; i++)
                {
                    File.WriteByte(i);
                    Console.WriteLine(t);
                    t++;
                }
                File.Close();
                Console.WriteLine("\nDone! Bytes successfully writen to file and saved to the same directory as this program.");
            }
        }
        void MethodReading(string fileName)
        {
            while (!File.Exists(fileName))
            {
                Console.WriteLine("The specified file does not exist in the same directory. Did you mispell anything?\nType a number...\n1. Try again.\n2. Quit");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Specify the file name. Make sure the file is in the same folder as this program. Be sure to include the full extension!");
                    fileName = Console.ReadLine();
                }
                else if (input == "2")
                {
                    return;
                }
            }
            FileStream readFile = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
            {
                Console.WriteLine("File found. Preparing to read the first 100 bytes.\nPress any key to continue.\n");
                Console.ReadKey();
                readFile.Position = 0x00;
                int y = 0x01;
                for (int i = 0x00; i < 0x64; i++)
                {
                    byte[] data = { (byte)readFile.ReadByte() };
                    string hex = BitConverter.ToString(data);

                    Console.Write(hex + " ");
                    if (y == 0x10)
                    {
                        Console.WriteLine("\r");
                        y -= 0x10;
                    }
                    y++;
                }
                readFile.Close();
                Console.WriteLine("\n\nEnd of Bytes reached. Press any key to close this program...");
                Console.ReadKey();
            }
            return;
        }
        void MethodEditing(string fileName)
        {
            while (!File.Exists(fileName))
            {
                Console.WriteLine("The specified file does not exist in the same directory. Did you mispell anything?\nType a number...\n1. Try again.\n2. Quit");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Specify the file name. Make sure the file is in the same folder as this program. Be sure to include the full extension!");
                    fileName = Console.ReadLine();
                }
                else if (input == "2")
                {
                    return;
                }

            }
            FileStream editFile = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
            {
                Console.WriteLine("File Found.");
                string input = "";
                string value = "";
                int valueInt;
                while (input != "4")
                Console.WriteLine("Please select from the following options.\n1. Read single byte.\n2. Edit single byte.\n3. Add bytes to end of file.\n4. Quit");
                input = Console.ReadLine();
                if (input == "1")
                {
                    bool loops = true;
                    while (loops == true)
                    {
                        /*long length = editFile.Length;
                        Console.WriteLine("The file is exactly 0x" + Convert.ToString(length, 16) + " bytes long. Specify an address to edit one byte.\nPlease only input the number after the '0x'.");
                        value = Console.ReadLine();
                        bool canParse = Int32.TryParse(value, out valueInt);
                        if (!canParse)
                        {
                            Console.WriteLine("I'm sorry. I couldn't understand your input... Try again?");

                        }
                        return;*/
                    }

                }
                else if (input == "2")
                {

                }
                else if (input == "3")
                {

                }
            }
        }
        static void Main(string[] args)
        {
            string nameOfFile;
            Console.WriteLine("Would you like to do something to a file? Type 'Y' or 'y' for yes. Anything else for no.");
            string confirmation = Console.ReadLine();
            if (confirmation == "Y" || confirmation == "y")
            {
                Console.WriteLine("Ok. Edit an existing file, or create a new one? C/E");
                confirmation = Console.ReadLine();
                if (confirmation == "C" || confirmation == "c")
                {
                    Console.WriteLine("What do you want to name it? Please include the file extension.");
                    nameOfFile = Console.ReadLine();

                    Program Create = new Program();
                    Create.MethodWriting(nameOfFile);

                    Console.WriteLine("Thanks for using this dumb program to write 0x64 bytes to a file you made.\nNow restart this program to try the reading function!\nThis program will now close. Press any key to continue...");
                    Console.ReadKey();

                    return;
                }
                else if (confirmation == "E" || confirmation =="e")
                {
                    Console.WriteLine("What is the file name with the full extension?");
                    nameOfFile = Console.ReadLine();

                    Program EditFile = new Program();
                    EditFile.MethodEditing(nameOfFile);

                    return;
                }
                else
                {
                    Console.WriteLine("You typed incorrectly. The program will now close.\nPress any key to close this program...");
                    Console.ReadKey();
                    return;
                }
            }
            else
            {
                Console.WriteLine("Would you like to read a file? Type 'Y' or 'y' for yes. Anything else to close program.");
                confirmation = Console.ReadLine();
                if (confirmation == "Y" || confirmation == "y")
                {
                    Console.WriteLine("What is the file name with the full extension?");
                    nameOfFile = Console.ReadLine();

                    Program ReadIt = new Program();
                    ReadIt.MethodReading(nameOfFile);
                }
                else
                {
                    return;
                }
            }
        }
    }
}
