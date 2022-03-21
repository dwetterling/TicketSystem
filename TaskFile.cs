using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;
namespace TicketSystem
{
    public class TaskFile
    {
        public string filePath{get; set;}

        public List<Task> Tickets {get; set;}
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
    

        public TaskFile(string taskFilePath)
        {
            filePath = taskFilePath;
            Tickets = new List<Task>();


            try{
                StreamReader sr = new StreamReader(filePath);

                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    Task Task = new Task();
                    string line = sr.ReadLine();

                    string[] ticketInformation = line.Split(',');
                    Task.TicketID = UInt64.Parse(ticketInformation[0]);
                    Task.summary = ticketInformation[1];
                    Task.status = ticketInformation[2];
                    Task.priority = ticketInformation[3];
                    Task.submitter = ticketInformation[4];
                    Task.assigned = ticketInformation[5];
                    Task.watching = ticketInformation[6].Split('|').ToList();
                    Task.projectname = ticketInformation[7];
                    Task.duedate = ticketInformation[8];
                    
                    Tickets.Add(Task);
                }
            sr.Close();
            logger.Info("Tickets in file {Count}", Tickets.Count);
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
        }
    
    }
    public void AddTicket(Task Task)
        {
            try{
                Task.TicketID = Tickets.Max(t => t.TicketID) + 1;
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{Task.TicketID},{Task.summary},{Task.status},{Task.priority},{Task.submitter},{Task.assigned},{string.Join("|", Task.watching)},{Task.projectname},{Task.duedate}");
                sw.Close();
                Tickets.Add(Task);
                logger.Info("Task id {Id} added", Task.TicketID);
                }
                catch(Exception ex)
                {
                    logger.Error(ex.Message);
                }
        }
    
}
}

    