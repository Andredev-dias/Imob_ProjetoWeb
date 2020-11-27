using Imob.Models;
using LocadoraDeImoveis.DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Imob.DAL
{
    class ImovelDAO
    {
        private static Context _context = SingletonContext.GetInstance();    

        public static Imovel BuscarPorId(int id) =>
            _context.Imoveis.Find(id);

        public static List<Imovel> BuscarPorIdCompleto(int id)
        {
            return _context.Imoveis.Include(u => u.TipoImovel.Id == id).ToList();
        }
        public static bool Cadastrar(Imovel imovel)
        {
            if (BuscarPorId(imovel.Id) == null)
            {
                _context.Imoveis.Add(imovel);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool Atualizar(Imovel imovel)
        {
            if (BuscarPorId(imovel.Id) != null)
            {
                _context.Imoveis.Update(imovel);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public static bool Remover(Imovel imovel)
        {
            var Imovel = BuscarPorId(imovel.Id);
            var c = _context.Imoveis.Remove(Imovel);
            _context.SaveChanges();

            if (c == null)
            {
                return false;
            }
            return true;
        }

        public static List<Imovel> Listar()
        {
            return _context.Imoveis.Include("TipoImovel").ToList();
        }

        public static List<Imovel> ListarPorFiltro(string filtro)
        {
            switch (filtro)
            {
                case "disponivel":
                    return _context.Imoveis.Where(x => x.Locado == true).ToList();
                case "alugado":
                    return _context.Imoveis.Where(x => x.Locado == false).ToList();
                default:
                    return new List<Imovel>();
            }
            
        }
    }
}

