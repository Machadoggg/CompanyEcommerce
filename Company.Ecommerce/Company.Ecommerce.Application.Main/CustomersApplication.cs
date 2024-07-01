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



        #region Async methods
        public Response<bool> Insert(CustomersDto customersDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customersDto);
                response.Data = _customersDomain.Insert(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Update(CustomersDto customersDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customersDto);
                response.Data = _customersDomain.Update(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Delete(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _customersDomain.Delete(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }


        public Response<CustomersDto> Get(string customerId)
        {
            throw new NotImplementedException();
        }

        public Response<IEnumerable<CustomersDto>> GetAll()
        {
            throw new NotImplementedException();
        }
        #endregion



        public Task<Response<bool>> DeleteAsync(string customerId)
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


        public Task<Response<bool>> InsertAsync(CustomersDto customersDto)
        {
            throw new NotImplementedException();
        }

        

        public Task<bool> UpdateAsync(CustomersDto customersDto)
        {
            throw new NotImplementedException();
        }
    }
}
