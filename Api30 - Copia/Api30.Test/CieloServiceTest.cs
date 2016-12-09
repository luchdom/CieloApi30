using Api30.Entities;
using Api30.Entities.Request;
using Api30.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Api30.Test
{
    [TestClass()]
    public class CieloServiceTest
    {
        //public string MerchantKey = "BHFSMYZBPJSAKXNVVYKRQVDXYHUFCLXHIZUEBSEO";
        //public string MerchantId = "c58520e9-d7cf-4e80-abe8-1e1c3a53e7fa";

        public Merchant Merchant = new Merchant("c58520e9-d7cf-4e80-abe8-1e1c3a53e7fa","BHFSMYZBPJSAKXNVVYKRQVDXYHUFCLXHIZUEBSEO");
        public Environment Environment = Environment.Sandbox();
        //public Merchan
        [TestMethod()]
        public void CreateSimpleSaleTest()
        {
            var service = new CieloEcommerceService(Merchant, Environment);
            try
            {
                var orderId = Guid.NewGuid().ToString();
                var task = service.CreateSale(new Sale()
                {
                    MerchantOrderId = orderId,
                    Customer = Utils.CustomerSimple,
                    Payment = new Payment()
                    {
                        Type = Lib.CieloPaymentType.CreditCard,
                        Amount = 1.00m,
                        Installments = 1,
                        CreditCard = Utils.CardValid_4
                    }
                });
                task.Wait();
                var saleResponse = task.Result;
                Assert.AreEqual(saleResponse.Payment.ReturnCode, "4");
            }
            catch(CieloRequestException ex)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void UnauthorizedCardTest()
        {
            var service = new CieloEcommerceService(Merchant, Environment);
            try
            {
                var orderId = Guid.NewGuid().ToString();
                var task = service.CreateSale(new Sale()
                {
                    MerchantOrderId = orderId,
                    Customer = Utils.CustomerSimple,
                    Payment = new Payment()
                    {
                        Type = Lib.CieloPaymentType.CreditCard,
                        Amount = 1.00m,
                        Installments = 1,
                        CreditCard = Utils.CardUnauthorized_2
                    }
                });
                task.Wait();
                var saleResponse = task.Result;
                Assert.AreEqual(saleResponse.Payment.ReturnCode, "4");
            }
            catch (CieloRequestException ex)
            {
                Assert.Fail();
            }
        }
    }
}