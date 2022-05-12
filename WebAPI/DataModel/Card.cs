
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WebAPI.DataModel
{
    public class Card
    {
        [Key]
        public int Id { get; set; }

        public string DesignatedNo { get; set; }
        public string RankGrade { get; set; }
        public string RankLimit { get; set; }
        public ICollection<CardContent> CardContents {get;set;}
    }
}