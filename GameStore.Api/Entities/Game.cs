using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Entities;
public class Game
{
    public int Id { get; set; }

    [Required]  // System.ComponentModel.DataAnnotations
    [StringLength(50)]
    public required string Name { get; set; }
    
    [Required]
    [StringLength(20)]
    public required string Genre { get; set; }
   
    [Range(1,100)]
    public decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }
    
    [Url]  // check that Url is valid
    [StringLength(100)]
    public required string ImageUri { get; set; }
}
