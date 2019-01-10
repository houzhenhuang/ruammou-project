using Ioc.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Bussiness.Service
{
    public class ModuleService : BaseService
    {
        public ModuleService(PerManagerContext context)
            : base(context)
        {

        }

    }
}
