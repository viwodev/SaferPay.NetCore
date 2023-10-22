using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaferPay.Models.Core
{
    public class CaptureReference
    {

        public CaptureReference()
        {
            
        }

        public CaptureReference(string captureId)
        {
            this.CaptureId = captureId;
        }

        public string CaptureId { get; set; }

        public string TransactionId { get; set; }

        public string OrderId { get; set; }

        public string OrderPartId { get; set; }
    }
}
