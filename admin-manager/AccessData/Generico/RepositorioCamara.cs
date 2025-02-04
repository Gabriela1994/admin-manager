using System.Collections.Generic;
using System.Threading.Tasks;
using AccessData.Models;

namespace AccessData.Generico
{
    public class RepositorioCamara
    {
        private readonly UnitOfWork _unitOfWork;

        public RepositorioCamara(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Camara> ObtenerTodas()
        {
            return _unitOfWork.CamaraRepository.ObtenerTodo();
        }

        public Camara ObtenerPorId(int id)
        {
            return _unitOfWork.CamaraRepository.ObtenerTodoPorId(id);
        }

        public void Agregar(Camara camara)
        {
            _unitOfWork.CamaraRepository.Crear(camara);
            _unitOfWork.Save();
        }

        public void Actualizar(Camara camara)
        {
            _unitOfWork.CamaraRepository.Actualizar(camara);
            _unitOfWork.Save();
        }

        public void Eliminar(int id)
        {
            _unitOfWork.CamaraRepository.Borrar(id);
            _unitOfWork.Save();
        }
    }
}