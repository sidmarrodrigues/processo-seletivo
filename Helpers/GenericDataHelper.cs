using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Helpers
{
    public class GenericDataHelper
    {
        public string GetDatabasePath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
        }
    }
}
