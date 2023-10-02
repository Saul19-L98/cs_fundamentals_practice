using System.Numerics;

namespace assignment_solution;

internal class NumericType
{
    public const string BigInteger = "BigInteger";
    public const string Ulong = "ulong";
    public const string UInt = "unit";
    public const string Ushort = "ushort";
    public const string Byte = "byte";
    public const string Long = "long";
    public const string Int = "int";
    public const string Short = "short";
    public const string Sbyte = "sbyte";
    public const string Decimal = "decimal";
    public const string Float = "float";
    public const string Double = "double";
    public const string ImpossibleRepresentation = "Impossible representation";
    public static string GetName(BigInteger minValue, BigInteger maxValue, bool integralOnly, bool mustBePrecise)
    {
        return 
            integralOnly ? 
            GetIntegralNumericType(minValue, maxValue) : 
            GetFlaotingPointNumberName(minValue,maxValue,mustBePrecise); 
    }
    private static string GetIntegralNumericType(BigInteger minValue, BigInteger maxValue)
    {
        return minValue >= 0 ? GetUnsignedIntegralNumberName(maxValue) : GetSignedIntegralNumberName(minValue, maxValue);
    }
    private static string GetUnsignedIntegralNumberName(BigInteger maxValue)
    {
        if (maxValue <= byte.MaxValue)
        {
            return Byte;
        }
        if (maxValue <= ushort.MaxValue)
        {
            return Ushort;
        }
        if (maxValue <= uint.MaxValue)
        {
            return UInt;
        }
        if (maxValue <= ulong.MaxValue)
        {
            return Ulong;
        }
        return BigInteger;
    }
    private static string GetSignedIntegralNumberName(BigInteger minValue, BigInteger maxValue)
    {
        if (minValue >= sbyte.MinValue && maxValue <= sbyte.MaxValue)
        {
            return Sbyte;
        }
        if (minValue >= short.MinValue && maxValue <= short.MaxValue)
        {
            return Short;
        }
        if (minValue >= int.MinValue && maxValue <= int.MaxValue)
        {
            return Int;
        }
        if (minValue >= long.MinValue && maxValue <= long.MaxValue)
        {
            return Long;
        }
        return BigInteger;
    }

    private static string GetFlaotingPointNumberName(BigInteger minValue, BigInteger maxValue, bool mustBePrecise)
    {
        return mustBePrecise ? GetPreciseFloatingPointNumberName(minValue, maxValue) : GetImpreciseFloatingPointNumberName(minValue, maxValue);
    }
    private static string GetPreciseFloatingPointNumberName(BigInteger minValue, BigInteger maxValue)
    {
        if (minValue >=  new BigInteger(decimal.MinValue) && maxValue <= new BigInteger(decimal.MaxValue))
        {
            return Decimal;
        }
        return ImpossibleRepresentation;
    }
    private static string GetImpreciseFloatingPointNumberName(BigInteger minValue, BigInteger maxValue)
    {
        if (minValue >= new BigInteger(float.MinValue) && maxValue <= new BigInteger(float.MaxValue))
        {
            return Float;
        }
        if (minValue >= new BigInteger(double.MinValue) && maxValue <= new BigInteger(double.MaxValue))
        {
            return Double;
        }
        return ImpossibleRepresentation;
    }
}