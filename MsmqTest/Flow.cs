using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;


namespace MsmqTest
{
    public class Flow
    {
        public Guid FlowId { get; set; }
        public string Name { get; set; }
        public bool IsAutomatic { get; set; }
        public string FlowDescription { get; set; }

        public Flow()

        {
        }

        public Flow(Guid Fid, string Fname, bool Fauto, string Fdes)
        {
            Guid FlowId = Guid.NewGuid();
            //Flow_id = Fid;
            FlowDescription = Fdes;
            Name = Fname;
            IsAutomatic = Fauto;
        }


    }
}
