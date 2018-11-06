using System; 

namespace DecoratorExample
{
    public class Order
    {
        public Guid OrderId;

        public DateTime CreateDateTime;

        public DateTime? CompletedDateTime;

        public double TotalAmount;
    }
}
