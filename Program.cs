using System;
using System.IO;
using NLog.Web;



namespace TicketSystem
{
    class Program
    {

        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {

            string ticketFilePath = Directory.GetCurrentDirectory() + "\\tickets.csv";
           
           logger.Info("Program started");

            TicketFile ticketFile = new TicketFile(ticketFilePath);
            string menuSelection = "";
            do
            {
                Console.WriteLine("1) Read from file ");
                Console.WriteLine("2) Write ticket to file");
                Console.WriteLine("3) Exit application");
                menuSelection = Console.ReadLine();

                if (menuSelection == "1")
                {
                    foreach(Ticket t in ticketFile.Tickets)
                    {
                        Console.WriteLine(t.Display());
                    }
                }
                else if (menuSelection == "2")
                {
                    
                        //Add Ticket
                        Ticket ticket = new Ticket();
                        Console.WriteLine("Enter the ticket summary");
                        ticket.summary = Console.ReadLine();
                        Console.WriteLine("Enter the ticket status");
                        ticket.status = Console.ReadLine();
                        Console.WriteLine("Enter the ticket priority");
                        ticket.priority = Console.ReadLine();
                        Console.WriteLine("Enter who submitted the ticket");
                        ticket.submitter = Console.ReadLine();
                        Console.WriteLine("Enter who was assigned the ticket");
                        ticket.assigned = Console.ReadLine();

                        string watchers;
                        do{
                            //get all watching
                            Console.WriteLine("Enter who is watching the ticket");
                            watchers = Console.ReadLine();
                            //if user enters "done" stop adding to watching
                            //maybe no one is watching the ticket
                            if (watchers != "done")
                            {
                                ticket.watching.Add(watchers);
                            }

                        } while (watchers != "done");
                        //specify if no one is watching the ticket
                        if (ticket.watching.Count == 0)
                        {
                            ticket.watching.Add("(No users watching this ticket)");
                        }

                        ticketFile.AddTicket(ticket);
                        

                    } 
             
                

            } while (menuSelection != "3");

            
            Console.ReadLine();


        }
    }
}
