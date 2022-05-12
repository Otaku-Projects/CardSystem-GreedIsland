using System.ComponentModel.DataAnnotations;

namespace WebAPI.DataModel
{
    public class CardContent
    {
        [Key]
        public int Id { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }

        public string LanguageCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
