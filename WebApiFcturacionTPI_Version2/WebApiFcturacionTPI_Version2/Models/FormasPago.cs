﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WebApiFcturacionTPI.Models;

public partial class FormasPago
{
    public int IdFormaPago { get; set; }

    public string Nombre { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}