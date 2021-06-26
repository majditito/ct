namespace Coffee.DAL.Entities
{
    public class Product
    {
        public Product(string productCode, string productName, int price, bool extraHotEnabled = true)
        {
            this.Code = productCode;
            this.Name = productName;
            this.Price = price;
            this.ExtraHotEnabled = extraHotEnabled;
        }
        public string Code { get; set; }
        public string Name { get; set; }

        //The price is on cents 
        public int Price { get; set; }
        public bool ExtraHotEnabled { get; set; }
        public Result Order(int sugar, int insertedMoney, bool extraHot)
        {
            if (insertedMoney >= Price)
            {
                string displayedCode = Code + ((extraHot && ExtraHotEnabled) ? "h" : "");
                if (sugar > 0)
                {
                    return new Result
                    {
                        Message = displayedCode + ":" + sugar.ToString() + ":0",
                        Success = true
                    };
                }
                else
                {
                    return new Result
                    {
                        Message = displayedCode + "::",
                        Success = true
                    };
                }
            }
            else
            {
                return new Result
                {
                    Message = "M:Missing " + (Price - insertedMoney) + " cents to the drink maker",
                    Success = false
                };
            }

        }
    }
}
