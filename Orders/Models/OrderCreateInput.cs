﻿
using System;

namespace Orders.Models
{
    public class OrderCreateInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; private set; }
        public int CustomerId { get; set; }
    }
}
