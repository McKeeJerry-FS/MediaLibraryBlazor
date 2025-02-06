using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Shared.Model
{
    public class PersonModel : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDay { get; set; }
        public string BirthPlace { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public int[] MoviesIds { get; set; } = Array.Empty<int>();

    }
}
