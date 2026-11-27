using LastroApp.Domain.Entities;
using LastroApp.Domain.Enums;
using LastroApp.Domain.Exceptions;
using Xunit;

namespace LastroUnitTest.TestDomain
{
    public class TestBoleto
    {
        private const string ValidCode = "34191790010104351004791020150008291070000065000";
        private static Seller ValidSeller()
        {
            return new Seller(
                1,
                "João Silva Comércio LTDA",
                "12345678000199",
                SellerStatus.Active,
                DateTime.Today
            );
        }
        private static Payer CreatePayer()
        {
            return new Payer(
                "Carlos Henrique Oliveira",
                "07511107109",
                SellerStatus.Active,
                DateTime.Today
            );
        }
        
        private static Charge CreateCharge(Seller seller, long amountInCents = 5000) 
            => Charge.Create(seller, CreatePayer(), amountInCents, "Assinatura anual");
        private static DateTime FutureDate() => DateTime.UtcNow.AddDays(3); 

        [Fact]
        public void Issue_ShouldCreateBoleto_WhenDataIsValid()
        {
            // Arrange: prepara o cenário
            var seller = ValidSeller();
            var charge = CreateCharge(seller, 5000);
            var maturity = FutureDate();

            // Act: executa a única coisa que está sendo testada
            var boleto = Boleto.Issue(charge, seller, BoletoStatus.Issued, ValidCode, maturity);

            // Assert: confere o resultado
            Assert.NotEqual(Guid.Empty, boleto.Id);
            Assert.Equal(BoletoStatus.Issued, boleto.Status);  
            Assert.Equal(charge.Id, boleto.ChargeId);
            Assert.Equal(seller.Id, boleto.SellerId);
            Assert.Equal(5000, charge.AmountInCents);         
            Assert.Equal(ValidCode, boleto.CodeBoleto);
        }
    }
}
