using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaQR.Data.DAL
{
    public class PresencaDAL
    {
        private IESContext _context;

        public PresencaDAL(IESContext context)
        {
            _context = context;
        }

      
       
    }
}
