﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApiFcturacionTPI.Models;

public partial class Articulo
{
    public int Idarticulo { get; set; }

    public int Precio { get; set; }

    public string Nombre { get; set; }

    public string Estado { get; set; }

    [JsonIgnore]
    public virtual ICollection<Detallefactura> Detallefacturas { get; set; } = new List<Detallefactura>();
}