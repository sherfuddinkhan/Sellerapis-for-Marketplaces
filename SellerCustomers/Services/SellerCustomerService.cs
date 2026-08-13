using Marketplacesellerportal.Models;
using Marketplacesellerportal.SellerCustomers.DTOs;
using Marketplacesellerportal.SellerCustomers.Interfaces;

namespace Marketplacesellerportal.SellerCustomers.Services
{
    public class SellerCustomerService : ISellerCustomerService
    {
        private readonly ISellerCustomerRepository _repository;

        public SellerCustomerService(
            ISellerCustomerRepository repository)
        {
            _repository = repository;
        }

        // Get all seller customers
        public async Task<IEnumerable<SellerCustomer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // Get all customers belonging to one seller
        public async Task<IEnumerable<SellerCustomer>> GetBySellerIdAsync(
            int sellerId)
        {
            return await _repository.GetBySellerIdAsync(sellerId);
        }

        // Get one customer belonging to one seller
        public async Task<SellerCustomer?> GetCustomerAsync(
            int sellerId,
            int customerId)
        {
            return await _repository.GetCustomerAsync(
                sellerId,
                customerId);
        }

        // Get customer by code for a specific seller
        public async Task<SellerCustomer?> GetByCustomerCodeAsync(
            int sellerId,
            string customerCode)
        {
            return await _repository.GetByCustomerCodeAsync(
                sellerId,
                customerCode);
        }

        // Create customer
        public async Task<SellerCustomer> CreateAsync(CreateSellerCustomerRequest request)
        {
            var customer = new SellerCustomer
            {
                SellerId = request.SellerId,
                CustomerCode = "CUST-" +
                       Guid.NewGuid().ToString("N")[..8].ToUpper(),
                // DO NOT set CustomerId.
                // SQL Server will generate it automatically.

                CustomerName = request.CustomerName,

                ContactPerson = request.ContactPerson,

                Email = request.Email,

                Phone = request.Phone,

                GSTIN = request.GSTIN,

                AddressLine1 = request.AddressLine1,

                AddressLine2 = request.AddressLine2,

                City = request.City,

                State = request.State,

                Country = request.Country,

                PostalCode = request.PostalCode,

                CreditLimit = request.CreditLimit,

                IsActive = true,

                CreatedDate = DateTime.Now
            };

            await _repository.AddAsync(customer);

            await _repository.SaveChangesAsync();

            return customer;
        }
        // Update customer
        public async Task<bool> UpdateAsync(
            int sellerId,
            int customerId,
            UpdateSellerCustomerRequest request)
        {
            var customer =
                await _repository.GetCustomerAsync(
                    sellerId,
                    customerId);

            if (customer == null)
                return false;

            customer.CustomerName =
                request.CustomerName;

            customer.ContactPerson =
                request.ContactPerson;

            customer.Email =
                request.Email;

            customer.Phone =
                request.Phone;

            customer.GSTIN =
                request.GSTIN;

            customer.AddressLine1 =
                request.AddressLine1;

            customer.AddressLine2 =
                request.AddressLine2;

            customer.City =
                request.City;

            customer.State =
                request.State;

            customer.Country =
                request.Country;

            customer.PostalCode =
                request.PostalCode;

            customer.CreditLimit =
                request.CreditLimit;

            customer.IsActive =
                request.IsActive;

            customer.UpdatedDate =
                DateTime.Now;

            await _repository.UpdateAsync(customer);

            await _repository.SaveChangesAsync();

            return true;
        }

        // Delete customer
        public async Task<bool> DeleteAsync(
            int sellerId,
            int customerId)
        {
            var customer =
                await _repository.GetCustomerAsync(
                    sellerId,
                    customerId);

            if (customer == null)
                return false;

            await _repository.DeleteAsync(customer);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
