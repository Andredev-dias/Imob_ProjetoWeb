using Imob.Models;
using Imob.DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Imob.DAL
{
    class ContratoDAO
    {
        private readonly Context _context;

        public ContratoDAO(Context context) => _context = context;
        public Contrato BuscarPorId(int id) =>
            _context.Contratos.Include("Imovel").Include("Corretor").Include("Locatario").FirstOrDefault(x => x.Id == id);

        public List<Contrato> BuscarPorCorretor(string corretor) =>
            _context.Contratos.Include("Imovel").Include("Corretor").Include("Locatario").Where(x => x.Corretor.Nome == corretor).ToList();

        public bool Cadastrar(Contrato Contrato)
        {
            if (BuscarPorId(Contrato.Id) == null)
            {
                _context.Contratos.Add(Contrato);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Atualizar(Contrato Contrato)
        {
            if (BuscarPorId(Contrato.Id) != null)
            {
                _context.Contratos.Update(Contrato);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Remover(Contrato Contrato)
        {
            var c = _context.Contratos.Remove(Contrato);
            _context.SaveChanges();

            if (c == null)
            {
                return false;
            }
            return true;
        }
        public List<Corretor> FiltrarPorParteNome(string parteNome) =>
            _context.Corretores.Where(x => x.Nome.Contains(parteNome)).ToList();
        public List<Contrato> Listar() => _context.Contratos
                                                            .Include("Imovel")
                                                            .Include("Corretor")
                                                            .Include("Locatario")
                                                            .ToList();
    }
}
