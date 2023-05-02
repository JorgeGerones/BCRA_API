using System.ComponentModel.DataAnnotations;

namespace BCRA_API.Model
{
    public class Movimientos
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Operatoria { get; set; }
        [Required]
        public string Transaccion { get; set; }
        [Required]
        public int EntidadDeudora { get; set; }
        [Required] 
        public int CuentaDeudora { get; set; }
        [Required] 
        public int EntidadAcreedora { get; set; }
        [Required] 
        public int CuentaAcreedora { get; set; }
        [Required]
        public float Importe { get; set; }
        [Required] 
        public string InstruccionDePago { get; set; }
        
        public DateTime FechaProcesado { get; set; }
        public string NumeroInterno { set; get; }
        
        public Movimientos()
        {
            Operatoria = Transaccion = InstruccionDePago = NumeroInterno = string.Empty;
        }
    }

}
