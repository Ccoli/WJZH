using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Model.Models;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{
    public partial class PasswordLibServices : BaseServices<PasswordLib>, IPasswordLibServices
    {
        IPasswordLibRepository _dal;
        public PasswordLibServices(IPasswordLibRepository dal)
        {
            this._dal = dal;
            base.baseDal = dal;
        }

    }
}
