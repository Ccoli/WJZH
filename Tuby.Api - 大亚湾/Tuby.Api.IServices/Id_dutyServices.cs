using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tuby.Api.IServices.BASE;
using Tuby.Api.Model;

namespace Tuby.Api.IServices
{
    public interface Id_dutyServices:IBaseServices<d_duty>
    {
        Task<List<d_duty>> QueryDuty();
        Task<bool> DeleteDuty(string time);
    }
}
