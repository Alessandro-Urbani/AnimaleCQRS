using AnimaleCQRS.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimaleCQRS.Server.Queries.Handler
{
    public class VeterinarioQueryHandler
    {


        private readonly VeterinarioDbContext _context;

        public VeterinarioQueryHandler(VeterinarioDbContext context)
        {
            _context = context;
        }
    }
}
