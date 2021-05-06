using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace PBL.Models
{
    [Table("Db_chocolate")]
    public class chocolate
    {
        [Key]
        public int Id_Chocolate { get; set; }
        [MaxLength(15)]
        [Required(ErrorMessage = "O nome da Marca é exigida", AllowEmptyStrings = false)]
        public string Marca { get; set; }
        [Required(ErrorMessage = "Este Campo é Obrigatório", AllowEmptyStrings = false)]
        public DateTime Validade { get; set; }
        [Required(ErrorMessage = "Preencha o tipo de chocolate", AllowEmptyStrings = false)]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Valor necessário", AllowEmptyStrings = false)]
        [Column("Porcentagem_Cacao")]
        public string Cacao { get; set; }
        [Required(ErrorMessage = "O Preço e necessário", AllowEmptyStrings = false)]
        [Column("Preco_Chocolate")]
        public double Preco { get; set; }
        public decimal Desconto { get; set; }

    }
}