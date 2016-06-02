using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetReady.Domain.Commands
{
    public class UnrecognizedCommand : ICommand
    {
        public IGetReady GetReady { get; set; }

        public string Name { get; set; }

        public string Execute()
        {
            return Constants.Fail;
        }
    }
}
