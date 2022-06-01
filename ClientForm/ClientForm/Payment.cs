using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientForm
{
    internal class Payment
    {
        public decimal amount { get; set; }

        public int TransmitterId { get; set; }

        public int ReceiverId { get; set; }

        public DateTime DateTime { get; set; }

        public string freeOrStructuredCommunication { get; set; }
    }
}
