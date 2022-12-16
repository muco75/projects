using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;


namespace InAndOut.Models
{
    public class item
    {
       [Key]
       public int Id { get; set; }
       public string Borrwer { get; set; }
       public string Klantadres { get; set; }
       public DateTime GeboorteDatum { get; set; }
    }

    public class itemView
    {
        public int Id { get; set; }
        public int Leeftijd { get; set; }
        public string Borrwer { get; set; }
        public string Klantadres { get; set; }

        //public override string ToString() => JsonSerializer.Serialize<itemView>(this);


    }

}

