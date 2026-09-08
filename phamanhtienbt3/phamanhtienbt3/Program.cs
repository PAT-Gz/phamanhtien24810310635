
using System;
using System.Collections.Generic;

namespace phamanhtienbt3
{
  

    public class DiscountCalculator
    {
        
        public decimal ApplyDiscount(decimal totalAmount)
        {
            return totalAmount * 0.95m;
        }

       
        public decimal ApplyDiscount(
            decimal totalAmount,
            double percentage)
        {
            if (percentage < 0 || percentage > 100)
            {
                throw new ArgumentException(
                    "Phan tram giam phai tu 0 den 100!"
                );
            }

            decimal discount =
                totalAmount * (decimal)(percentage / 100);

            return totalAmount - discount;
        }

       
        public decimal ApplyDiscount(
            decimal totalAmount,
            decimal fixedVoucher,
            decimal minimumOrder)
        {
            if (fixedVoucher < 0)
            {
                throw new ArgumentException(
                    "Gia tri voucher khong duoc am!"
                );
            }

            if (totalAmount >= minimumOrder)
            {
                return totalAmount - fixedVoucher;
            }

            return totalAmount;
        }
    }


    public class DeliveryService
    {
        public string OrderId { get; set; }

        public double DistanceKm { get; set; }

       
        public virtual decimal CalculateShippingFee()
        {
            return (decimal)DistanceKm * 5000m;
        }

        public DeliveryService(
            string orderId,
            double distanceKm)
        {
            OrderId = orderId;
            DistanceKm = distanceKm;
        }
    }


    public class ExpressDelivery : DeliveryService
    {
        public ExpressDelivery(
            string orderId,
            double distanceKm)
            : base(orderId, distanceKm)
        {
        }

        
        public override decimal CalculateShippingFee()
        {
            decimal basicFee =
                base.CalculateShippingFee();

            return basicFee * 1.5m + 20000m;
        }
    }


   
    public class EcoDelivery : DeliveryService
    {
        public EcoDelivery(
            string orderId,
            double distanceKm)
            : base(orderId, distanceKm)
        {
        }

       
        public override decimal CalculateShippingFee()
        {
            decimal basicFee =
                base.CalculateShippingFee();

         
            if (DistanceKm > 10)
            {
                return basicFee * 0.9m;
            }

            return basicFee;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding =
                System.Text.Encoding.UTF8;

            Console.WriteLine("==========================================");
            Console.WriteLine("     BAI TAP 3 - DA HINH TRONG C#");
            Console.WriteLine("==========================================");



            Console.WriteLine();
            Console.WriteLine("===== PHAN 1: METHOD OVERLOADING =====");

            DiscountCalculator calculator =
                new DiscountCalculator();

            Console.Write("Nhap tong gia tri don hang: ");
            decimal totalAmount =
                decimal.Parse(Console.ReadLine());

            
            decimal result1 =
                calculator.ApplyDiscount(totalAmount);

            Console.WriteLine();
            Console.WriteLine("--- Giam mac dinh 5% ---");
            Console.WriteLine(
                "Gia sau giam: " +
                result1.ToString("N0") +
                " VND"
            );


          
            Console.WriteLine();
            Console.Write("Nhap phan tram giam: ");
            double percentage =
                double.Parse(Console.ReadLine());

            decimal result2 =
                calculator.ApplyDiscount(
                    totalAmount,
                    percentage
                );

            Console.WriteLine(
                "Gia sau giam " +
                percentage +
                "%: " +
                result2.ToString("N0") +
                " VND"
            );


          
            Console.WriteLine();
            Console.Write("Nhap gia tri voucher: ");
            decimal voucher =
                decimal.Parse(Console.ReadLine());

            Console.Write("Nhap gia tri don toi thieu: ");
            decimal minimumOrder =
                decimal.Parse(Console.ReadLine());

            decimal result3 =
                calculator.ApplyDiscount(
                    totalAmount,
                    voucher,
                    minimumOrder
                );

            Console.WriteLine(
                "Gia sau ap dung voucher: " +
                result3.ToString("N0") +
                " VND"
            );



            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("===== PHAN 2: METHOD OVERRIDING =====");

            
            Console.WriteLine();
            Console.WriteLine("--- NHAP DON GIAO HOA TOC ---");

            Console.Write("Nhap ma don hang: ");
            string expressOrderId =
                Console.ReadLine();

            Console.Write("Nhap quang duong (km): ");
            double expressDistance =
                double.Parse(Console.ReadLine());

            ExpressDelivery express =
                new ExpressDelivery(
                    expressOrderId,
                    expressDistance
                );


            
            Console.WriteLine();
            Console.WriteLine("--- NHAP DON GIAO TIET KIEM ---");

            Console.Write("Nhap ma don hang: ");
            string ecoOrderId =
                Console.ReadLine();

            Console.Write("Nhap quang duong (km): ");
            double ecoDistance =
                double.Parse(Console.ReadLine());

            EcoDelivery eco =
                new EcoDelivery(
                    ecoOrderId,
                    ecoDistance
                );


           
            List<DeliveryService> deliveries =
                new List<DeliveryService>();

            deliveries.Add(express);
            deliveries.Add(eco);


            Console.WriteLine();
            Console.WriteLine("===== CHI PHI VAN CHUYEN =====");

            
            foreach (DeliveryService delivery in deliveries)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Ma don hang: " +
                    delivery.OrderId
                );

                Console.WriteLine(
                    "Loai giao hang: " +
                    delivery.GetType().Name
                );

                Console.WriteLine(
                    "Quang duong: " +
                    delivery.DistanceKm +
                    " km"
                );

                Console.WriteLine(
                    "Phi van chuyen: " +
                    delivery.CalculateShippingFee()
                        .ToString("N0") +
                    " VND"
                );
            }


            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("GHI CHU:");
            Console.WriteLine(
                "ApplyDiscount co 3 phien ban khac nhau"
            );
            Console.WriteLine(
                "=> Day la Method Overloading."
            );

            Console.WriteLine();

            Console.WriteLine(
                "CalculateShippingFee duoc override"
            );

            Console.WriteLine(
                "boi ExpressDelivery va EcoDelivery."
            );

            Console.WriteLine(
                "=> Day la Method Overriding."
            );

            Console.WriteLine(
                "=> List<DeliveryService> van goi dung"
            );

            Console.WriteLine(
                "phuong thuc cua lop con khi chay."
            );

            Console.WriteLine("==========================================");

            Console.WriteLine();
            Console.WriteLine("Nhan phim bat ky de ket thuc...");
            Console.ReadKey();
        }
    }
}

