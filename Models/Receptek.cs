using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace bee_healthy_backend.Models;

public partial class Receptek
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int GyogyszerId { get; set; }

    public int OrvosId { get; set; }

    public virtual GyogyszerAdatok Gyogyszer { get; set; } = null!;

    public virtual Orvosok Orvos { get; set; } = null!;

    [JsonIgnore]
    public virtual User User { get; set; } = null!;
}
