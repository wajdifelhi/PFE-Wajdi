using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MsmqTest 
{



    //public class Flux
    //{
    //    public int flowId;
    //    public string flowName;
    //    public string flowDescription;
    //    public bool flowAuto;
    //};
   public class Program : Message
    {
        private static Random random = new Random();

        static string messageFlow = "t";
        static MessageQueue messageQueue = null;


        public static void Main(string[] args)

        {
            Flow flow = new Flow();

            IsStarted();
            IsFinished();
            string flux = "";
            FlowMngr(flux);

            Message message = new Message();
           Guid ActionId = message.MessageId;
        }


        // class Flow
        //................................................................
              public class Flow
        {
            public Guid FlowId { get; set; }
            public string Name { get; set; }
            public bool IsAutomatic { get; set; }
            public string FlowDescription { get; set; }
            public Flow()

            {
            }

            public Flow(Guid Fid, string Fname, bool Fauto, string Fdes)
            {
                Guid FlowId = Guid.NewGuid();
                //Flow_id = Fid;
                FlowDescription = Fdes;
                Name = Fname;
                IsAutomatic = Fauto;
            }
        }



        public static List<string> FlowMngr(string flux)
        {

            Message message = new Message();
            Guid ActionId = message.MessageId;
            DateTime dateEnvoie = DateTime.Now;
            List<string> lstFlux = new List<string>();
            string description = "This is a test queue.";
            DateTime dateReçu = DateTime.Now;
            string path = @".\private$\PFE_TEST";



         
            try

            {
                if (MessageQueue.Exists(path))
                {
                    messageQueue = new MessageQueue(path);
                    messageQueue.Label = description;
                    
                }

                else

                {
                    MessageQueue.Create(path);

                    messageQueue = new MessageQueue(path);

                    messageQueue.Label = description;
                }

                //string myMsg = "";
                //// myMsg = "{\"a\":\"b\",\"c\":\"d\",{\"x\":\"y\"}}";
                //myMsg = "Message from Flow";


                for (int i = 0; i < 20; i++)
                {
                    var action = new List<string>();
                    action.Add("Error");
                    action.Add("flow finished");
                    Random random = new Random();

                    int index = random.Next(action.Count);
                    messageFlow = "#" + i + " Message From  Flow Id :  | " + Guid.NewGuid() + "  | Content : 'this is a test'  " + "sent at | " + dateEnvoie + " | " ;
                    // messageQueue.Send(messageFlow.IsStarted());
                    //System.Threading.Thread.Sleep(1000);

                    messageQueue.Send(messageFlow + " | flow started"  );

                    //messageQueue.Send(messageFlow + " | started", flux[rdn].ToString());
                    System.Threading.Thread.Sleep(1000);

                    //.........................................

                    //messageFlow = i + "# Message From  Flow " + id + " Flow Id | " + id + "  | Content " + id + " | Finished";
                    //messageQueue.Send(messageFlow + " | Finished", flux[rdn].ToString());
                    messageQueue.Send(messageFlow + " | " + action[index]);
                    System.Threading.Thread.Sleep(500);


                    lstFlux.Add(messageFlow + "...");

                }
                try
                {

                    //messageQueue.Send(messageFlow);

                    lstFlux.Add(messageFlow);

                    Console.WriteLine("Message envoyé !");

                }
                catch (Exception ex)
                {

                    Console.WriteLine("Message non envoyé !" + ex.Message);

                }

            }
            catch (Exception exx)
            {
                throw exx;
            }
            finally
            {

                messageQueue.Dispose();
            }
            return lstFlux;

        }
        public static void IsStarted()
        {

            Console.WriteLine("Flow started");
        }

        public static void IsFinished()
        {
            Console.WriteLine("Flow finished ");

        }
    }
}









