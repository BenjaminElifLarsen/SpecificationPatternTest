namespace SpecificationPatternTest2.SpecificationPattern
{
    public interface ISpecification<T>
    { //based upon the wikipedia page.
        bool IsSatisfiedBy(T candidate);
        ISpecification<T> And(ISpecification<T> other);
        ISpecification<T> AndNot(ISpecification<T> other);
        ISpecification<T> Or(ISpecification<T> other);
        ISpecification<T> OrNot(ISpecification<T> other);
        ISpecification<T> Not();
    }

    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        public abstract bool IsSatisfiedBy(T candidate);

        public ISpecification<T> And(ISpecification<T> other)
        {
            return new AndSpecification<T>(this, other);
        }

        public ISpecification<T> AndNot(ISpecification<T> other)
        {
            throw new NotImplementedException();
        }

        public ISpecification<T> Not()
        {
            throw new NotImplementedException();
        }

        public ISpecification<T> Or(ISpecification<T> other)
        {
            return new OrSpecification<T>(this, other);
        }

        public ISpecification<T> OrNot(ISpecification<T> other)
        {
            throw new NotImplementedException();
        }
    }

    public class AndSpecification<T> : CompositeSpecification<T>
    {
        ISpecification<T> _left;
        ISpecification<T> _right;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _left = left;
            _right = right;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return _left.IsSatisfiedBy(candidate) && _right.IsSatisfiedBy(candidate);
        }
    }

    public class OrSpecification<T> : CompositeSpecification<T>
    {
        ISpecification<T> _left;
        ISpecification<T> _right;

        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _left = left;
            _right = right;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return _left.IsSatisfiedBy(candidate) || _right.IsSatisfiedBy(candidate);
        }
    }
}
