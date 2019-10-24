using System.ComponentModel.DataAnnotations;

namespace Universitätsverwaltung.model
{
    public class Abschluss
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(80, MinimumLength = 2)]
        public string Name { get; set; }

        public Abschluss() { }

        public Abschluss(string name)
        {
            Name = name;
        }
    }
}
