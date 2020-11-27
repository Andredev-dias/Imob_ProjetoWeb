using Imob.Models;
using LocadoraDeImoveis.DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Imob.DAL
{
    class ContratoDAO
    {
        private static Context _context = SingletonContext.GetInstance();       
        public static Contrato BuscarPorId(int id) =>
            _context.Contratos.Include("Imovel").Include("Corretor").Include("Locatario").FirstOrDefault(x => x.Id == id);

        public static List<Contrato> BuscarPorCorretor(string corretor) =>
            _context.Contratos.Include("Imovel").Include("Corretor").Include("Locatario").Where(x => x.Corretor.Nome == corretor).ToList();

        public static bool Cadastrar(Contrato Contrato)
        {
            if (BuscarPorId(Contrato.Id) == null)
            {
                _context.Contratos.Add(Contrato);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool Atualizar(Contrato Contrato)
        {
            if (BuscarPorId(Contrato.Id) != null)
            {
                _context.Contratos.Update(Contrato);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public static bool Remover(Contrato Contrato)
        {            
            var c = _context.Contratos.Remove(Contrato);
            _context.SaveChanges();

            if (c == null)
            {
                return false;
            }
            return true;
        }
        public static List<Corretor> FiltrarPorParteNome(string parteNome) =>
            _context.Corretores.Where(x => x.Nome.Contains(parteNome)).ToList();
        public static List<Contrato> Listar() => _context.Contratos
                                                            .Include("Imovel")
                                                            .Include("Corretor")
                                                            .Include("Locatario")
                                                            .ToList();
    }
}
