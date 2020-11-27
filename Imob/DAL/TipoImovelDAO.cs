using Imob.Models;

namespace LocadoraDeImoveis.DAL
{
    class TipoImovelDAO
    {
        private static Context _context = SingletonContext.GetInstance();

        public static TipoImovel BuscarPorId(int id) =>
            _context.TipoImovel.Find(id);
    }
}
