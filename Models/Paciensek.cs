using System;
using System.Collections.Generic;

namespace bee_healthy_backend.Models;

public partial class Paciensek
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public string Taj { get; set; } = null!;

    public virtual ICollection<Receptek> Recepteks { get; set; } = new List<Receptek>();
}
