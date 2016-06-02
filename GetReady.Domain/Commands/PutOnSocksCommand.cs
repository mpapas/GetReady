using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetReady.Domain.Commands
{

    public class PutOnSocksCommand : IGetReadyCommand, ICommandFactory
    {
        public IGetReady GetReady { get; set; }

        public string Execute()
        {
            return GetReady.PutOnSocks();
        }

        public string CommandName => "3";
        public string Description => "Put on socks";
        public ICommand CreateCommand(IGetReady getReady)
        {
            return new PutOnSocksCommand { GetReady = getReady };
        }

    }
}
