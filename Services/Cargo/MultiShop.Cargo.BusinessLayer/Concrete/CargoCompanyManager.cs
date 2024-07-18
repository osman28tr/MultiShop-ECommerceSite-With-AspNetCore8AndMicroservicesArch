using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _cargoCompanyDal;
        public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
        {
            _cargoCompanyDal = cargoCompanyDal;
        }

        public async Task<CargoCompany> TGetByIdAsync(int id)
        {
            return await _cargoCompanyDal.GetByIdAsync(id);
        }

        public async Task<CargoCompany> TGetAsync(Expression<Func<CargoCompany, bool>> predicate)
        {
            return await _cargoCompanyDal.GetAsync(predicate);
        }

        public async Task<List<CargoCompany>> TGetAllAsync()
        {
            return await _cargoCompanyDal.GetAllAsync();
        }

        public async Task TAddAsync(CargoCompany entity)
        {
            await _cargoCompanyDal.AddAsync(entity);
        }

        public async Task TUpdateAsync(CargoCompany entity)
        {
            await _cargoCompanyDal.UpdateAsync(entity);
        }

        public async Task TDeleteAsync(int id)
        {
            await _cargoCompanyDal.DeleteAsync(id);
        }
    }
}
