using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Helper
{
    public class EExamConfigurationManager : IEExamConfigurationManager
    {
        private readonly IConfigurationManager _configurationManager;
        public EExamConfigurationManager(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }
        public string AppConnectionString 
        {
            get
            {
                return _configurationManager["AppDbConnection"];
            }
        }

        public string GetConnectionString()
        {
            return _configurationManager.GetConnectionString("AppDbConnection");
        }
    }
}
