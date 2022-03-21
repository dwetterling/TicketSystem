using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;
namespace TicketSystem
{
    public class EnhancementFile
    {
        public string filePath{get; set;}

        public List<Enhancement> Tickets {get; set;}
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
    

        public EnhancementFile(string EnhancementFilePath)
        {
            filePath = EnhancementFilePath;
            Tickets = new List<Enhancement>();


            try{
                StreamReader sr = new StreamReader(filePath);

                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    Enhancement Enhancement = new Enhancement();
                    string line = sr.ReadLine();

                    string[] ticketInformation = line.Split(',');
                    Enhancement.TicketID = UInt64.Parse(ticketInformation[0]);
                    Enhancement.summary = ticketInformation[1];
                    Enhancement.status = ticketInformation[2];
                    Enhancement.priority = ticketInformation[3];
                    Enhancement.submitter = ticketInformation[4];
                    Enhancement.assigned = ticketInformation[5];
                    Enhancement.watching = ticketInformation[6].Split('|').ToList();
                    Enhancement.software = ticketInformation[7];
                    Enhancement.cost = ticketInformation[8];
                    Enhancement.reason = ticketInformation[9];
                    Enhancement.estimate = ticketInformation[10];
                    Tickets.Add(Enhancement);
                }
            sr.Close();
            logger.Info("Tickets in file {Count}", Tickets.Count);
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
        }
    
    }
    public void AddTicket(Enhancement Enhancement)
        {
            try{
                Enhancement.TicketID = Tickets.Max(t => t.TicketID) + 1;
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{Enhancement.TicketID},{Enhancement.summary},{Enhancement.status},{Enhancement.priority},{Enhancement.submitter},{Enhancement.assigned},{string.Join("|", Enhancement.watching)},{Enhancement.software},{Enhancement.cost},{Enhancement.reason},{Enhancement.estimate}");
                sw.Close();
                Tickets.Add(Enhancement);
                logger.Info("Enhancement id {Id} added", Enhancement.TicketID);
                }
                catch(Exception ex)
                {
                    logger.Error(ex.Message);
                }
        }
    
}
}

    