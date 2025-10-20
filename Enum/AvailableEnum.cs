namespace Enum.AvailableEnum
{
    public enum OrderStatus
    {
        NotSpecified = 0,
        Pending = 1,
        InProgress = 2,
        Completed = 3
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
}