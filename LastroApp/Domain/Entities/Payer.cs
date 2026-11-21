using LastroApp.Domain.Enums;

namespace LastroApp.Domain.Entities
{
    public class Payer
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string CPF { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        public Payer(string name, string cpf, string cnpj, SellerStatus sellerStatus , DateTime createdAt)
        {
            Name = name;
            CPF = cpf;
            CreatedAt = createdAt;

            if(string.IsNullOrEmpty(name) || name.Length < 3)
            {
                throw new ArgumentException("Name must be provided and have at least 3 characters.");
            }
            if(string.IsNullOrEmpty(cnpj))
            {
                throw new ArgumentException("CPF must be provided.");
            }

            for (int i = 0; i < cpf.Length; i++)
            {
                if (!char.IsDigit(cpf[i]))
                {
                    throw new ArgumentException("CPF must contain only numbers.");
                }
                if(cpf.Length != 11)
                {
                    throw new ArgumentException("CPF must have 11 digits.");
                }
            }
        }
                   
    }
}