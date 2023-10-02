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

public delegate void PriceRead(decimal  price);

//GoldPriceReader: 'Observable'
public class GoldPriceReader 
{
    public event PriceRead? PriceRead;
    public void ReadCurrentPrice()
    {
        var currentGoldPrice = new Random().Next(20_000, 50_000);
        OnPriceRead(currentGoldPrice);
    }

    private void OnPriceRead(decimal price)
    {
        //PriceRead(price);
        //* '?.' null-propagating operator.
        PriceRead?.Invoke(price);
    }
}

public class EmailPriceChangeNotifier 
{
    private readonly decimal _notificationThreshold;
    public EmailPriceChangeNotifier(decimal notificationThreshold)
    {
        _notificationThreshold = notificationThreshold;
    }
    public void Update(decimal price)
    {
        if (price > _notificationThreshold)
        {
            //imagine this is actually sending an email
            Console.WriteLine($"Sending an email saying that " + $"the gold price exceeded {_notificationThreshold} " + $"and is now {price}\n");
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
    public void Update(decimal price)
    {
        if (price > _notificationThreshold)
        {
            //imagine this is actually sending a push notification
            Console.WriteLine($"Sending a push notification saying that " + $"the gold price exceeded {_notificationThreshold} " + $"and is now {price}\n");
        }
    }
}

