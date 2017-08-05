using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PointOfSale.ViewModels.MetodoPagamento
{
    public class MetodoPagamentoViewModel
    {
        public Guid GuidId { get; set; }

        [Required(ErrorMessage = "Informe o nome", AllowEmptyStrings = false)]
        [Display(Name = "Nome do método de pagamento")]
        [StringLength(50, ErrorMessage = "O nome deve conter no máximo 50 caracteres")]
        public string Nome { get; set; }
    }
}