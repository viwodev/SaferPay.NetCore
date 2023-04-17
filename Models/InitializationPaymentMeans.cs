using System.CodeDom;

namespace SaferPay.Models
{
	public class InitializationPaymentMeans
	{
        public InitializationPaymentMeans()
        {
            
        }

        /// <summary>
        /// Card data
        /// </summary>
        public InitializationCard Card { get; set; }

        public InitializationPaymentMeans(InitializationCard card)
        {
            Card = card;
        }
        // BankAccount
        // Alias


    }
}