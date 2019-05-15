namespace EfOneToOneDemo.Data.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}