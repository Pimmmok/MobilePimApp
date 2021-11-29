using SQLite;

namespace PimApp
{
    [Table("akt")]
    public class Akt
    {

        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        public string Name_Org { get; set; }

        public string Date_Akt { get; set; }
        
        public string Model_Counter { get; set; }

        public string Number_Counter { get; set; }

        public string Energy_Values { get; set; }

        public string Results { get; set; }

        public int Number_of_measurements { get; set; }

        public string Average { get; set; }
        
        public string Qvadro_Average { get; set; }

        public string Note { get; set; }

    }

}

