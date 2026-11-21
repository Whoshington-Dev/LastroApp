using LastroApp.Domain.Enums;

namespace LastroApp.Domain.Entities{

    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string CNPJ { get; private set; }
        public SellerStatus SellerStatus { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;


        public Seller (int Id, string name, string cnpj, SellerStatus sellerStatus, DateTime createAt)
        {
            Name = name; 
            CNPJ = cnpj;
            SellerStatus = SellerStatus;
            CreatedAt = createAt;

            if(string.IsNullOrEmpty(name) || name.Length < 3)
            {
                throw new ArgumentException("Name must be provided and have at least 3 characters.");
            }
            if(string.IsNullOrEmpty(cnpj))
            {
                throw new ArgumentException("CNPJ must be provided.");
            }
            
            for (int i = 0; i < cnpj.Length; i++)
            {
                if (!char.IsDigit(cnpj[i]))
                {
                    throw new ArgumentException("CNPJ must contain only numbers.");
                }
                if(cnpj.Length != 14)
                {
                    throw new ArgumentException("CNPJ must have 14 digits.");
                }
            }
        }
        public void ValidSeller()
        {   
            if(SellerStatus != SellerStatus.Active)
            {
                throw new InvalidOperationException("The Seller must be active!");
            }
            if(SellerStatus == SellerStatus.Banned)
            {
                throw new InvalidOperationException("The Seller was banned");
            }
        }
    }
}