using System.ComponentModel.Design;
using LastroApp.Domain.Enums;

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
        public DateTime Maturity { get; private set; }
        public BoletoStatus Status { get; private set; }


        private Boleto(Guid chargeId, Guid sellerId, string codeBoleto, long amountInCents, DateTime maturity, BoletoStatus boletoStatus)
        {
            Id = Guid.NewGuid();
            ChargeId = chargeId;
            SellerId = sellerId;
            CodeBoleto = codeBoleto;
            AmountInCents = amountInCents;
            Maturity = maturity;
            Status = BoletoStatus.Issuance;  
        }

    }
}
