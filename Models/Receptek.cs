﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace bee_healthy_backend.Models;

public partial class Receptek
{
    public int Id { get; set; }

    public int PaciensId { get; set; }

    public int GyogyszerId { get; set; }

    public int OrvosId { get; set; }

    [JsonIgnore]
    public virtual GyogyszerAdatok Gyogyszer { get; set; } = null!;

    [JsonIgnore]
    public virtual Orvosok Orvos { get; set; } = null!;

    [JsonIgnore]
    public virtual Paciensek Paciens { get; set; } = null!;
}
