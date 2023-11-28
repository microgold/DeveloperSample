using System;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, European
    }

    public enum SwallowLoad
    {
        None, Coconut
    }

    // Strategy interface for airspeed calculation
    public interface IAirspeedCalculator
    {
        double CalculateAirspeed(SwallowLoad load);
    }

    // Concrete strategies for different swallow types
    public class AfricanSwallowAirspeedCalculator : IAirspeedCalculator
    {
        public double CalculateAirspeed(SwallowLoad load)
        {
            return load == SwallowLoad.None ? 22 : 18;
        }
    }

    public class EuropeanSwallowAirspeedCalculator : IAirspeedCalculator
    {
        public double CalculateAirspeed(SwallowLoad load)
        {
            return load == SwallowLoad.None ? 20 : 16;
        }
    }

    // Factory class
    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType)
        {
            IAirspeedCalculator calculator = swallowType switch
            {
                SwallowType.African => new AfricanSwallowAirspeedCalculator(),
                SwallowType.European => new EuropeanSwallowAirspeedCalculator(),
                _ => throw new ArgumentException("Invalid swallow type")
            };

            return new Swallow(calculator);
        }
    }

    // Swallow class using strategy pattern for calculation
    public class Swallow
    {
        private readonly IAirspeedCalculator _airspeedCalculator;

        public SwallowLoad Load { get; private set; }

        public Swallow(IAirspeedCalculator airspeedCalculator)
        {
            _airspeedCalculator = airspeedCalculator ?? throw new ArgumentNullException(nameof(airspeedCalculator));
        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public double GetAirspeedVelocity()
        {
            return _airspeedCalculator.CalculateAirspeed(Load);
        }
    }
}
