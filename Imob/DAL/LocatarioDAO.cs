using Imob.Models;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeImoveis.DAL
{
    public class LocatarioDAO
    {
        private readonly Context _context;

        public LocatarioDAO(Context context) => _context = context;
        public Locatario BuscarPorNome(string nome) =>
            _context.Locatarios.FirstOrDefault(x => x.Nome == nome);

        public Locatario BuscarPorId(int id) =>
            _context.Locatarios.Find(id);
        public  bool BuscarPorCpf(string cpf)
        {
            var x = _context.Locatarios.FirstOrDefault(x => x.Cpf == cpf);
            if (x != null)
            {
                return false;
            }
            return true;
        }
        public bool Cadastrar(Locatario locatario)
        {
            if (BuscarPorNome(locatario.Nome) == null)
            {
                _context.Locatarios.Add(locatario);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Atualizar(Locatario locatario)
        {
            if (BuscarPorId(locatario.Id) != null)
            {
                _context.Locatarios.Update(locatario);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Remover(Locatario locatario)
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
        public List<Locatario> FiltrarPorParteNome(string parteNome) =>
            _context.Locatarios.Where(x => x.Nome.Contains(parteNome)).ToList();
        public List<Locatario> Listar() => _context.Locatarios.ToList();
    }
}
