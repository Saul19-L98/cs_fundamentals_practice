using System;

const int threshold = 30_000;

var emailPriceChangeNotifier = new EmailPriceChangeNotifier(threshold);

var pushPriceChangeNotifier = new PushPriceChangeNotifier(threshold);

//var goldPriceReader = new GoldPriceReader(emailPriceChangeNotifier,pushPriceChangeNotifier);
var goldPriceReader = new GoldPriceReader();
goldPriceReader.AttachObserver(emailPriceChangeNotifier);
goldPriceReader.AttachObserver(pushPriceChangeNotifier);

for (int i = 0; i < 3; ++i)
{
    goldPriceReader.ReadCurrentPrice();
}

Console.WriteLine("Turning push notifications off");
goldPriceReader.DetachObserver(pushPriceChangeNotifier);
for (int i = 0; i < 3; ++i)
{
    goldPriceReader.ReadCurrentPrice();
}

Console.ReadKey();

//GoldPriceReader: 'Observable'
public class GoldPriceReader : IObservable<decimal>
{
    private int _currentGoldPrice;
    ////1. EmailPriceChangeNotifier: 'Observers'
    //private readonly EmailPriceChangeNotifier _emailPriceChangeNotifier;
    ////2. PushPriceChangeNotifier: 'Observers'
    //private readonly PushPriceChangeNotifier _pushPriceChangeNotifier;
    private readonly List<IObserver<decimal>> _observers = new();
    public void ReadCurrentPrice()
    {
        _currentGoldPrice = new Random().Next(20_000, 50_000);
        //_emailPriceChangeNotifier.Update(_currentGoldPrice);
        //_pushPriceChangeNotifier.Update(_currentGoldPrice);
        NotifyObservers();
    }

    public void AttachObserver(IObserver<decimal> observer)
    {
        _observers.Add(observer);
    }

    public void DetachObserver(IObserver<decimal> observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_currentGoldPrice);
        }
    }
}

public class EmailPriceChangeNotifier : IObserver<decimal>
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

public class PushPriceChangeNotifier : IObserver<decimal>
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

public interface IObserver<TData>
{
    void Update(TData price);
}

public interface IObservable<TData>
{
    void AttachObserver(IObserver<TData> observer);
    void DetachObserver(IObserver<TData> observer);
    void NotifyObservers();
}