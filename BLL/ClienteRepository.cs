using MODEL;
using DAL.DBContext;

namespace BLL
{
    public class ClienteRepository
    {

        public static void Add(Cliente _cliente)
        {
            using (var dbContext = new DatabaseMdf())
            {
                dbContext.Clientes.Add(_cliente);
                dbContext.SaveChanges();
            }
        }

        public static Cliente GetById(int Id)
        {
            using (var dbContext = new DatabaseMdf())
            {
                var cliente = dbContext.Clientes.Single(p => p.Id == Id);
                return cliente;
            }
        }
        
        public static List<Cliente> GetAll()
        {
            using (var dbContext = new DatabaseMdf())
            {
                var clientes = dbContext.Clientes.ToList();
                return clientes;
            }
        }

        public static void Update(Cliente _cliente)
        {
            using (var dbContext = new DatabaseMdf())
            {
                var cliente = dbContext.Clientes.Single(p => p.Id == _cliente.Id);
                cliente.Nome = _cliente.Nome;
                cliente.Telefone = _cliente.Telefone;
                cliente.Email = _cliente.Email;
                dbContext.SaveChanges();
            }
        }

        public static void Excluir(Cliente _cliente)
        {
            using (var dbContext = new DatabaseMdf())
            {
                var cliente = dbContext.Clientes.Single(p => p.Id == _cliente.Id);
                dbContext.Remove(cliente);
                dbContext.SaveChanges();
            }
        }
     
    }
}