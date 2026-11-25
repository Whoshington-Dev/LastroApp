using System.Reflection;
using System.Security.Permissions;
using LastroApp.Domain.Entities;
using LastroApp.Domain.Enums;
using Xunit;
using Xunit.Sdk;



namespace LastroUnitTest.TestDomain
{
    public class TestBoleto
    {
        [Fact]
        public void Issue_ShouldCreateBoleto_WhenDataIsValid()
        {
            // Arrange
            var seller = new Seller(
                1,
                "João Silva Comércio LTDA",
                "12345678000199",
                SellerStatus.Active,
                DateTime.Today
            );
            var payer = new Payer(
                "Carlos Henrique Oliveira",
                "12345678909",
                SellerStatus.Active,
                DateTime.Today
            );
            var charge = Charge.Create(
                seller, 
                payer,
                100,
                "Assinatura anual Curso de Inglês"
            );

            var codeBoleto = "";
            var createDate = DateTime.Now;

            // Act
            var boleto = Boleto.Issue(charge, seller, codeBoleto, createDate);
            
            // Assert
            Assert.NotNull(boleto);
            Assert.Equal(100, boleto.AmountInCents); 
            
        }
        
    }   
}