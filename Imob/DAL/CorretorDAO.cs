using Imob.Models;
using Imob.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Imob.DAL
{
    class CorretorDAO
    {
        private static Context _context = SingletonContext.GetInstance();
        public static Corretor BuscarPorNome(string nome) =>
            _context.Corretores.FirstOrDefault(x => x.Nome == nome);

        public static bool BuscarPorCpf(string cpf){
             var x = _context.Corretores.FirstOrDefault(x => x.Cpf == cpf);
            if(x != null)
            {
                return false;
            }
            return true;
        }

        public static Corretor BuscarPorId(int id) =>
            _context.Corretores.Find(id);

        public static bool Cadastrar(Corretor corretor)
        {
            if (BuscarPorNome(corretor.Nome) == null)
            {
                _context.Corretores.Add(corretor);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool Atualizar(Corretor corretor)
        {            
            if (BuscarPorId(corretor.Id) != null)
            {   
                _context.Corretores.Update(corretor);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public static bool Remover(Corretor corretor)
        {
            var Corretor = BuscarPorId(corretor.Id);
            var c = _context.Corretores.Remove(Corretor);
            _context.SaveChanges();

            if (c == null)
            {
                return false;
            }
            return true;
        }
        public static List<Corretor> FiltrarPorParteNome(string parteNome) =>
            _context.Corretores.Where(x => x.Nome.Contains(parteNome)).ToList();
        public static List<Corretor> Listar() => _context.Corretores.ToList();        
    }
}
