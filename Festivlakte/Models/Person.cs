using System.ComponentModel.DataAnnotations;

namespace Festivlakte.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Voornaam is een verplicht veld")]
        [Display(Name = "Voornaam")]
        public string Voornaam { get; set; }
        
        [Required(ErrorMessage = "Achternaam is een verplicht veld")]
        [Display(Name = "Achternaam")]
        public string Achternaam { get; set; }
        
        [Required(ErrorMessage = "E-mail is een verplicht veld")]
        [EmailAddress(ErrorMessage = "Geen geldig e-mail adres")]
       public string Email { get; set; }
       public string Telefoonnummer { get; set; }
        
        [Required(ErrorMessage = "Opmerkingen en/of vragen is een verplicht veld")]
        [Display(Name = "Opmerkingen en/of vragen")]
       public string Vragen { get; set; }
    }
}