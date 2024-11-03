using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace B1Task1.Models
{
    public class RandomDataEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public string EnglishString { get; set; } = string.Empty;
        public string RussianString { get; set; } = string.Empty;
        public long EvenNumber { get; set; }
        public decimal DecimalNumber { get; set; }

        public RandomDataEntry()
        {
        }

        public RandomDataEntry(DateOnly date, string engilshString, string russianString, long evenNumber, decimal decimalNumber)
        {
            Date = date;
            EnglishString = engilshString;
            RussianString = russianString;
            EvenNumber = evenNumber;
            DecimalNumber = decimalNumber;
        }
    }
}
