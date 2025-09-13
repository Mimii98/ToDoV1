using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_Liste
{
    internal class Items
    {
        //Eigenschaften 

        public int id  { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        

        public override string ToString() 
        {
            string status = IsCompleted ? "[X] " : "[ ] ";
            return $"{status}{Description}";


        }
    }
}
