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

    public enum CieloCurrency
    {
        BRL, USD, MXN, COP, CLP, ARS, PEN, EUR, PYN, UYU, VEB, VEF, GBP
    }

    public enum CieloCountry
    {
        BRA
    }

    public enum CieloCardBrand
    {
        Visa, Master , Amex , Elo , Aura , JCB , Diners , Discover
    }
}