using Newtonsoft.Json;

namespace SaferPay.Models
{
	public abstract class ResponseBase
	{
		public ResponseHeader ResponseHeader { get; set; }
		public override string ToString() => JsonConvert.SerializeObject( this, Formatting.Indented );
	}
}
