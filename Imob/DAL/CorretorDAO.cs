using Imob.Models;
using Imob.DAL;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Imob.DAL
{
    public class CorretorDAO
    {
        private readonly Context _context;

        public CorretorDAO(Context context) => _context = context;

        public Corretor BuscarPorId(int id) =>
            _context.Corretores.Find(id);

        public void Atualizar(Corretor corretor)
        {
            _context.Corretores.Update(corretor);
            _context.SaveChanges();
        }
       
        public void Remover(int id)
        {
            _context.Corretores.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }

        public List<Corretor> FiltrarPorParteNome(string parteNome) =>
            _context.Corretores.Where(x => x.Nome.Contains(parteNome)).ToList();
        public List<Corretor> Listar() => _context.Corretores.ToList();
              
        public Corretor BuscarPorNome(string nome) =>
            _context.Corretores.FirstOrDefault(x => x.Nome == nome);

        public bool BuscarPorCpf(string cpf)
        {
            var x = _context.Corretores.FirstOrDefault(x => x.Cpf == cpf);
            if (x != null)
            {
                return false;
            }
            return true;
        }
        
        public void Cadastrar(Corretor corretor)
        {
            _context.Corretores.Add(corretor);
            _context.SaveChanges();
            /*
            if (BuscarPorNome(corretor.Nome) == null)
            {
                _context.Corretores.Add(corretor);
                _context.SaveChanges();
            }
            */
        }
        
    }
}
