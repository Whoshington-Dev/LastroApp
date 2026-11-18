using System.Collections.Concurrent;

namespace LastroApp.Domain.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string CPF { get; private set; }
        public string CNPJ { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        public Users(string name, string cpf, string cnpj, DateTime createdAt)
        {
            Name = name;
            CPF = cpf;
            CNPJ = cnpj;
            CreatedAt = createdAt;

            if(string.IsNullOrEmpty(name) || name.Length < 3)
            {
                throw new ArgumentException("Name must be provided and have at least 3 characters.");
            }
            if(string.IsNullOrEmpty(cpf) && string.IsNullOrEmpty(cnpj))
            {
                throw new ArgumentException("CPF or CNPJ must be provided.");
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
            for (int i = 0; i < cnpj.Length; i++)
            {
                if (!char.IsDigit(cnpj[i]))
                {
                    throw new ArgumentException("CNPJ must contain only numbers.");
                }
                if(cnpj.Length != 14)
                {
                    throw new ArgumentException("CNPJ must have 14 digits.");
                }
            }

        }
        
    }
}