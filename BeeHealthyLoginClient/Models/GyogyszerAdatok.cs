﻿using System;
using System.Collections.Generic;

namespace bee_healthy_backend.Models;

public partial class GyogyszerAdatok
{
    public int Id { get; set; }

    public string GyogyszerNev { get; set; } = null!;

    public int GyartoId { get; set; }

    public string Kategoria { get; set; } = null!;

    public string Megjegyzes { get; set; } = null!;

    public virtual Gyarto Gyarto { get; set; } = null!;

    public virtual ICollection<Receptek> Recepteks { get; set; } = new List<Receptek>();

    public override string ToString()
    {
        return $"Id: {Id}\nGyógyszerNév: {GyogyszerNev}\nGyártóId: {GyartoId}\nKategória: {Kategoria}\nMegjegyzés: {Megjegyzes}\nGyartó {Gyarto}";
    }
}
