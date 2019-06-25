using System;
using System.Collections.Generic;
using System.Linq;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

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
        //operação Insert
        public void Insert(Seller obj)
        {
          // obj.Department = _context.Department.First();
            
            //insere o obj Seller na lista
            _context.Add(obj);
            // salva as alterções no DB.
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }
        //operação Remove
        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
        //operação update
        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            { 
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
