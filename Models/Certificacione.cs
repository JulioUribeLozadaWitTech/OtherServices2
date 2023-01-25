//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;

//namespace LunesBorrar.Models
//{
//    public partial class Certificacione
//    {
//        [Required(ErrorMessage = "Campo Requerido")]
//        public int IdCertification { get; set; }

//        [Required(ErrorMessage = "Campo Requerido")]
//        public string NoContract { get; set; } = null!;

//        [Required(ErrorMessage = "Campo Requerido")]
//        public string ContractNumber { get; set; } = null!;

//        [Required(ErrorMessage = "Campo Requerido")]
//        public string DocIdentContrator { get; set; } = null!;

//        public string? Address { get; set; }
//        public string? MobilePhone { get; set; }
//        public string? Ciudad { get; set; }
//        public string Email { get; set; } = null!;

//        [Required(ErrorMessage = "Campo Requerido")]
//        public string TypeContract { get; set; } = null!;

//        [Required(ErrorMessage = "Campo Requerido")]
//        public DateTime DateSuscripcion { get; set; }

//        [Required(ErrorMessage = "Campo Requerido")]
//        public string Object { get; set; } = null!;

//        [Required(ErrorMessage = "Campo Requerido")]
//        public decimal VrInicial { get; set; }

//        public decimal? VrAdicionNo1 { get; set; }
//        public decimal? ModificatorioReduccionNo1 { get; set; }
//        public decimal? VrAdicionNo2 { get; set; }
//        public decimal? VrAdicionNo3 { get; set; }

//        [Required(ErrorMessage = "Campo Requerido")]
//        public decimal VrTotalContrato { get; set; }

//        public DateTime? InitialTerm { get; set; }
//        public DateTime? ExtensionTerm { get; set; }

//        [Required(ErrorMessage = "Campo Requerido")]
//        public DateTime FinalTerm { get; set; }

//        [Required(ErrorMessage = "Campo Requerido")]
//        public string StateContract { get; set; } = null!;

//        [Required(ErrorMessage = "Campo Requerido")]
//        public string DocIdentSupervisor { get; set; } = null!;

//        [Required(ErrorMessage = "Campo Requerido")]
//        public DateTime IssueDate { get; set; }
//    }
//}
