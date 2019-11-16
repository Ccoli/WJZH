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
            count.SixStateCount = 0;
            count.SevenLeaveCount = 0;
            count.LeaveCount = 0;
            count.ToLoanCount = 0;
            count.TrainCount = 0;
            count.VacationCount = 0;
            count.AllTrainCount = 0;

            count.SixLeaveCount = 0;
            count.SixToLoanCount = 0;
            count.SixTrainCount = 0;
            count.SixVacationCount = 0;
            count.SixAllTrainCount = 0;

            count.SevenLeaveCount = 0;
            count.SevenToLoanCount = 0;
            count.SevenTrainCount = 0;
            count.SevenVacationCount = 0;
            count.SevenAllTrainCount = 0;

            foreach (var item in list)
            {
                if (item.SoldierID.Contains("六中队"))
                {
                    if (item.SoilderStateID == 1)
                    {
                        count.StateCount++;
                        count.SixStateCount++;
                    }
                    if (item.SoilderStateID == 0)
                    {
                        count.LeaveCount++;
                        count.SixLeaveCount++;
                    }
                    if (item.SoldierID.Contains("借调"))
                    {
                        count.ToLoanCount++;
                        count.SixTrainCount++;
                    }
                    if (item.SoldierID.Contains("新训"))
                    {
                        count.TrainCount++;
                    }
                    if (item.SoldierID.Contains("休假"))
                    {
                        count.VacationCount++;
                        count.SixVacationCount++;
                    }
                    if (item.SoldierID.Contains("集训"))
                    {
                        count.AllTrainCount++;
                        count.SixAllTrainCount++;
                    }
                }
                else if(item.SoldierID.Contains("七中队"))
                {
                    if (item.SoilderStateID == 1)
                    {
                        count.StateCount++;
                        count.SevenLeaveCount++;
                    }
                    if (item.SoilderStateID == 0)
                    {
                        count.LeaveCount++;
                        count.SevenLeaveCount++;
                    }
                    if (item.SoldierID.Contains("借调"))
                    {
                        count.ToLoanCount++;
                        count.SevenToLoanCount++;
                    }
                    if (item.SoldierID.Contains("新训"))
                    {
                        count.TrainCount++;
                        count.SevenTrainCount++;
                    }
                    if (item.SoldierID.Contains("休假"))
                    {
                        count.VacationCount++;
                        count.SevenVacationCount++;
                    }
                    if (item.SoldierID.Contains("集训"))
                    {
                        count.AllTrainCount++;
                        count.SevenAllTrainCount++;
                    }
                }
            }
            return count;
        }
       
    }
}
	
	