using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace YaustinMusicShopOnline.Models
{
    public class Music
    {
        public required int MusicId { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public required string Title { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public required string Artist { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public required string Genre { get; set; }

      //  [StringLength(60, MinimumLength = 3)]
      //  [Required]
      //  public required string Type { get; set; }

        [Range(0, 100)]
        [DataType(DataType.Currency)]
        public required decimal Price { get; set; }

     

    }
}
