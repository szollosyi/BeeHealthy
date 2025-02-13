using System;
using System.Collections.Generic;

namespace bee_healthy_backend.Models;

public partial class Gyarto
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public string Cim { get; set; } = null!;

    public string Leiras { get; set; } = null!;

    public virtual ICollection<GyogyszerAdatok> GyogyszerAdatoks { get; set; } = new List<GyogyszerAdatok>();
}
