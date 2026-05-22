using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_AnalyseDossier.Services
{
    public class FormatService
    {
        public static double ConvertToMo(double data)
        {
            //return data / (1024.0 * 1024.0);
            return Math.Round(data / (1000.0*1000.0),2);
        }
    }
}
