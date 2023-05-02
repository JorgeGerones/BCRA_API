using BCRA_API.Data;
using BCRA_API.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BRCA_API.Controllers
{
    [ApiController]
    [Route("Movimientos")]
    public class MovimientosController : ControllerBase
    {
        private SQLiteContext _context;

        public MovimientosController(SQLiteContext context)
        {
            _context = context;
        }

        [HttpPost("Agregar")]
        public string AgregarMovimiento([Bind("Id,Operatoria,Transaccion,EntidadDeudora,CuentaDeudora,EntidadAcreedora,CuentaAcreedora,Importe,InstruccionDePago,FechaProcesado,NumeroInterno")]Movimientos Mov)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Mov);
                _context.SaveChanges();

                return true.ToString();
            }

            return false.ToString();
        }

        [HttpDelete("Eliminar")]
        public string EliminarMovimiento(int Id)
        {
            if (Id <= 0) return "Valor Invalido";

            if (_context.Movimientos != null && _context.Movimientos.Count() > 0)
            {
                Movimientos? Selected = _context.Movimientos.Where(u => u.Id == Id).FirstOrDefault();
                if (Selected != null)
                {
                    _context.Remove(Selected);
                    _context.SaveChanges();

                    HttpContext.Response.StatusCode = 200;
                    return "true";
                }

                HttpContext.Response.StatusCode = 500;
                return "Movimiento de Cuenta No Encontrado";
            }
            else
            {
                HttpContext.Response.StatusCode = 500;
                return "Lista " + this.GetType().Name + " Vacia";
            }
        }

        [HttpGet("Mostrar")]
        public string MostrarMovimientos()
        {
            var Data = _context.Movimientos.ToArray();

            JsonSerializerOptions Options = new JsonSerializerOptions();
            Options.WriteIndented = true;

            return JsonSerializer.Serialize(Data, Options);
        }

        [HttpGet("Credito")]
        public string Credito(int Cuenta)
        {
            if (_context.Movimientos == null || _context.Movimientos.Count() == 0)
                return "Movimientos Vacios";

            string SerializedData = string.Empty;

            var Data = _context.Movimientos.AsEnumerable();

            var Selected = Data.Where(m => { return m.CuentaAcreedora == Cuenta; }).FirstOrDefault();
            if(Selected != null)
            {
                object obj = new { 
                    Cuenta = Selected.CuentaAcreedora, 
                    CreditoDisponible = Selected.Importe * 2f
                };

                JsonSerializerOptions Options = new JsonSerializerOptions();
                Options.WriteIndented = true;

                SerializedData = JsonSerializer.Serialize(obj, Options);
            }
            else
            {
                return "Numero de Cuenta No Encontrada";
            }

            return SerializedData;
        }
    }
}
