using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*namespace phamanhtienbt1
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}*/


namespace phamanhtienbt1
{
    public class BankAccount
    {
        private static long _nextAccountNumber = 1000000001;

        public long AccountNumber { get; private set; }

        private string _accountHolder;

        public string AccountHolder
        {
            get { return _accountHolder; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        "Ten chu tai khoan khong duoc de trong!"
                    );
                }

                _accountHolder = value;
            }
        }

        private decimal _balance;

        public decimal Balance
        {
            get { return _balance; }
        }

        public BankAccount(string accountHolder, decimal initialBalance)
        {
            AccountHolder = accountHolder;

            if (initialBalance < 50000)
            {
                throw new ArgumentException(
                    "So du ban dau phai tu 50.000 VND tro len!"
                );
            }

            AccountNumber = _nextAccountNumber;
            _nextAccountNumber++;

            _balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(
                    "So tien nap phai lon hon 0!"
                );
            }

            _balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(
                    "So tien rut phai lon hon 0!"
                );
            }

            if (_balance - amount < 50000)
            {
                return false;
            }

            _balance -= amount;
            return true;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("So tai khoan: " + AccountNumber);
            Console.WriteLine("Chu tai khoan: " + AccountHolder);
            Console.WriteLine("So du: " + Balance.ToString("N0") + " VND");
            Console.WriteLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
             
                BankAccount account1 =
                    new BankAccount("Nguyen Van A", 1000000);


                BankAccount account2 =
                    new BankAccount("Tran Thi B", 2000000);

                Console.WriteLine("===== THONG TIN BAN DAU =====");

                account1.DisplayInfo();
                account2.DisplayInfo();

                Console.WriteLine("===== NAP TIEN =====");

                account1.Deposit(500000);

                Console.WriteLine("Da nap 500.000 VND vao tai khoan 1.");
                account1.DisplayInfo();

           
                Console.WriteLine("===== RUT TIEN =====");

                bool result = account1.Withdraw(300000);

                if (result)
                {
                    Console.WriteLine("Rut tien thanh cong!");
                }
                else
                {
                    Console.WriteLine("Rut tien that bai!");
                }

                account1.DisplayInfo();

              
                Console.WriteLine("===== RUT TIEN QUA MUC =====");

                result = account1.Withdraw(2000000);

                if (result)
                {
                    Console.WriteLine("Rut tien thanh cong!");
                }
                else
                {
                    Console.WriteLine(
                        "Rut tien that bai: So du sau khi rut phai >= 50.000 VND!"
                    );
                }

                account1.DisplayInfo();

               
                Console.WriteLine("===== KIEM TRA LOI =====");

                BankAccount account3 =
                    new BankAccount("Le Van C", 30000);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Nhan phim bat ky de ket thuc...");
            Console.ReadKey();
        }
    }
}

