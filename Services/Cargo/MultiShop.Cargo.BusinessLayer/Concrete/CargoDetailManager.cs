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
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal _cargoDetailDal;
        public CargoDetailManager(ICargoDetailDal cargoDetailDal)
        {
            _cargoDetailDal = cargoDetailDal;
        }

        public async Task<CargoDetail> TGetByIdAsync(int id)
        {
            return await _cargoDetailDal.GetByIdAsync(id);
        }

        public async Task<CargoDetail> TGetAsync(Expression<Func<CargoDetail, bool>> predicate)
        {
            return await _cargoDetailDal.GetAsync(predicate);
        }

        public async Task<List<CargoDetail>> TGetAllAsync()
        {
            return await _cargoDetailDal.GetAllAsync();
        }

        public async Task TAddAsync(CargoDetail entity)
        {
            await _cargoDetailDal.AddAsync(entity);
        }

        public async Task TUpdateAsync(CargoDetail entity)
        {
            await _cargoDetailDal.UpdateAsync(entity);
        }

        public async Task TDeleteAsync(int id)
        {
            await _cargoDetailDal.DeleteAsync(id);
        }
    }
}
