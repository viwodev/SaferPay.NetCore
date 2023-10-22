using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction
{
    public class AssertCaptureRequest : RequestBase
    {
        public AssertCaptureRequest() { }

        public AssertCaptureRequest(string captureId)
        {
            this.CaptureReference = new CaptureReference(captureId);
        }

        public CaptureReference CaptureReference { get; set; }
    }
}
