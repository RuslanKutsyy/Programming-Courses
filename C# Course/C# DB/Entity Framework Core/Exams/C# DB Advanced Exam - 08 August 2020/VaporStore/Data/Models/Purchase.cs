using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(0, 1)]
        public PurchaseType Type { get; set; }
        [Required]
        [RegularExpression("^(\\w{4})\\-(\\w{4})\\-(\\w{4})$")]
        public string ProductKey { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required, ForeignKey(nameof(Card))]
        public int CardId { get; set; }
        [Required]
        public Card Card { get; set; }
        [Required, ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        [Required]
        public Game Game { get; set; }
    }
}