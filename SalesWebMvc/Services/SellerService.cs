using System;
using System.Collections.Generic;
using System.Linq;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;
using System.Threading.Tasks;

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
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }
        //operação Insert
        public async Task InsertAsync(Seller obj)
        {
          // obj.Department = _context.Department.First();
            
            //insere o obj Seller na lista
            _context.Add(obj);
            // salva as alterções no DB.
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }
        //operação Remove
        public async Task RemoveAsync(int id)
        {
            try
            { 
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }
        //operação update
        public async Task UpdateAsync(Seller obj)
        {

            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            { 
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
