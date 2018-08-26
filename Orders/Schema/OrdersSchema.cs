using System;
using System.Collections.Generic;
using System.Text;
using GraphQL;

namespace Orders.Schema
{
    public class OrdersSchema : GraphQL.Types.Schema
    {
        public OrdersSchema(OrdersQuery query, OrdersMutation ordersMutation, IDependencyResolver resolver)
        {
            Query = query;
            Mutation = ordersMutation;
            DependencyResolver = resolver;
        }
    }
}
