using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOIntegrador.Datos
{
    public interface IRepositorio<T> where T : class
    {
        List<T> lista {  get; set; }
        int GetCantidad();
        List<T> GetLista();
    }
}
