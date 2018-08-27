using System;
using System.Collections.Generic;
using System.Text;
using GraphQL;

namespace Orders.Schema
{
    public class OrdersSchema : GraphQL.Types.Schema
    {
        public OrdersSchema(OrdersQuery query, OrdersMutation ordersMutation, OrdersSubscription ordersSubscription, IDependencyResolver resolver)
        {
            Query = query;
            Mutation = ordersMutation;
            Subscription = ordersSubscription;
            DependencyResolver = resolver;
        }
    }
}
