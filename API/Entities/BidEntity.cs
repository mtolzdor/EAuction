namespace API.Entities
{
    public class BidEntity
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public ItemEntity? Item { get; set; }
        public string BidderName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}