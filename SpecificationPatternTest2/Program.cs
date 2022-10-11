using SpecificationPatternTest2.SpecificationPattern;

var rule = new TestSpecifiction().And(new Under10TestSpecificaation()).Or(new Over4Specification());
//read more into https://www.martinfowler.com/apsupp/spec.pdf and figure out how to best implementing some of the things that are mentioned
var test = rule.IsSatisfiedBy(7);


Console.WriteLine(test);




public class TestSpecifiction : CompositeSpecification<int>
{
    private int _test = 5;
    public override bool IsSatisfiedBy(int candidate)
    {
        return candidate != _test;
    }
}

public class Under10TestSpecificaation : CompositeSpecification<int>
{
    public override bool IsSatisfiedBy(int candidate)
    {
        return candidate < 10;
    }
}

public class Over4Specification : CompositeSpecification<int>
{
    public override bool IsSatisfiedBy(int candidate)
    {
        return candidate > 4;
    }
}

