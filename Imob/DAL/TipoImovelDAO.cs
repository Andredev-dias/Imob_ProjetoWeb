using Imob.Models;
using System.Collections.Generic;
using System.Linq;

namespace Imob.DAL
{
    public class TipoImovelDAO
    {
        private readonly Context _context;

        public TipoImovelDAO(Context context) => _context = context;
        public List<TipoImovel> Listar() => _context.TipoImovel.ToList();
        public TipoImovel BuscarPorId(int id) =>
            _context.TipoImovel.Find(id);
    }
}
