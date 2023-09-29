using System.ComponentModel.DataAnnotations;

namespace CadastroDeFornecedores.Models
{
    public class FornecedorModel
    {
        [Key]
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string? RazaoSocial { get; set; }
        public string? NomeFantasia { get; set; }
        public string Email { get; set; }
        public string? Telefone { get; set; }
        public string NomePessoaContato { get; set; }
        public string? Rua {  get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Estado { get; set; }
        public string? Municipio { get; set; }
        public string? CEP { get; set; }
    }
}
