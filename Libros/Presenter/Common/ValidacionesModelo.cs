using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Libros.Presenter.Common
{
    public class ValidacionesModelo
    {
        public void Validar(object modelo)
        {
            string mensajeError = "";
            List<ValidationResult> resultados = new List<ValidationResult>();
            ValidationContext contexto = new ValidationContext(modelo);

            bool esValido = Validator.TryValidateObject(modelo, contexto, resultados);

            if (esValido==false)
            {
                foreach (var item in resultados)
                {
                    mensajeError+= "- " + item.ErrorMessage + "\n";
                    
                }
                throw new Exception(mensajeError);
            }
        }

    }
}
