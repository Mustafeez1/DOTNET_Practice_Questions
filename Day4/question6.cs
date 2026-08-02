using System;
using System.Collections.Generic;

namespace Banking
{
    interface ITransaction
    {
        void Process();
        void Rollback();
    }

    sealed class Deposit : ITransaction
    {
        public double Amount { get; set; }

        public void Process()
        {
            Console.WriteLine("Deposit Successful : ₹" + Amount);
        }

        public void Rollback()
        {
            Console.WriteLine("Deposit Rollback : ₹" + Amount);
        }
    }

    sealed class Withdraw : ITransaction
    {
        public double Amount { get; set; }

        public void Process()
        {
            Console.WriteLine("Withdraw Successful : ₹" + Amount);
        }

        public void Rollback()
        {
            Console.WriteLine("Withdraw Rollback : ₹" + Amount);
        }
    }

    sealed class Transfer : ITransaction
    {
        public double Amount { get; set; }

        public void Process()
        {
            Console.WriteLine("Transfer Successful : ₹" + Amount);
        }

        public void Rollback()
        {
            Console.WriteLine("Transfer Rollback : ₹" + Amount);
        }
    }

    class TransactionManager
    {
        private List<ITransaction> history = new List<ITransaction>();

        public void AddTransaction(ITransaction transaction)
        {
            transaction.Process();
            history.Add(transaction);
        }

        public void ShowHistory()
        {
            Console.WriteLine();
            Console.WriteLine("Transaction History");

            foreach (ITransaction item in history)
            {
                Console.WriteLine(item.GetType().Name);
            }
        }

        public void UndoLastTransaction()
        {
            if (history.Count > 0)
            {
                ITransaction last = history[history.Count - 1];

                Console.WriteLine();
                Console.WriteLine("Undo Last Transaction");

                last.Rollback();

                history.RemoveAt(history.Count - 1);
            }
            else
            {
                Console.WriteLine("No Transaction Found");
            }
        }
    }

    class question6
    {
        static void Main(string[] args)
        {
            TransactionManager manager = new TransactionManager();

            Deposit d = new Deposit();
            d.Amount = 5000;

            Withdraw w = new Withdraw();
            w.Amount = 2000;

            Transfer t = new Transfer();
            t.Amount = 8000;

            manager.AddTransaction(d);

            manager.AddTransaction(w);

            manager.AddTransaction(t);

            manager.ShowHistory();

            manager.UndoLastTransaction();

            manager.ShowHistory();
        }
    }
}