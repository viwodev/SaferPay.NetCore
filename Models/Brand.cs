namespace SaferPay.Models
{
	public class Brand
	{

        /// <summary>
        /// alphanumeric id of the payment method / brand<br/><br/>
        /// <i>Possible values: ACCOUNTTOACCOUNT, ALIPAY, AMEX, BANCONTACT, BONUS, DINERS, DIRECTDEBIT, EPRZELEWY, EPS, GIROPAY, IDEAL, INVOICE, JCB, KLARNA, MAESTRO, MASTERCARD, MYONE, PAYCONIQ, PAYDIREKT, PAYPAL, POSTCARD, POSTFINANCE, SOFORT, TWINT, UNIONPAY, VISA, WLCRYPTOPAYMENTS.</i>
        /// </summary>
        public PaymentMethodTypes PaymentMethod { get; set; }

        /// <summary>
        /// Name of the Brand (Visa, Mastercard, an so on – might change over time, only use for display, never for parsing). Only use it for display, never for parsing and/or mapping! Use PaymentMethod instead.<br/><br/>
        /// <i>Example: SaferpayTestCard</i><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
		public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name} ({PaymentMethod.ToString()})";
        }

    }

    public enum PaymentMethodTypes
    {
        ACCOUNTTOACCOUNT, 
        ALIPAY, 
        AMEX, 
        BANCONTACT, 
        BONUS, 
        DINERS, 
        DIRECTDEBIT, 
        EPRZELEWY, 
        EPS, 
        GIROPAY, 
        IDEAL, 
        INVOICE, 
        JCB, 
        KLARNA, 
        MAESTRO, 
        MASTERCARD, 
        MYONE, 
        PAYCONIQ, 
        PAYDIREKT, 
        PAYPAL, 
        POSTCARD, 
        POSTFINANCE, 
        SOFORT, 
        TWINT, 
        UNIONPAY, 
        VISA, 
        WLCRYPTOPAYMENTS
    }
}