using Aspose.Email.Storage.Pst;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ostConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 2)
            {
                args = new string[2];
                Console.WriteLine("Enter the input file path:");
                args[0] = Console.ReadLine();
                Console.WriteLine("Enter the output folder path:");
                args[1] = Console.ReadLine();
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine($"File {args[0]} doesn't exist...");
                goto exit;
            }

            using (PersonalStorage personalStorage = PersonalStorage.FromFile(args[0]))
            {
                if (!Directory.Exists(args[1]))
                {
                    if (Directory.Exists(Path.GetDirectoryName(args[1])))
                    {
                        args[1] = Path.GetDirectoryName(args[1]);
                        Console.WriteLine($"That's not the folder's path... will use {args[1]} as the path");
                    }
                    else
                    {
                        Console.WriteLine($"{args[1]} doesn't exist...");
                        goto exit;
                    }
                }
                Console.WriteLine($"Writing to {args[1]} as storage_part0.pst");
                personalStorage.SplitInto(4000000000, args[1]);
                Console.WriteLine("Finished converting the ost file.");
            }
            exit:
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }
    }
}
