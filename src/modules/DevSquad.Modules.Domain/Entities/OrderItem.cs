﻿using Flunt.Notifications;
using System;

namespace DevSquad.Modules.Domain.Enums
{
    public class OrderItem : Notifiable, IEntity
    {
        public OrderItem(Product product, int quantity)
        {
            Id = Guid.NewGuid();
            Product = product;
            Quantity = quantity;

            if (product.StockQuantity < quantity)
            {
                AddNotification("Quantidade", "Produto sem estoque");
            }            
        }
        public Guid Id { get; private set; }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}
