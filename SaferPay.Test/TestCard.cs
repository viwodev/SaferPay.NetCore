namespace SaferPay.Test;

public class TestCard
{
    public TestCard() { }
    public TestCard(string number, string cardHolder, string expire, string cvv)
    {
        this.Number = number;
        this.CardHolder = cardHolder;
        this.Expire = expire;
        this.CVV = cvv;
    }

    public TestCard(string alias, string number, string cardHolder, string expire, string cvv)
    {
        this.Alias = alias;
        this.Number = number;
        this.CardHolder = cardHolder;
        this.Expire = expire;
        this.CVV = cvv;
    }

    public string Alias { get; set; } = "Success";
    public string Number { get; set; }
    public string CardHolder { get; set; }
    public string Expire { get; set; }
    public string CVV { get; set; }

    public override string ToString()
    {
        return $"{Number} [{Alias}]";
    }
}
