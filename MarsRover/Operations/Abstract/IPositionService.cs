using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Operations.Abstract
{
    public interface IPositionService
    {
        void StartMoving(List<int> maxPoints,Models.Position position);
    }
}
