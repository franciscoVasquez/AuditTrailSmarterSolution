using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuditTrailModel;
using System.Threading.Tasks;

namespace AuditAD
{
    public class Resultado
    {
        public string TipoError { get; set; }
        public bool Error = false;
        public string Mensaje { get; set; }
    }

    public class AuditAD
    {
        ContextAudit BaseDeDatos = new ContextAudit();

        public List<CuentaBancaria> ListarCuentas()
        {
            return BaseDeDatos.Cuenta.ToList();
        }

        public Resultado GuardarCuenta(CuentaBancaria pCuenta)
        {
            Resultado result = new Resultado();
            try
            {
                BaseDeDatos.Cuenta.Add(pCuenta);
                result.Error = false;
                result.Mensaje = "Registro Guardado exitósamente";
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Mensaje = "El registro no fue guardado";
                throw ex;
            }
           
            BaseDeDatos.SaveChanges("Francisco");
            return result;
        }
        public CuentaBancaria BuscarCuenta(int id)
        {
            CuentaBancaria cuenta = new CuentaBancaria();
            try
            {
                return BaseDeDatos.Cuenta.Where(x => x.Cod_Cuenta == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }
        public Resultado EditarCuenta(int id, CuentaBancaria Model)
        {
            Resultado result = new Resultado();

            try
            {
                var cuenta = BaseDeDatos.Cuenta.Where(x => x.Cod_Cuenta == id).FirstOrDefault();
                cuenta.Banco = Model.Banco;
                cuenta.NroCuenta = Model.NroCuenta;
                cuenta.TipoCuenta = Model.TipoCuenta;

                BaseDeDatos.SaveChanges("Francisco");

                result.Mensaje = "La cuenta fue editada exitosamente";
                result.Error = false;
                result.TipoError = "";

            }
            catch (Exception ex)
            {
                result.Mensaje = "Error al editar la cuenta";
                result.Error = true;
                result.TipoError = "";
                throw ex;
            }

            return result;
        }

        public Resultado EliminarCuenta(int id)
        {
            Resultado result = new Resultado();
            try
            {
                BaseDeDatos.Cuenta.Remove(BaseDeDatos.Cuenta.Find(id));
                BaseDeDatos.SaveChanges("Francisco");
                result.Error = false;
                result.Mensaje = "La cuenta fue eliminada exitósamente";
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Mensaje = "Ocurrió un error al eliminar la cuenta";
                throw ex;
            }
            return result;
        }
    }




}
