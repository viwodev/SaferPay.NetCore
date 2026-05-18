using System.Globalization;

namespace SaferPay;

public struct CreditCardExpiration
{
    private int _year;
    private int _month;

    private static int NormalizeYear(int year) => year % 100;

    public CreditCardExpiration(int year, int month)
    {
        _year = NormalizeYear(year);
        _month = month;
    }

    public int Year
    {
        get => _year;
        set => _year = NormalizeYear(value);
    }

    public int Month
    {
        get => _month;
        set => _month = value;
    }

    public override string ToString()
    {
        return _month.ToString("D2", CultureInfo.InvariantCulture)
             + _year.ToString("D2", CultureInfo.InvariantCulture);
    }

    public static CreditCardExpiration Parse(string text)
    {
        text = new string(text.Where(char.IsNumber).ToArray());

        var month = int.Parse(text.Substring(0, 2), CultureInfo.InvariantCulture);
        var year = int.Parse(text.Substring(2), CultureInfo.InvariantCulture);

        return new CreditCardExpiration(year, month);
    }
}