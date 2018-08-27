using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;
using Orders.Models;
using Orders.Services;

namespace Orders.Schema
{
    public class OrdersMutation : ObjectGraphType
    {
        public OrdersMutation(IOrderService orders)
        {
            Name = "Mutation";
            Field<OrderType>("createOrder", arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<OrderCreateInputType>>{Name = "order"}),
                resolve: context =>
                {
                    var inputOrder = context.GetArgument<OrderCreateInput>("order");
                    var newOrder = new Order(inputOrder.Name, inputOrder.Description, inputOrder.Created, inputOrder.CustomerId, Guid.NewGuid().ToString());

                    return orders.CreateAsync(newOrder);
                });

            FieldAsync<OrderType>("startOrder", arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>>{Name = "orderId"}),
                resolve: async context =>
                {
                    var orderId = context.GetArgument<string>("orderId");

                    var order = await orders.GetOrderByIdAsync(orderId);
                    var newOrderEvent = new OrderEvent(order.Id, order.Name, OrderStatuses.PROCESSING, DateTime.Now);
                    orderEvents.AddEvent(newOrderEvent);

                    return await context.TryAsyncResolve(async c => await orders.StartAsync(orderId));
                });
        }
    }
}
