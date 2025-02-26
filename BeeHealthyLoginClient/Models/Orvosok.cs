using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace bee_healthy_backend.Models;

public partial class Orvosok
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public string Beosztas { get; set; } = null!;

    public virtual ICollection<Receptek> Recepteks { get; set; } = new List<Receptek>();
}
