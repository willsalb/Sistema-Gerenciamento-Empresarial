using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MathNet.Numerics;

namespace ControleDeContatos.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do cliente")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o CPF/CNPJ do cliente")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do cliente")]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido!!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o celular do cliente")]
        [Phone(ErrorMessage = "O celular informado é inválido!!")]
        public string Celular { get; set; }
    }
}
