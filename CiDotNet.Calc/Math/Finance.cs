namespace CiDotNet.Calc.Math
{
    public class Finance
    {
        public enum Mode
        {
            BeginMode = 1, EndMode = 0
        }

        private static double CalculateSPPV(double compoundPeriods, double periodicInterestRate)
        {
            return System.Math.Pow(1.0 + (periodicInterestRate / 100), -compoundPeriods);
        }

        private static double CalculateSPFV(double compoundPeriods, double periodicInterestRate)
        {
            return System.Math.Pow(1.0 + (periodicInterestRate / 100), compoundPeriods);
        }

        private static double CalculateUSPV(double compoundPeriods, double periodicInterestRate)
        {
            double uspv = (1.0 - CalculateSPPV(compoundPeriods, periodicInterestRate))
                /
                (periodicInterestRate / 100);

            return uspv;
        }

        private static double CalculateUSFV(double compoundPeriods, double periodicInterestRate)
        {
            double usfv = (CalculateSPFV(compoundPeriods, periodicInterestRate) - 1.0)
                /
                (periodicInterestRate / 100);

            return usfv;
        }

        private static double GetCompoundPeriods(int duration, int ppy)
        {
            return (double)((ppy * duration) / 12);
        }

        private static double GetPeriodicInterestRate(double interestRate, int ppy)
        {
            return (interestRate / ((double)ppy));
        }

        public static double CalculateRate(int duration, int ppy, double interestRate,
            double presentValue, double finalValue, Mode mode)
        {
            int m = (int)mode;
            double compoundPeriods = GetCompoundPeriods(duration, ppy);
            double periodicInterestRate = GetPeriodicInterestRate(interestRate, ppy);
            return -(
                (finalValue * CalculateSPPV(compoundPeriods, periodicInterestRate) - presentValue)
                /
                ((1.0 + ((periodicInterestRate * m) / 100)) * CalculateUSPV(compoundPeriods, periodicInterestRate))
                );

        }

    }
}
