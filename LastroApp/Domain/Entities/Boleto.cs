using System.ComponentModel;
using System.Security.Permissions;
using LastroApp.Domain.Enums;

namespace LastroApp.Domain.Entities
{
    public class Boleto
    {
        public Guid Id { get; private set; }
        public string Emitir { get; private set; }
        public string CodeBoleto { get; private set; }
        public BoletoStatus Status { get; private set; }
        public Guid ChargeId { get; private set; }
        public Guid PayerId { get; private set; }
        public Guid SellerId  { get; private set; }
    
    private Boleto(Guid chargeId, Guid sellerId, string codeBoleto)
    {
        Id = Guid.NewGuid();
        ChargeId = chargeId;
        SellerId = sellerId;
        CodeBoleto = codeBoleto;
    }


        public Boleto(string emitir, BoletoStatus status)
        {
            Emitir = emitir;
            Status = status;
        }

    }
}
