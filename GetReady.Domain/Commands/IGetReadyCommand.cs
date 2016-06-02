using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetReady.Domain.Commands
{
    public interface IGetReadyCommand : ICommand
    {
        IGetReady GetReady { get; set; }
    }
}
