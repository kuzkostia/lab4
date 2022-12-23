namespace lab4.Models
{
    public class Orders
    {
            public int ID { get; set; }
            public int Number { get; set; }
            public int Price { get; set; }
            public DateTime DateOfAdmission { get; set; }
            public DateTime DateOfIssue { get; set; }
            public Users UserID { get; set; }
            public Services ServiceID { get; set; }
    }
}
