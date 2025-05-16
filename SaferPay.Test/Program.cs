using SaferPay.Test;
using System.Drawing;
using Console = Colorful.Console;

Console.WriteAsciiStyled("SaferPay Test Console", new Colorful.StyleSheet(Color.Orange));
Console.WriteLine("Json Api Version: 1.46", System.Drawing.Color.OrangeRed);
Console.WriteLine("By Viwo Dev");
Console.WriteLine("https://github.com/viwodev/SaferPay.NetCore");
Console.WriteLine();
Console.WriteLine();
Helpers.CreateClient();
WebHelper.InitWeb(null);
Helpers.PrintMenu(false);

while (!Helpers.ExitConsole)
{
    System.Threading.Thread.Sleep(10);
}