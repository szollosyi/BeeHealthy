using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace bee_healthy_backend.Models;

public partial class GyogyszerAdatok
{
    public int Id { get; set; }

    public string GyogyszerNev { get; set; } = null!;

    public int GyartoId { get; set; }

    public string Kategoria { get; set; } = null!;

    public string Megjegyzes { get; set; } = null!;

    public virtual Gyarto? Gyarto { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Receptek> Recepteks { get; set; } = new List<Receptek>();
}
