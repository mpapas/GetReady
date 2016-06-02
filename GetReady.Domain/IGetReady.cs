using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetReady.Domain
{
    public interface IGetReady
    {
        string LeaveHouse();
        string PutOnFootwear();
        string PutOnHeadwear();
        string PutOnJacket();
        string PutOnPants();
        string PutOnShirt();
        string PutOnSocks();
        string TakeOffPajamas();
    }
}
