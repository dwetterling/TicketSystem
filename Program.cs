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
            string enhancementFilePath = Directory.GetCurrentDirectory() + "\\enhancements.csv";
            string taskFilePath = Directory.GetCurrentDirectory() + "\\tasks.csv";
           
           logger.Info("Program started");

            TicketFile ticketFile = new TicketFile(ticketFilePath);
            EnhancementFile enhancementFile = new EnhancementFile(enhancementFilePath);
            TaskFile taskFile = new TaskFile(taskFilePath);
            string menuSelection = "";
            string fileSelection ="";
            do
            {
                Console.WriteLine("1) Read from file ");
                Console.WriteLine("2) Write ticket to file");
                Console.WriteLine("3) Exit application");
                menuSelection = Console.ReadLine();

                if (menuSelection == "1")
                {
                    Console.WriteLine("Please choose file to read from\n 1. Tickets\n2. Enhancements\n3.Tasks");
                    fileSelection = Console.ReadLine();
                    if (fileSelection == "1"){
                            foreach(Ticket t in ticketFile.Tickets)
                    {
                        Console.WriteLine(t.Display());
                    }
                    }
                    if (fileSelection == "2"){
                            foreach(Enhancement e in enhancementFile.Tickets)
                    {
                        
                        Console.WriteLine(e.Display());
                    }
                    }
                     if (fileSelection == "3"){
                            foreach(Task t in taskFile.Tickets)
                    {
                        Console.WriteLine(t.Display());
                    } 
                    }
                    
                }
                else if (menuSelection == "2")
                {
                  Console.WriteLine("Please choose type of ticket to add\n 1. Tickets\n2. Enhancements\n3.Tasks");
                    fileSelection = Console.ReadLine();   
                    if(fileSelection == "1"){
                    
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
                        Console.WriteLine("Enter the severity of the ticket");
                        ticket.severity = Console.ReadLine();

                        ticketFile.AddTicket(ticket);
                        
                    }
                    if(fileSelection == "2"){
                
                        //Add Enhancement
                        Enhancement enhancement = new Enhancement();
                        Console.WriteLine("Enter the enhancement summary");
                        enhancement.summary = Console.ReadLine();
                        Console.WriteLine("Enter the enhancement status");
                        enhancement.status = Console.ReadLine();
                        Console.WriteLine("Enter the enhancement priority");
                        enhancement.priority = Console.ReadLine();
                        Console.WriteLine("Enter who submitted the enhancement");
                        enhancement.submitter = Console.ReadLine();
                        Console.WriteLine("Enter who was assigned the enhancement");
                        enhancement.assigned = Console.ReadLine();

                        string watchers;
                        do{
                            //get all watching
                            Console.WriteLine("Enter who is watching the enhancement");
                            watchers = Console.ReadLine();
                            //if user enters "done" stop adding to watching
                            //maybe no one is watching the ticket
                            if (watchers != "done")
                            {
                                enhancement.watching.Add(watchers);
                            }

                        } while (watchers != "done");
                        //specify if no one is watching the ticket
                        if (enhancement.watching.Count == 0)
                        {
                            enhancement.watching.Add("(No users watching this enhancement)");
                        }
                        Console.WriteLine("Enter the software");
                        enhancement.software = Console.ReadLine();
                        Console.WriteLine("Enter the cost");
                        enhancement.cost = Console.ReadLine();
                        Console.WriteLine("Enter the reason");
                        enhancement.reason = Console.ReadLine();
                        Console.WriteLine("Enter the estimate");
                        enhancement.estimate = Console.ReadLine();

                        enhancementFile.AddTicket(enhancement);
                        
                    }
                     if(fileSelection =="3"){
                        Task task = new Task();
                        Console.WriteLine("Enter the ticket summary");
                        task.summary = Console.ReadLine();
                        Console.WriteLine("Enter the ticket status");
                        task.status = Console.ReadLine();
                        Console.WriteLine("Enter the ticket priority");
                        task.priority = Console.ReadLine();
                        Console.WriteLine("Enter who submitted the ticket");
                        task.submitter = Console.ReadLine();
                        Console.WriteLine("Enter who was assigned the ticket");
                        task.assigned = Console.ReadLine();

                        string watchers;
                        do{
                            //get all watching
                            Console.WriteLine("Enter who is watching the ticket");
                            watchers = Console.ReadLine();
                            //if user enters "done" stop adding to watching
                            //maybe no one is watching the ticket
                            if (watchers != "done")
                            {
                                task.watching.Add(watchers);
                            }

                        } while (watchers != "done");
                        //specify if no one is watching the ticket
                        if (task.watching.Count == 0)
                        {
                            task.watching.Add("(No users watching this ticket)");
                        }
                        Console.WriteLine("Enter the project name");
                        task.projectname = Console.ReadLine();
                        Console.WriteLine("Enter the due date");
                        task.duedate = Console.ReadLine();

                        taskFile.AddTicket(task);
                    } 
                    } 
             
                

            } while (menuSelection != "3");

            
            Console.ReadLine();


        }
    }
}
