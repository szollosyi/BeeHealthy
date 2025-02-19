using System;
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

    public DateTime KezelesKezdete { get; set; }

    public DateTime KezelesVege { get; set; }

    public DateTime Emlekezteto { get; set; }

    public string Megjegyzes { get; set; } = null!;

    public virtual Gyarto Gyarto { get; set; } = null!;

    public virtual ICollection<Receptek> Recepteks { get; set; } = new List<Receptek>();
}
