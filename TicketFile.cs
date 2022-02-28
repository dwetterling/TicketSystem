using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;
namespace TicketSystem
{
    public class TicketFile
    {
        public string filePath{get; set;}

        public List<Ticket> Tickets {get; set;}
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
    

        public TicketFile(string ticketFilePath)
        {
            filePath = ticketFilePath;
            Tickets = new List<Ticket>();


            try{
                StreamReader sr = new StreamReader(filePath);

                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    Ticket ticket = new Ticket();
                    string line = sr.ReadLine();

                    string[] ticketInformation = line.Split(',');
                    ticket.TicketID = UInt64.Parse(ticketInformation[0]);
                    ticket.summary = ticketInformation[1];
                    ticket.status = ticketInformation[2];
                    ticket.priority = ticketInformation[3];
                    ticket.submitter = ticketInformation[4];
                    ticket.assigned = ticketInformation[5];
                    ticket.watching = ticketInformation[6].Split('|').ToList();
                    Tickets.Add(ticket);
                }
            sr.Close();
            logger.Info("Tickets in file {Count}", Tickets.Count);
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
        }
    
    }

        public void AddTicket(Ticket ticket)
        {
            try{
                ticket.TicketID = Tickets.Max(t => t.TicketID) + 1;
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{ticket.TicketID},{ticket.summary},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigned},{string.Join("|", ticket.watching)}");
                sw.Close();
                Tickets.Add(ticket);
                logger.Info("Ticket id {Id} added", ticket.TicketID);
                }
                catch(Exception ex)
                {
                    logger.Error(ex.Message);
                }
        }
}
}