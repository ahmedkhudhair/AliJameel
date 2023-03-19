using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ali_Jameel.Models
{
    public class Calculator
    {
        public double SystemSize { get; set; }

        public double installationCost { get; set; }

        public double electricityCost { get; set; }

        public double savingsPerMonth { get; set; }

        public double paybackPeriod { get; set; }

        public double totalSavings { get; set; }

        public double timePeriod { get; set; }

        public double batteryCost { get; set; }

        public double batterySavings { get; set; }

        public double batteryPaybackPeriod { get; set; }


        double Calculate()
        {


            //Calculate monthly savings
            savingsPerMonth = (SystemSize * 4.2 * 30 * electricityCost) / 1000;

            //Calculate payback period
            paybackPeriod = installationCost / savingsPerMonth;

            //Calculate total savings
            totalSavings = savingsPerMonth * timePeriod;


            batterySavings = (savingsPerMonth * 0.3) - (batteryCost / timePeriod);
            batteryPaybackPeriod = batteryCost / (savingsPerMonth * 0.3);


            return 13000.3;
        }
    }
}