namespace GongChaWebAPI.Models
{
    public class ProductTypeSize
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Price { get; set; }
        public int TypeId { get; set; }
        public int SizeId { get; set; }
        public double SugarAmount { get; set; }
        public double CaffeinAmount { get; set; }
        public double CalloriesSugarAmount { get; set; }
        public double CalloriesNoSugarAmount { get; set; }
    }
}
