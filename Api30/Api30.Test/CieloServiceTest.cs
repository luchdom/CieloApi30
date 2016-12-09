using Api30.Entities;
using Api30.Entities.Request;
using Api30.Lib;
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
        [TestMethod()]
        public void AuthorizeSimpleSaleTest()
        {
            var service = new CieloEcommerceService(Merchant, Environment);
            try
            {
                var sale = Utils.SaleSimple;
                sale.Payment.CreditCard = Utils.CardValid_4;
                var task = service.CreateSaleAsync(sale);
                task.Wait();
                var saleResponse = task.Result;
                Assert.AreEqual(saleResponse.Payment.ReturnCode, "4");
                Assert.AreEqual(saleResponse.Payment.Status, CieloPaymentStatus.Authorized);
            }
            catch (CieloRequestException ex)
            {
                Assert.Fail(ex.CieloError.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void CaptureSaleTest()
        {
            var service = new CieloEcommerceService(Merchant, Environment);
            try
            {
                var sale = Utils.SaleSimple;
                sale.Payment.CreditCard = Utils.CardValid_4;
                var task = service.CreateSaleAsync(sale);
                task.Wait();
                var saleResponse = task.Result;
                var paymentId = saleResponse.Payment.PaymentId;
                var taskCapture = service.CaptureSaleAsync(paymentId);
                taskCapture.Wait();
                var saleResponseCaptured = taskCapture.Result;
                //Assert.AreEqual(saleResponse.Payment.Capture, true);//Capture não vem na resposta. Default =>"false"
                Assert.AreEqual(saleResponseCaptured.Payment.Status, CieloPaymentStatus.PaymentConfirmed);
            }
            catch (CieloRequestException ex)
            {
                Assert.Fail(ex.CieloError.Message);
            }
        }

        [TestMethod()]
        public void CancelSaleTest()
        {
            var service = new CieloEcommerceService(Merchant, Environment);
            try
            {
                var sale = Utils.SaleSimple;
                sale.Payment.CreditCard = Utils.CardValid_4;
                var task = service.CreateSaleAsync(sale);
                task.Wait();
                var saleResponse = task.Result;
                var paymentId = saleResponse.Payment.PaymentId;
                var taskCancel = service.CancelSaleAsync(paymentId);
                taskCancel.Wait();
                var saleResponseCanceled = taskCancel.Result;
                Assert.AreEqual(saleResponseCanceled.Payment.Status, CieloPaymentStatus.Voided);
            }
            catch (CieloRequestException ex)
            {
                Assert.Fail(ex.CieloError.Message);
            }
        }


        [TestMethod()]
        public void QuerySaleTest()
        {
            var service = new CieloEcommerceService(Merchant, Environment);
            try
            {
                var sale = Utils.SaleSimple;
                sale.Payment.CreditCard = Utils.CardValid_4;
                var task = service.CreateSaleAsync(sale);
                task.Wait();
                var saleResponse = task.Result;
                var paymentId = saleResponse.Payment.PaymentId;
                var taskCapture = service.CaptureSaleAsync(paymentId);
                taskCapture.Wait();
                var saleResponseCaptured = taskCapture.Result;

                var taskQuerySale = service.QuerySaleAsync(paymentId);
                taskQuerySale.Wait();
                var saleQueried = taskQuerySale.Result;
                Assert.AreEqual(saleQueried.Payment.Status, CieloPaymentStatus.PaymentConfirmed);
            }
            catch (CieloRequestException ex)
            {
                Assert.Fail(ex.CieloError.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void UnauthorizedCardTest()
        {
            var service = new CieloEcommerceService(Merchant, Environment);
            try
            {
                var sale = Utils.SaleSimple;
                sale.Payment.CreditCard = Utils.CardUnauthorized_2;
                var task = service.CreateSaleAsync(sale);
                task.Wait();
                var saleResponse = task.Result;
                Assert.AreEqual(saleResponse.Payment.ReturnCode, "2");
                Assert.AreEqual(saleResponse.Payment.Status, CieloPaymentStatus.Denied);
            }
            catch (CieloRequestException ex)
            {
                Assert.Fail(ex.CieloError.Message);
            }
        }

       
    }
}