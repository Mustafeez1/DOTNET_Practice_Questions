using System;

class Payment
{
    public double Amount;

    public virtual void ProcessPayment()
    {
        Console.WriteLine("Payment Processing");
    }
}

class CreditCardPayment : Payment
{
    public override void ProcessPayment()
    {
        Console.WriteLine("Credit Card Payment Successful");
    }
}

class UPIPayment : Payment
{
    public override void ProcessPayment()
    {
        Console.WriteLine("UPI Payment Successful");
    }
}

class NetBankingPayment : Payment
{
    public override void ProcessPayment()
    {
        Console.WriteLine("Net Banking Payment Successful");
    }
}

class Question1
{
    static void Main()
    {
        Payment payment;

        payment = new CreditCardPayment();
        payment.ProcessPayment();

        payment = new UPIPayment();
        payment.ProcessPayment();

        payment = new NetBankingPayment();
        payment.ProcessPayment();
    }
}