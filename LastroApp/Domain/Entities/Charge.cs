using LastroApp.Domain.Enums;
using LastroApp.Domain.Exceptions;

namespace LastroApp.Domain.Entities
{
    public class Charge
    {
        public Guid Id { get; private set; }
        public Guid SellerId { get; private set; }
        public Payer Payer { get; private set; }
        public long AmountInCents { get; private set; } 
        public string Description { get; private set; }
        public ChargeStatus Status { get; private set; }
        public int ReissueCount { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Charge(Guid sellerId, Payer payer, long amountInCents, string description)
        {
            Id = Guid.NewGuid();
            SellerId = sellerId;
            Payer = payer;
            AmountInCents = amountInCents;
            Description = description;
            Status = ChargeStatus.Open;
            ReissueCount = 0;
            CreatedAt = DateTime.UtcNow;
        }

        public static Charge Create(Seller seller, Payer payer, long amountInCents, string description)
        {
            Seller.Create(
                seller.Name,
                seller.CNPJ, 
                seller.SellerStatus, 
                seller.CreatedAt
                );

            if (amountInCents < 100)
            {
                throw new DomainException("The amount does not meet the minimum (R$ 1,00).");
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new DomainException("The description is required.");
            }

            return new Charge(seller.Id, payer, amountInCents, description);
        }
    }
}