using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;

namespace YoreselSozluk.DataAccess.Operations.HeadingOperations.Commands.CreateHeading
{
    public class CreateHeadingCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public CreateHeadingCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        

    }
}
