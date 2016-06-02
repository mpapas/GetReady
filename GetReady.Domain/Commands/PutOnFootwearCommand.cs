using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetReady.Domain.Commands
{
    public class PutOnFootwearCommand : IGetReadyCommand, ICommandFactory
    {
        public string Execute()
        {
            return GetReady.PutOnFootwear();
        }

        public string CommandName => "1";
        public string Description => "Put on footwear";
        public ICommand CreateCommand(IGetReady getReady)
        {
            return new PutOnFootwearCommand { GetReady = getReady };
        }

        public IGetReady GetReady { get; set; }
    }
}
