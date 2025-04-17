using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSystems.Models {
    [Table("places")]
    public class Place {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("name")]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        [Column("address")]
        public string Address { get; set; }
        [Required]
        [Column("image")]
        public byte[] ImageData { get; set; }

        [NotMapped]
        public ImageSource ImageSource {
            get {
                return ImageSource.FromStream(() => new MemoryStream(ImageData));
            }
        }
    }
}
