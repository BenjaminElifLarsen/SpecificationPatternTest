using NiaPortfolio.Common.SpecificationPattern;
using NiaPortfolio.Common.SpecificationPattern.Extensions;

var rule = new IsNumberBiggerThan50().And(new IsNumberLessThan100()).And(new IsNumberNotEqualTo53()).And(new IsNunberNotEqualTo3());
int flag51 = 0, flag49 = 0, flag53 = 0, flag3 = 0;
var number51 = rule.IsSatisfiedBy(51, ref flag51); 
var number49 = rule.IsSatisfiedBy(49, ref flag49);
var number53 = rule.IsSatisfiedBy(53, ref flag53);
var number3 = rule.IsSatisfiedBy(3, ref flag3);

Console.WriteLine($"{number51}, {flag51}");
Console.WriteLine($"{number49}, {flag49}");
Console.WriteLine($"{number53}, {flag53}");
Console.WriteLine($"{number3}, {flag3}");

class IsNumberLessThan100 : ISpecification<int>
{
    public bool IsSatisfiedBy(int candidate, ref int binaryFlag)
    {
        bool satisfied = candidate < 100;
        if (!satisfied)
        {
            binaryFlag = 0b1;
        }
        return satisfied;
    }
}

class IsNumberBiggerThan50 : ISpecification<int>
{
    public bool IsSatisfiedBy(int candidate, ref int binaryFlag)
    {
        bool satisfied = candidate > 50;
        if (!satisfied)
        {
            binaryFlag = 0b10;
        }
        return satisfied;
    }
}

class IsNunberNotEqualTo3 : ISpecification<int>
{
    public bool IsSatisfiedBy(int candidate, ref int binaryFlag)
    {
        bool satisfied = candidate != 3;
        if (!satisfied)
        {
            binaryFlag = 0b1000;
        }
        return satisfied;
    }
}

class IsNumberNotEqualTo53 : ISpecification<int>
{
    public bool IsSatisfiedBy(int candidate, ref int binaryFlag)
    {
        bool satisfied = candidate != 53;
        if (!satisfied)
        {
            binaryFlag = 0b100;
        }
        return satisfied;
    }
}