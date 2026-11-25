using System.Security.Permissions;
using LastroApp.Domain.Enums;
using LastroApp.Domain.Exceptions;

namespace LastroApp.Domain.Entities
{
    public class Boleto
    {
        private const long MinimumAmountInCents = 100;
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
            AmountInCents = amountInCents;
            CreationDate = creationDate;
            ExpirationDate = creationDate.AddDays(3);
            Status = BoletoStatus.Issuance;  
        }

        public static Boleto Issue(Charge charge, Seller seller, string codeBoleto, DateTime CreationDate)
        {
            seller.ValidSeller(); 
            
            if(charge.SellerId != seller.Id)
            {
                throw new DomainException("The charge does not belong to this seller.");
            }
            if (!string.IsNullOrWhiteSpace(codeBoleto))
            {
                throw new DomainException("The boleto code is required.");
            }
            if(charge.AmountInCents < MinimumAmountInCents)
            {
               throw new DomainException("The amount does not meet the minimum (R$ 1,00).");
            }

            return new Boleto(charge.Id, seller.Id, codeBoleto, charge.AmountInCents, CreationDate);
        }

    }
}
