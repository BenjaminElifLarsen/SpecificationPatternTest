namespace NiaPortfolio.Common.SpecificationPattern;

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T candidate, ref int binaryFlag);
}
