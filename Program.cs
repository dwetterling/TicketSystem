using System;
using System.IO;


namespace TicketSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            
            string menuSelection = "";
            do
            {
                Console.WriteLine("1) Read from file ");
                Console.WriteLine("2) Write ticket to file");
                Console.WriteLine("3) Exit application");
                menuSelection = Console.ReadLine();

                if (menuSelection == "1")
                {
                    if (File.Exists("tickets.csv"))
                    {
                        StreamReader sr = new StreamReader("tickets.csv");

                        while (!sr.EndOfStream)
                        {
                            
                            Console.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned, Watching");
                            String ticket = System.IO.File.ReadAllText("tickets.csv");
                            Console.WriteLine(ticket);
                            break;

                        }

                        sr.Close();

                    }
                }
                else if (menuSelection == "2")
                {
                    StreamWriter sw = new StreamWriter("tickets.csv", append:true);
                    string moreTickets = "";
                    do
                    {
                        Console.WriteLine("Enter the ticket ID");
                        string ticketId = Console.ReadLine();
                        Console.WriteLine("Enter the ticket summary");
                        string summary = Console.ReadLine();
                        Console.WriteLine("Enter the ticket status");
                        string status = Console.ReadLine();
                        Console.WriteLine("Enter the ticket priority");
                        string priority = Console.ReadLine();
                        Console.WriteLine("Enter who submitted the ticket");
                        string submitter = Console.ReadLine();
                        Console.WriteLine("Enter who was assigned the ticket");
                        string assigned = Console.ReadLine();
                        Console.WriteLine("Enter who is watching the ticket");
                        string watching = Console.ReadLine();

                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", ticketId, summary, status, priority, submitter, assigned, watching);

                        Console.WriteLine("Do you want to enter another ticket (y/n)?");
                        moreTickets = Console.ReadLine();

                    } while (moreTickets.ToLower() == "y");
                    sw.Close();
                }

            } while (menuSelection != "3");

            
            Console.ReadLine();


        }
    }
}
