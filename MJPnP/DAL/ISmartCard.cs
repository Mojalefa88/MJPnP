using MJPnP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJPnP.DAL
{
    public interface ISmartCard
    {
        SmartCard Create(SmartCard newSmartCart);
    }
}
