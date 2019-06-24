using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class SellerService
    {// esse dependencia não pode ser alterada.
        private readonly SalesWebMvcContext _context;
        // criando o construtor
        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        // operação findAll para retornar a lista de sellers
        public List<Seller> findAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
          // obj.Department = _context.Department.First();
            
            //insere o obj Seller na lista
            _context.Add(obj);
            // salva as alterções no DB.
            _context.SaveChanges();

        }
    }
}
