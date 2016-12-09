namespace Api30.Lib
{
    public enum EnvironmentType
    {
        Sandbox,
        Production
    }

    public enum HttpMethodType
    {
        GET, POST, PUT
    }

    public enum Provider
    {
        Bradesco, BancoDoBrasil, Simulado
    }

    public enum CieloPaymentType
    {
        CreditCard, DebitCard, ElectronicTransfer, Boleto
    }

    public enum CieloPaymentStatus
    {
        NotFinished = 0, Authorized = 1, PaymentConfirmed = 2,
        Denied = 3, Voided = 10, Refunded = 11, Pending = 12,
        Aborted = 13, Scheduled = 20
    }

    public enum CieloCurrency
    {
        BRL, USD, MXN, COP, CLP, ARS, PEN, EUR, PYN, UYU, VEB, VEF, GBP
    }

    public enum CieloCountry
    {
        BRA
    }

    //public enum CieloCardBrand
    //{
    //    Visa, Master , Amex , Elo , Aura , JCB , Diners , Discover
    //}
}