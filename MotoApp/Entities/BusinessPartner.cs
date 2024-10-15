namespace MotoApp.Entities
{
    public class BusinessPartner : EntityBase
    {
        public string? Name { get; set; }
        public override string ToString() => $"Id: {Id}, First name: {Name},";
    }
}
