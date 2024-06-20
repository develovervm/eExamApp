using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Helper
{
    public interface IEExamConfigurationManager
    {
        string AppConnectionString { get; }
        string GetConnectionString();
    }
}
