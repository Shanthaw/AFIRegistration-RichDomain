using System;
using System.Threading.Tasks;
using AFIRegistration.Api.Entities;
using AFIRegistration.Api.Models;
using AFIRegistration.Api.Services;
using AFIRegistration.Api.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AFIRegistration.Api.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomersController : BaseController
    {
        private readonly ICustomerRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ICustomerRepository<Customer> customerRepository,
            IMapper mapper, ILogger<CustomersController> logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        [HttpPost]
        public async Task<IActionResult> RegisterCustomer(CustomerRegistrationDto registrationDto)
        {
            Result<CustomerFirstName> customerFirstNameOrError = CustomerFirstName.Create(registrationDto.FirstName);
            Result<CustomerLastName> customerLastNameOrError = CustomerLastName.Create(registrationDto.LastName);
            Result<CustomerDateOfBirth> customerDOBOrError = CustomerDateOfBirth.Create(registrationDto.DateOfBirth);
            Result<Email> emailOrError = Email.Create(registrationDto.Email);
            Result<PolicyReferenceNumber> policyReferenceOrError = PolicyReferenceNumber.Create(registrationDto.PolicyReferenceNumber);
            var result = Result.Combine(customerFirstNameOrError,
                                        customerLastNameOrError,
                                        customerDOBOrError,
                                        emailOrError,
                                        policyReferenceOrError);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            var customerEntity = _mapper.Map<Customer>(registrationDto);
            await _customerRepository.AddItemAsync(customerEntity);
            await _customerRepository.SaveAsync();
            var customerToReturn = _mapper.Map<CustomerDto>(customerEntity);
            _logger.LogInformation($"a customer id {customerToReturn.Id} is registered");
            return CreatedAtRoute("GetCustomer", new { id = customerToReturn.Id }, customerToReturn);
        }
        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<IActionResult> GetRegisteredCustomer(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                return NotFound();
            return Ok(_mapper.Map<CustomerDto>(customer));
        }
    }
}
