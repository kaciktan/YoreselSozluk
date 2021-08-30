using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoreselSozluk.Entities
{
    public class Heading
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; } 
        public User User { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }    
      

        public string Name { get; set; } // Heading  : Endele (33) Mersin -> Entry: Öyle yapma o şekilde yapma anlamındadır.
        public bool IsActive { get; set; } = true;

        public virtual ICollection<HeadingCity> HeadingCities {  get; set; }  


    }
}
