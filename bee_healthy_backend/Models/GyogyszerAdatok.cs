﻿using System;
using System.Collections.Generic;

namespace bee_healthy_backend.Models;

public partial class GyogyszerAdatok
{
    public int Id { get; set; }

    public string GyogyszerNev { get; set; } = null!;

    public int GyartoId { get; set; }

    public string Kategoria { get; set; } = null!;

    public string Adagolas { get; set; } = null!;

    public string KezelesiIdopont { get; set; } = null!;

    public string KezelesIdotartama { get; set; } = null!;

    public DateTime Emlekezteto { get; set; }

    public string Megjegyzes { get; set; } = null!;

    public virtual Gyarto? Gyarto { get; set; } = null!;
}
