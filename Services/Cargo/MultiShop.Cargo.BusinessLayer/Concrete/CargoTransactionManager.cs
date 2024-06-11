using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoTransactionManager : ICargoTransactionService
    {
        private readonly ICargoTransactionDal _cargoTransactionDal;
        public CargoTransactionManager(ICargoTransactionDal cargoTransactionDal)
        {
            _cargoTransactionDal = cargoTransactionDal;
        }

        public async Task<CargoTransaction> TGetByIdAsync(int id)
        {
            return await _cargoTransactionDal.GetByIdAsync(id);
        }

        public async Task<CargoTransaction> TGetAsync(Func<CargoTransaction, bool> predicate)
        {
            return await _cargoTransactionDal.GetAsync(predicate);
        }

        public async Task<List<CargoTransaction>> TGetAllAsync()
        {
            return await _cargoTransactionDal.GetAllAsync();
        }

        public async Task TAddAsync(CargoTransaction entity)
        {
            await _cargoTransactionDal.AddAsync(entity);
        }

        public async Task TUpdateAsync(CargoTransaction entity)
        {
            await _cargoTransactionDal.UpdateAsync(entity);
        }

        public async Task TDeleteAsync(int id)
        {
            await _cargoTransactionDal.DeleteAsync(id);
        }
    }
}
