using System;
using System.Collections.Generic;

namespace TicketSystem
{
    public class Enhancement
    {
        public UInt64 TicketID { get; set;}

        
        public string summary{get; set;}
        
    

        public string status {get; set;}

         public string priority {get; set;}
          public string submitter {get; set;}
           public string assigned {get; set;}

           public List<string> watching {get; set;}

           public Enhancement()
           {
               watching = new List<string>();
           }

           public string software{get; set;}
           public string cost{get; set;}
           public string reason{get; set;}
           public string estimate{get; set;}

           public string Display()
           {
               return $"Id: {TicketID}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatching: {string.Join(", ", watching)}\nSoftware: {software}\nCost: {cost}\nReasoning: {reason}\nEstimate: {estimate}";
           }
    }

}