using System;
using AccessData.Models;

namespace AccessData.Generico
{
    public class UnitOfWork : IDisposable
    {
        private readonly BdInfraccionesContext _context;

        public UnitOfWork(BdInfraccionesContext context)
        {
            _context = context;
        }

        public GenericRepository<Camara> CamaraRepository => new GenericRepository<Camara>(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
