using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Festivlakte.Controllers.Databases
{
    public class Festivals
    {
        public int Id { get; set; }
        public string? Naam { get; set; }
        public string? Beschrijving { get; set; }
        public string? Datum_begin { get; set; }
        public string? Datum_eind { get; set; }
        public string? Tijd { get; set; }
        public string? Beschrijving_lang { get; set; }
        public string? Afbeelding { get; set; }
    }
}
