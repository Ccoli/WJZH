using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuby.Api.IRepositoty.work;
using Tuby.Api.IServices;
using Tuby.Api.Model;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{
    public class d_dutyServices:BaseServices<d_duty>,Id_dutyServices
    {
        Id_dutyRepository dal;
        public d_dutyServices(Id_dutyRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }

        public async Task<List<d_duty>> QueryDuty() { 
            var list =await dal.Query("", 14, "UpdateTime desc,id desc");
            if (list.Count > 0&&list!=null)
            {
                int excutiontionTime = Convert.ToInt32(list.First().ExcutionTime);
                int currentTime = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
                if (excutiontionTime <= currentTime)
                {
                    list = list.Take(7).ToList();
                    if (list.First().Class=="第七班")
                    {
                        list.Reverse();
                    }
                }
                else
                {
                    list.Reverse();
                    list = list.Take(7).ToList();
                    if (list.First().Class == "第七班")
                    {
                        list.Reverse();
                    }
                }
            }
            return list;
        }
        public async Task<bool> DeleteDuty(string time)
        {
            var list = await dal.Query("", 1, "UpdateTime desc");
            var flag = false;
            if (list.Count > 0 && list != null)
            {
                string excutiontionTime = list.First().ExcutionTime;
                if(excutiontionTime== time)
                {
                    flag = await dal.DeleteValue(it => it.ExcutionTime == time);
                }
            }
            return flag;
        }
    }
}
