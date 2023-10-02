using System;
using System.Diagnostics.Tracing;

const int threshold = 30_000;

var emailPriceChangeNotifier = new EmailPriceChangeNotifier(threshold);

var pushPriceChangeNotifier = new PushPriceChangeNotifier(threshold);

var goldPriceReader = new GoldPriceReader();
goldPriceReader.PriceRead += emailPriceChangeNotifier.Update;
goldPriceReader.PriceRead += pushPriceChangeNotifier.Update;

for (int i = 0; i < 3; i++)
{
    goldPriceReader.ReadCurrentPrice();
}

Console.ReadKey();

//public delegate void PriceRead(decimal price);

public class PriceReadEventArgs : EventArgs
{
    public decimal Price { get; }
    public PriceReadEventArgs(decimal price)
    {
        Price = price;
    }
}

//GoldPriceReader: 'Observable'
public class GoldPriceReader
{
    public event EventHandler<PriceReadEventArgs>? PriceRead;
    public void ReadCurrentPrice()
    {
        var currentGoldPrice = new Random().Next(20_000, 50_000);
        OnPriceRead(currentGoldPrice);
    }

    private void OnPriceRead(decimal price)
    {
        // Arguments: 1.'this': current instance of the GoldPriceReader class as it is the sender of the event 2. is the priceReadEventArgs object carrying the price.
        PriceRead?.Invoke(this,new PriceReadEventArgs(price));
    }
}

public class EmailPriceChangeNotifier
{
    private readonly decimal _notificationThreshold;
    public EmailPriceChangeNotifier(decimal notificationThreshold)
    {
        _notificationThreshold = notificationThreshold;
    }
    public void Update(object? sender, PriceReadEventArgs eventArgs)
    {
        if (eventArgs.Price > _notificationThreshold)
        {
            //imagine this is actually sending an email
            Console.WriteLine($"Sending an email saying that " + $"the gold price exceeded {_notificationThreshold} " + $"and is now {eventArgs.Price}\n");
        }
    }
}

public class PushPriceChangeNotifier
{
    private readonly decimal _notificationThreshold;
    public PushPriceChangeNotifier(decimal notificationThreshold)
    {
        _notificationThreshold = notificationThreshold;
    }
    public void Update(object? sender, PriceReadEventArgs eventArgs)
    {
        if (eventArgs.Price > _notificationThreshold)
        {
            //imagine this is actually sending a push notification
            Console.WriteLine($"Sending a push notification saying that " + $"the gold price exceeded {_notificationThreshold} " + $"and is now {eventArgs.Price}\n");
        }
    }
}

