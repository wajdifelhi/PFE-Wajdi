using System;
using System.Collections.Generic;
using System.Messaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMQ_receiver
{
    class Program
    {
        static string path = @".\private$\PFE_TEST";
        //MessageQueue messageQueue = null;

        static void Main(string[] args)
        {
            /*
            string command = "";
            while (command.ToLower() != "exit")
            {
                Console.WriteLine("Checking for messages ");
                ReadQueue(path);
                command = Console.ReadLine();
            }

            Console.WriteLine("Exit program ");
            */ 
            while (true)
            {
                Console.WriteLine("Checking for messages ");
                ReadQueue(path);
                System.Threading.Thread.Sleep(3000);
            }

            Console.WriteLine("Exit program ");
            


            Console.ReadLine();

        }

        public static List<string> ReadQueue(string path)

        {
            DateTime date = DateTime.Now;
            List<string> lstMessages = new List<string>();


                using (MessageQueue messageQueue = new MessageQueue(path))

                {

                    Message[] messages = messageQueue.GetAllMessages();

                    foreach (Message message in messages)

                    {

                        message.Formatter = new XmlMessageFormatter(new String[] { "System.String, mscorlib" });

                        string msg = message.Body.ToString();
                   
                        lstMessages.Add(msg);

                    }
                    messageQueue.Purge();
                }

                foreach (var item in lstMessages)
                {
                    Console.WriteLine(item);
                }

           
                    return lstMessages;
            
                
            }

    }

}


