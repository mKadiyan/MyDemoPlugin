using MyCard1PluginBase;
using System;

namespace VisaCardPlugin;

public class VisaCard: IMyCard1Plugin
{
    public void MakePayment()
    {
        Console.WriteLine("The payment is done by VisaMyCard1");
    }

}
