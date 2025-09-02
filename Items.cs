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

        public string description { get; set; }

        public bool isCompleted { get; set; }

        //Konstruktor

        public override string ToString()
        {
            string status = isCompleted ? "[X] " : "[ ] ";
            return $"{status}{description}";


        }
    }
}
