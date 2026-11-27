using LastroApp.Domain.Enums;
using LastroApp.Domain.Exceptions;

namespace LastroApp.Domain.Entities
{
    public class Boleto
    {        
        public Guid Id { get; private set; }
        public Guid ChargeId { get; private set; }
        public Guid SellerId { get; private set; }
        public string CodeBoleto { get; private set; }
        public long AmountInCents { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public BoletoStatus Status { get; private set; }


        private Boleto(Guid chargeId, Guid sellerId, string codeBoleto, long amountInCents, DateTime creationDate)
        {
            Id = Guid.NewGuid();
            ChargeId = chargeId;
            SellerId = sellerId;
            CodeBoleto = codeBoleto;
            CreationDate = creationDate;
            ExpirationDate = creationDate.AddDays(3);
            AmountInCents = amountInCents; 
        }

        public static Boleto Issue(Charge charge, Seller seller, string codeBoleto, DateTime creationDate)
        {
            Seller.Create(
                seller.Name,
                seller.CNPJ, 
                seller.SellerStatus, 
                
                seller.CreatedAt
                );
            ArgumentNullException.ThrowIfNull(charge);
            ArgumentNullException.ThrowIfNull(seller);
            seller.EnsureCanIssueBoleto();

            if(charge.SellerId != seller.Id)
            {
                throw new DomainException("The charge does not belong to this seller.");
            }
            if (string.IsNullOrWhiteSpace(codeBoleto))
            {
                throw new DomainException("The boleto code is required.");
            }
            return new Boleto(
            charge.Id,
            seller.Id,
            codeBoleto,
            charge.AmountInCents,
            creationDate);

        }

    }
}
