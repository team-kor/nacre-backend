namespace Enum.AvailableEnum
{
    public enum OrderStatus
    {
        NotSpecified = 0,
        Pending = 1,
        InProgress = 2,
        Completed = 3,
        Deleted = 4
    }

    public enum PaymentType
    {
        NotSpecified = 0,
        CreditCard = 1,
        Cash = 2
    }

    public enum PaymentStatus
    {
        NotSpecified = 0,
        PendingPayment = 1,
        PaymentReceived = 2
    }

    public enum ProductGroupType
    {
        NotSpecified = 0,
        SunScreen = 1,
        FaceMask = 2,
        Cleanser = 3
    }

    public enum ProductStatus
    {
        NotSpecified = 0,
        Discontinued = 0,
        Active = 0
    }

    public enum CustomerContactPreference
    {
        NotSpecified = 0,
        Phone = 1,
        Email = 2
    }
}