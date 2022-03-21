using System;
using System.Collections.Generic;

namespace TicketSystem
{
    public class Task
    {
        public UInt64 TicketID { get; set;}

        
        public string summary{get; set;}
        
    

        public string status {get; set;}

         public string priority {get; set;}
          public string submitter {get; set;}
           public string assigned {get; set;}

           public List<string> watching {get; set;}

           public Task()
           {
               watching = new List<string>();
           }

           public string projectname{get; set;}
           public string duedate{get; set;}
           

           public string Display()
           {
               return $"Id: {TicketID}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatching: {string.Join(", ", watching)}\nProject Name: {projectname}\nDue Date: {duedate}\n";
           }
    }

}