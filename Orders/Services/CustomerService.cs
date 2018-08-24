using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orders.Models;

namespace Orders.Services
{
    public class CustomerService : ICustomerService
    {
        private IList<Customer> _customers;

        public CustomerService()
        {
            _customers = new List<Customer>();
            _customers.Add(new Customer(1, "KinetEco"));
            _customers.Add(new Customer(2, "Pixelford Photography"));
            _customers.Add(new Customer(3, "Topsy Turvy"));
            _customers.Add(new Customer(4, "Leaf & Mortar"));
        }

        public Customer GerCustomerById(int id)
        {
            return GerCustomerByIdAsync(id).Result;
        }

        public Task<Customer> GerCustomerByIdAsync(int id)
        {
            return Task.FromResult(_customers.Single(o => Equals(o.Id, id)));
        }

        public Task<IEnumerable<Customer>> GerCustomersAsync()
        {
            return Task.FromResult(_customers.AsEnumerable());
        }
    }

    public interface ICustomerService
    {
        Customer GerCustomerById(int id);

        Task<Customer> GerCustomerByIdAsync(int id);

        Task<IEnumerable<Customer>> GerCustomersAsync();
    }
}
