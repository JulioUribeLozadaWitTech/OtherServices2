using System.ComponentModel.DataAnnotations;

namespace OtherServices2.Models
{
    //BORRAR MODELO
    public partial class Certification
    {
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdCertification { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string NoContract { get; set; } = null!;
        [Required(ErrorMessage = "Campo Requerido")]
        public string ContractNumber { get; set; } = null!;
        [Required(ErrorMessage = "Campo Requerido")]
        public string DocIdentContrator { get; set; } = null!;
        public string? Address { get; set; }
        public string? MobilePhone { get; set; }
        public string? City { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Campo Requerido")]
        public string TypeContract { get; set; } = null!;
        [Required(ErrorMessage = "Campo Requerido")]
        public DateTime DateSuscripcion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Object { get; set; } = null!;
        [Required(ErrorMessage = "Campo Requerido")]
        public decimal ValueInicial { get; set; }
        public decimal? ValueAddictionNo1 { get; set; } = null!;
        public decimal? ModificatorioReduccionNo1 { get; set; } = null!;
        public decimal? ValueAaddictionNo2 { get; set; } = null!;
        public decimal? ValueAddictionNo3 { get; set; } = null!;
        [Required(ErrorMessage = "Campo Requerido")]
        public decimal ValueFinalContract { get; set; }
        public DateTime? InitialTerm { get; set; }
        public DateTime? ExtensionTerm { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public DateTime FinalTerm { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string StateContract { get; set; } = null!;
        [Required(ErrorMessage = "Campo Requerido")]
        public string DocIdentSupervisor { get; set; } = null!;
        [Required(ErrorMessage = "Campo Requerido")]
        public DateTime IssueDate { get; set; }
    }
}
