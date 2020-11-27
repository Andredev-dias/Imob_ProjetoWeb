
using LocadoraDeImoveis.Models;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeImoveis.DAL
{
    class LocatarioDAO
    {
        private static Context _context = SingletonContext.GetInstance();
        public static Locatario BuscarPorNome(string nome) =>
            _context.Locatarios.FirstOrDefault(x => x.Nome == nome);

        public static Locatario BuscarPorId(int id) =>
            _context.Locatarios.Find(id);
        public static bool BuscarPorCpf(string cpf)
        {
            var x = _context.Locatarios.FirstOrDefault(x => x.Cpf == cpf);
            if (x != null)
            {
                return false;
            }
            return true;
        }
        public static bool Cadastrar(Locatario locatario)
        {
            if (BuscarPorNome(locatario.Nome) == null)
            {
                _context.Locatarios.Add(locatario);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool Atualizar(Locatario locatario)
        {
            if (BuscarPorId(locatario.Id) != null)
            {
                _context.Locatarios.Update(locatario);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public static bool Remover(Locatario locatario)
        {
            var Locatario = BuscarPorId(locatario.Id);
            var c = _context.Locatarios.Remove(Locatario);
            _context.SaveChanges();

            if (c == null)
            {
                return false;
            }
            return true;
        }
        public static List<Locatario> FiltrarPorParteNome(string parteNome) =>
            _context.Locatarios.Where(x => x.Nome.Contains(parteNome)).ToList();
        public static List<Locatario> Listar() => _context.Locatarios.ToList();
    }
}
