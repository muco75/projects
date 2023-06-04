using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string? CarMerk { get; set; }
        public string? Model { get; set; }
        public int? Prijs { get; set; }
        public string? Brandstof { get; set; }
        public int Bouwjaar { get; set; }
        public string? Kleur { get; set; }
        public string? Beschrijving { get; set; }
        public byte[]? Image { get; set; }


        internal object FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        internal string? SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
