
using GraphQL.Types;

namespace Orders.Schema
{
    public class OrderStatusesEnum : EnumerationGraphType
    {
        public OrderStatusesEnum()
        {
            Name = "OrderStatuses";
            AddValue("CREATED", "Order was created", 2);
            AddValue("PROCESSING", "Order is being processed", 4);
            AddValue("COMPLETED", "Order is being completed", 8);
            AddValue("CANCELED", "Order was cancelled", 16);
            AddValue("CLOSED", "Order was closed", 16);
        }
    }
}
