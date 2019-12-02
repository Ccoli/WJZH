using System;
using System.Collections.Generic;
using System.Text;
using Tuby.Api.Model.viewmodels;
using Tuby.Api.Repository.Base;
using Tuby.Api.IRepositoty;
using System.Threading.Tasks;
using Tuby.Api.Model;
using SqlSugar;

namespace Tuby.Api.Repository
{
    public class GunInfoRepository : BaseRepository<GunInfoView>, IGunInfoRepository
    {
        public async Task<List<GunInfoView>> QueryMuchTable()
        {
            return await QueryMuch<d_pap_gun, d_soldier, GunInfoView>(
                    (dpg, ds) => new object[] {
                JoinType.Left,ds.ID==dpg.SoldierID
                    },
                    (dpg, ds) => new GunInfoView()
                    {
                        SoldierName = ds.Name,
                        ID=dpg.ID,
                        Name=dpg.ImagePath,
                        GunTypeID=dpg.GunTypeID,
                        SoldierID=dpg.SoldierID,
                        UpdateTime=dpg.UpdateTime,
                        RecStatus=dpg.RecStatus
                    }
                    );
        }

        public async Task<PageModel<GunInfoView>> QueryMuchTable(int page,int pagesize)
        {
            return await QueryMuch<d_pap_gun, d_soldier, GunInfoView>(
                   (dpg, ds) => new object[] {
                JoinType.Left,ds.ID==dpg.SoldierID
                   },
                   (dpg, ds) => new GunInfoView()
                   {
                       SoldierName = ds.Name,
                       ID = dpg.ID,
                       Name = dpg.ImagePath,
                       GunTypeID = dpg.GunTypeID,
                       SoldierID = dpg.SoldierID,
                       UpdateTime = dpg.UpdateTime,
                       RecStatus = dpg.RecStatus
                   },page,pagesize,null
                   );
        }
    }
}
