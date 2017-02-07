using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace Chinook.Data.Entities
{
    [Table("Tracks")]
    public class Track
    {
        [Key]
        public int TrackId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(200, ErrorMessage = "Name exceeds maximum length of 200 characters")]
        public string Name { get; set; }
        public int? AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int? GenreId { get; set; }
        [StringLength(200, ErrorMessage = "Composer exceeds maximum length of 200 characters")]
        public string Composer { get; set; }
        [Required(ErrorMessage = "Milliseconds is required")]
        [Range(1.0,Double.MaxValue,ErrorMessage = "Millisecond value out of range; must be greater than 0")] //Double.MaxValue give you the maximum value of a double data type
        public int Milliseconds { get; set; }
        public int? Bytes { get; set; }
        [Required(ErrorMessage = "UnitPrice is required")]
        [Range(0.00, Double.MaxValue, ErrorMessage = "Unit Price value out of range; must be 0 or greater")]
        public decimal UnitPrice { get; set; }

        //Navigation properties
        public virtual Album Album { get; set; }
        public virtual MediaType MediaType { get; set; }

        //public virtual Genre Genre { get; set; }
        //public virtual ICollection<Track> PlaylistTracks { get; set; }
        //public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }


    }
}
