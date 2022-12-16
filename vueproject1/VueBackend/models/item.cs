using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;




namespace VueBackend.models
{
    public class item
    {
        public int Id { get; set; }
        public string? Task{ get; set; }
        public string? Status { get; set; }

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
