using System;
using System.Linq;
using System.Collections.Generic;
using SalesWebMvc.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }
        
        // Alterando a função sincrona para uma assincrona
        //public List<Department> FindAll()
        //{
        //    //return _context.Department.ToList();
        //    //Retornar a lista ordenada por nome(linq)
        //    return _context.Department.OrderBy(x => x.Name).ToList();
        //}

        public async Task<List<Department>> FindallAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
