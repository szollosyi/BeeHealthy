using System;

namespace bee_healthy_backend.Models
{
    public class ReceptDTO
    {
        public int Id { get; set; }
        public string PaciensNev { get; set; }
        public string GyogyszerNev { get; set; }
        public string OrvosNev { get; set; }
        public string KezelesiIdopont { get; set; }
        public DateTime KezelesKezdete { get; set; }
        public DateTime KezelesVege { get; set; }
        public string Adagolas { get; set; }
    }
}
