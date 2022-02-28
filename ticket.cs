using System;
using System.Collections.Generic;

namespace TicketSystem
{
    public class Ticket
    {
        public UInt64 TicketID { get; set;}

        string _summary;

        public string summary{get; set;}
        
    

        public string status {get; set;}

         public string priority {get; set;}
          public string submitter {get; set;}
           public string assigned {get; set;}

           public List<string> watching {get; set;}

           public Ticket()
           {
               watching = new List<string>();
           }

           public string Display()
           {
               return $"Id: {TicketID}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatching: {string.Join(", ", watching)}\n";
           }
    }

}