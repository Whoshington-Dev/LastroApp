using LastroApp.Domain.Enums;

namespace LastroApp.Domain.Entities
{
    public class Boleto
    {
        public string Txt { get; set; }
        public string CodeBoleto { get; private set; }
        public Users Users { get; private set; }
        public BoletoStatus BoletoStatus { get; private set; }
        public StatusPayment StatusPayment { get; private set; }
        public SellerStatus SellerStatus { get; private set; }

        public Boleto (string txt, string codeBoleto, Users users, BoletoStatus boletoStatus, StatusPayment statusPayment, SellerStatus sellerStatus)
        {
            Txt = txt;
            CodeBoleto = codeBoleto;
            Users = users;
            BoletoStatus = boletoStatus;
            StatusPayment = statusPayment;
            SellerStatus = sellerStatus;
        }



    }
}
