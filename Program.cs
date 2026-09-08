
using System;

namespace phamanhtienbt1
{
   

    public interface IPayable
    {
        bool ProcessPayment(decimal amount);
    }


  

    public interface IRefundable
    {
        bool ProcessRefund(
            decimal amount,
            string reason
        );
    }


   

    public abstract class PaymentGateway
    {
        
        public string TransactionId { get; init; }


        public DateTime CreationDate { get; init; }

        public string Status { get; protected set; }

        
        protected PaymentGateway(string transactionId)
        {
            TransactionId = transactionId;
            CreationDate = DateTime.Now;
            Status = "Pending";
        }

       
        public abstract void ValidateConnection();

      
        public virtual void LogTransaction(string message)
        {
            Console.WriteLine(
                "[LOG] Giao dich " +
                TransactionId +
                ": " +
                message
            );
        }
    }


    public class MomoPayment :
        PaymentGateway,
        IPayable,
        IRefundable
    {
       
        public string PhoneNumber { get; set; }

  
        public MomoPayment(
            string transactionId,
            string phoneNumber)
            : base(transactionId)
        {
            PhoneNumber = phoneNumber;
        }

        public override void ValidateConnection()
        {
            Console.WriteLine(
                "Dang kiem tra ket noi API MoMo..."
            );

            Console.WriteLine(
                "Ket noi API MoMo thanh cong!"
            );
        }


        public bool ProcessPayment(decimal amount)
        {
     
            if (amount <= 0)
            {
                Console.WriteLine(
                    "Loi: So tien thanh toan phai > 0!"
                );

                return false;
            }

     
            if (string.IsNullOrWhiteSpace(PhoneNumber))
            {
                Console.WriteLine(
                    "Loi: So dien thoai khong hop le!"
                );

                return false;
            }

      
            Status = "Success";

            Console.WriteLine();
            Console.WriteLine(
                "Thanh toan MoMo thanh cong!"
            );

            Console.WriteLine(
                "So tien: " +
                amount.ToString("N0") +
                " VND"
            );

            LogTransaction(
                "Thanh toan " +
                amount.ToString("N0") +
                " VND thanh cong."
            );

            return true;
        }


     
        public bool ProcessRefund(
            decimal amount,
            string reason)
        {
           
            if (amount <= 0)
            {
                Console.WriteLine(
                    "Loi: So tien hoan phai > 0!"
                );

                return false;
            }

            if (string.IsNullOrWhiteSpace(reason))
            {
                Console.WriteLine(
                    "Loi: Ly do hoan tien khong duoc de trong!"
                );

                return false;
            }

           
            Status = "Refunded";

            Console.WriteLine();
            Console.WriteLine(
                "Hoan tien MoMo thanh cong!"
            );

            Console.WriteLine(
                "So tien hoan: " +
                amount.ToString("N0") +
                " VND"
            );

            Console.WriteLine(
                "Ly do: " +
                reason
            );

            LogTransaction(
                "Hoan tien " +
                amount.ToString("N0") +
                " VND. Ly do: " +
                reason
            );

            return true;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding =
                System.Text.Encoding.UTF8;

            Console.WriteLine("==========================================");
            Console.WriteLine("       BAI TAP 4 - CONG THANH TOAN");
            Console.WriteLine("==========================================");


            Console.WriteLine();
            Console.WriteLine("----- NHAP THONG TIN GIAO DICH -----");

            Console.Write("Nhap ma giao dich: ");
            string transactionId =
                Console.ReadLine();

            Console.Write("Nhap so dien thoai MoMo: ");
            string phoneNumber =
                Console.ReadLine();


            
            MomoPayment momo =
                new MomoPayment(
                    transactionId,
                    phoneNumber
                );



            Console.WriteLine();
            Console.WriteLine("===== THONG TIN GIAO DICH =====");

            Console.WriteLine(
                "Ma giao dich: " +
                momo.TransactionId
            );

            Console.WriteLine(
                "So dien thoai: " +
                momo.PhoneNumber
            );

            Console.WriteLine(
                "Ngay tao: " +
                momo.CreationDate
            );

            Console.WriteLine(
                "Trang thai: " +
                momo.Status
            );


          
            Console.WriteLine();
            Console.WriteLine("===== KIEM TRA KET NOI =====");

            momo.ValidateConnection();



            Console.WriteLine();
            Console.WriteLine("===== THANH TOAN =====");

            Console.Write(
                "Nhap so tien thanh toan: "
            );

            decimal paymentAmount =
                decimal.Parse(Console.ReadLine());

            IPayable payable = momo;

            bool paymentResult =
                payable.ProcessPayment(paymentAmount);

            if (paymentResult)
            {
                Console.WriteLine(
                    "Ket qua: Thanh toan thanh cong!"
                );
            }
            else
            {
                Console.WriteLine(
                    "Ket qua: Thanh toan that bai!"
                );
            }


            Console.WriteLine();
            Console.WriteLine(
                "Trang thai hien tai: " +
                momo.Status
            );


           
            Console.WriteLine();
            Console.WriteLine("===== HOAN TIEN =====");

            Console.Write(
                "Nhap so tien muon hoan: "
            );

            decimal refundAmount =
                decimal.Parse(Console.ReadLine());

            Console.Write(
                "Nhap ly do hoan tien: "
            );

            string refundReason =
                Console.ReadLine();

            
            IRefundable refundable = momo;

            bool refundResult =
                refundable.ProcessRefund(
                    refundAmount,
                    refundReason
                );

            if (refundResult)
            {
                Console.WriteLine(
                    "Ket qua: Hoan tien thanh cong!"
                );
            }
            else
            {
                Console.WriteLine(
                    "Ket qua: Hoan tien that bai!"
                );
            }


            
            Console.WriteLine();
            Console.WriteLine(
                "Trang thai cuoi cung: " +
                momo.Status
            );

            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("GHI CHU:");
            Console.WriteLine(
                "PaymentGateway la Abstract Class."
            );

            Console.WriteLine(
                "MomoPayment la lop con cua PaymentGateway."
            );

            Console.WriteLine(
                "MomoPayment implements IPayable va IRefundable."
            );

            Console.WriteLine(
                "IPayable dung cho hanh vi thanh toan."
            );

            Console.WriteLine(
                "IRefundable dung cho hanh vi hoan tien."
            );

            Console.WriteLine(
                "Mot lop co the implement nhieu Interface."
            );

            Console.WriteLine("==========================================");

            Console.WriteLine();
            Console.WriteLine("Nhan phim bat ky de ket thuc...");
            Console.ReadKey();
        }
    }
}

