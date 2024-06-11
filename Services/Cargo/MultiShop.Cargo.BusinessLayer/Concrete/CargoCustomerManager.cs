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
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly ICargoCustomerDal _cargoCustomerDal;
        public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
        {
            _cargoCustomerDal = cargoCustomerDal;
        }

        public async Task<CargoCustomer> TGetByIdAsync(int id)
        {
            return await _cargoCustomerDal.GetByIdAsync(id);
        }

        public async Task<CargoCustomer> TGetAsync(Func<CargoCustomer, bool> predicate)
        {
            return await _cargoCustomerDal.GetAsync(predicate);
        }

        public async Task<List<CargoCustomer>> TGetAllAsync()
        {
            return await _cargoCustomerDal.GetAllAsync();
        }

        public async Task TAddAsync(CargoCustomer entity)
        {
            await _cargoCustomerDal.AddAsync(entity);
        }

        public async Task TUpdateAsync(CargoCustomer entity)
        {
            await _cargoCustomerDal.UpdateAsync(entity);
        }

        public async Task TDeleteAsync(int id)
        {
            await _cargoCustomerDal.DeleteAsync(id);
        }
    }
}
