using System;
using AutoMapper;
using Company.Ecommerce.Application.DTO;
using Company.Ecommerce.Application.Interface;
using Company.Ecommerce.Domain.Entity;
using Company.Ecommerce.Domain.Interface;
using Company.Ecommerce.Transversal.Common;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Company.Ecommerce.Application.Main
{
    public class CustomersApplication : ICustomerApplication
    {
        private readonly ICustomersDomain _customersDomain;
        private readonly IMapper _mapper;

        public CustomersApplication(ICustomersDomain customersDomain, IMapper mapper)
        {
            _customersDomain = customersDomain;
            _mapper = mapper;
        }


        public bool Delete(string customerId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> DeleteAsync(string customerId)
        {
            throw new NotImplementedException();
        }

        public Response<CustomersDto> Get(string customerId)
        {
            throw new NotImplementedException();
        }

        public Response<IEnumerable<CustomersDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<CustomersDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<CustomersDto>> GetAsync(string customerId)
        {
            throw new NotImplementedException();
        }

        public Response<bool> Insert(CustomersDto customersDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> InsertAsync(CustomersDto customersDto)
        {
            throw new NotImplementedException();
        }

        public bool Update(CustomersDto customersDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(CustomersDto customersDto)
        {
            throw new NotImplementedException();
        }
    }
}
