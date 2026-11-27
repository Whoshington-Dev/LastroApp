using LastroApp.Domain.En;
using LastroApp.Domain.Enums;

namespace LastroApp.Domain.Entities{

    public class Seller
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string CNPJ { get; private set; }
        public SellerStatus SellerStatus { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;


        public Seller (string name, string cnpj, SellerStatus sellerStatus, DateTime createAt)
        {
            Id = Guid.NewGuid();
            Name = name; 
            CNPJ = cnpj;
            SellerStatus = SellerStatus;
            CreatedAt = createAt;

            
        }
        public static Seller Create(
            string name, 
            string cnpj, 
            SellerStatus sellerStatus, 
            DateTime createAt)
        {   
            ValidateName(name);
            ValidateCnpj(cnpj);
                 
            return new Seller(name.Trim(), cnpj, sellerStatus, createAt);
        }
        private static void ValidateName(string name)
        {
            if(string.IsNullOrEmpty(name) || name.Length < 3)
            {
                throw new ArgumentException("Name must be provided and have at least 3 characters.");
            }
        }
        private static void ValidateCnpj(string cnpj)
        {
            if(string.IsNullOrEmpty(cnpj))
            {
                throw new ArgumentException("CNPJ must be provided.");
            }
            if (!cnpj.All(char.IsDigit))
            {
                    throw new ArgumentException("CNPJ must contain only numbers.");
            }
            if(cnpj.Length != 14)
            {
                    throw new ArgumentException("CNPJ must have 14 digits.");
            }
        }
        
        public void EnsureCanIssueBoleto()
        {
             if(SellerStatus != SellerStatus.Active)
            {
                throw new InvalidOperationException("The Seller must be active!");
            }
        }
    }
}