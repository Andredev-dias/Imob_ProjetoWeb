using Imob.Models;

namespace Imob.DAL
{
    class TipoImovelDAO
    {
        private readonly Context _context;

        public TipoImovelDAO(Context context) => _context = context;

        public TipoImovel BuscarPorId(int id) =>
            _context.TipoImovel.Find(id);
    }
}
