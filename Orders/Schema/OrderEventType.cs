using GraphQL.Types;
using Orders.Models;

namespace Orders.Schema
{
    public class OrderEventType : ObjectGraphType<OrderEvent>
    {
        public OrderEventType()
        {
            Field(o => o.Name);
            Field(o => o.OrderId);
            Field(o => o.Id);
            Field(o => o.Timestamp);
            Field<OrderStatusesEnum>("status");
        }
    }
}
