using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetReady.Domain.Commands
{

    public class PutOnJacketCommand : IGetReadyCommand, ICommandFactory
    {
        public IGetReady GetReady { get; set; }

        public string Execute()
        {
            return GetReady.PutOnJacket();
        }

        public string CommandName => "5";
        public string Description => "Put on jacket";
        public ICommand CreateCommand(IGetReady getReady)
        {
            return new PutOnJacketCommand { GetReady = getReady };
        }

    }
}
