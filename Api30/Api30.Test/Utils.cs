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
        public static Customer CustomerSimple = new Customer()
        {
            Name = "Client Test",
            Email = "lucas.domingues@rasystem.com.br"
        };


        public static CreditCard CardValid_4 = new CreditCard()
        {
            CardNumber = "0000000000000001",
            Holder = "Teste Holder",
            ExpirationDate = $"{DateTime.Today.Month}/{DateTime.Today.Year + 3}",
            SecurityCode = "123",
            Brand = Lib.CieloCardBrand.Visa
        };

        public static CreditCard CardUnauthorized_2 = new CreditCard()
        {
            CardNumber = "0000000000000002",
            Holder = "Teste Holder",
            ExpirationDate = $"{DateTime.Today.Month}/{DateTime.Today.Year + 3}",
            SecurityCode = "123",
            Brand = Lib.CieloCardBrand.Visa
        };
    }
}
