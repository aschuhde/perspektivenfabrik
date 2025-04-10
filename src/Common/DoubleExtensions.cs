namespace Common;

public static class DoubleExtensions
{
  private const double Tolerance = 1e-6;
  public static bool IsNotEqualTo(this double value, double otherValue)
  {
    return Math.Abs(value - otherValue) > Tolerance;
  }
}
