﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SINAC.Capacitacion.Curso1.API.Models
{
    public partial class Agents
    {
        public Agents()
        {
            Customer = new HashSet<Customer>();
            Orders = new HashSet<Orders>();
        }

        public string AgentCode { get; set; }
        public string AgentName { get; set; }
        public string WorkingArea { get; set; }
        public decimal? Commission { get; set; }
        public string PhoneNo { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}