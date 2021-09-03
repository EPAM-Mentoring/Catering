using Catering.BLL.Contracts.Reserve;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.BLL.Interfaces
{
    public interface IBuildingService
    {
        public Task<ReserveResponse> GetFreeBuildings();

        public Task<ReserveResponse> GetById(int buildingId);
    }
}
