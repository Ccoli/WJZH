using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.Services
{
    /// <summary>
    /// d_soldierServices
    /// </summary>	
    public class d_soldierServices : BaseServices<d_soldier>, Id_soldierServices
    {

        Id_soldierRepository dal;
        public d_soldierServices(Id_soldierRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }

        public async Task<List<string>> QueryList()
        {
            return await dal.QueryList();
        }
        public async Task<List<object>> QueryNameList()
        {
            return await dal.QueryNameList();
        }

        public async Task<CountSoldierEntity> GetCount()
        {
            var list = await dal.Query();
            CountSoldierEntity count = new CountSoldierEntity();
            count.StateCount = 0;
            count.LeaveCount = 0;
            count.ToLoanCount = 0;
            count.TrainCount = 0;
            count.VacationCount = 0;
            count.AllTrainCount = 0;

            foreach (var item in list)
            {
                if (item.SoilderStateID == 1)
                {
                    count.StateCount++;
                }
                if (item.SoilderStateID == 0)
                {
                    count.LeaveCount++;
                }
                if (item.SoldierID.Contains("½èµ÷"))
                {
                    count.ToLoanCount++;
                }
                if (item.SoldierID.Contains("ÐÂÑµ"))
                {
                    count.TrainCount++;
                }
                if (item.SoldierID.Contains("ÐÝ¼Ù"))
                {
                    count.VacationCount++;
                }
                if (item.SoldierID.Contains("¼¯Ñµ"))
                {
                    count.AllTrainCount++;
                }

            }
            return count;
        }

    }
}

