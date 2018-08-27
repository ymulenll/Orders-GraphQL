﻿using System;

namespace Orders.Models
{
    public class OrderEvent
    {
        public string OrderId { get; set; }
        public string Name { get; set; }
        public OrderStatuses Status { get; set; }
        public DateTime Timestamp { get; private set; }
        public string Id { get; set; }

        public OrderEvent(string orderId, string name, OrderStatuses status, DateTime timestamp)
        {
            OrderId = orderId;
            Name = name;
            Status = status;
            Timestamp = timestamp;
            Id = Guid.NewGuid().ToString();
        }
    }
}