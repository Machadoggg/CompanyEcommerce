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
            var response = new Response<CustomersDto>();
            try
            {
                var customer = _customersDomain.Get(customerId);
                response.Data = _mapper.Map<CustomersDto>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<IEnumerable<CustomersDto>> GetAll()
        {
            var response = new Response<IEnumerable<CustomersDto>>();
            try
            {
                var customers = _customersDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomersDto>>(customers);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
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

        bool ICustomerApplication.Update(CustomersDto customersDto)
        {
            throw new NotImplementedException();
        }

        bool ICustomerApplication.Delete(string customerId)
        {
            throw new NotImplementedException();
        }
    }
}
