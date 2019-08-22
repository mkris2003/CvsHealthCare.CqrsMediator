namespace CvsHealthCare.CqrsMediator.Domain.Entities
{
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; } = string.Empty;
        public int CountryId { get; set; }
    }
}
