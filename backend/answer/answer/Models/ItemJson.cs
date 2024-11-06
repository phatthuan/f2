namespace answer.Models
{
    public class ItemJson
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemName1 { get; set; }
        public string UomName { get; set; }
        public string ItemUrlImage { get; set; }
        public int? ItemDisplayOrder { get; set; }
        public decimal ItemPriceInclTax { get; set; }
        public decimal ItemPrice { get; set; }
        public string CurName { get; set; }
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public int OrderedQuantity { get; set; }
        public string? ItemDescription { get; set; }
    }
}
