using Api30.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api30.Test
{
    public class Utils
    {
        public static Customer CustomerSimple = new Customer("Client Test")
        {
            Email = "lucas.domingues@rasystem.com.br"
        };

        public static Sale SaleSimple = new Sale(Guid.NewGuid().ToString())
        {
            Customer = Utils.CustomerSimple,
            Payment = new Payment(Lib.CieloPaymentType.CreditCard, 1.00m)
            {
                CreditCard = CardValid_4
            }
        };


        public static CreditCard CardValid_4 = new CreditCard("Teste Holder","0000000000000001", $"{DateTime.Today.Month}/{DateTime.Today.Year + 3}",
            "123", "Visa");

        public static CreditCard CardUnauthorized_2 = new CreditCard("Teste Holder","0000000000000002", $"{DateTime.Today.Month}/{DateTime.Today.Year + 3}",
            "123", "Visa");
    }
}
