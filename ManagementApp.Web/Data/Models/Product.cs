﻿using ManagementApp.Web.Data.Enums;

namespace ManagementApp.Web.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductType ProductType { get; set; }
    }
}
