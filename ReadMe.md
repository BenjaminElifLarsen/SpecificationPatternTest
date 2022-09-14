# Purpose
The purpose of this small project was to test out some ideas using Specification Pattern for validation and see how well it would work with something like Result/Notification pattern.


## Observations
With the extension, a collection of ISpecification<T>s are created, which act as a one big boolean statement.
This means that it will stop running at the first false returned. In by itself this is fine and not a problem
However, if wanting to return error messages this will not do as it can only be used to see if something is wrong, but not what.
To get around this a ref int, acting as a binary flag, was added to the pattern. This can be used to see which ISpecification that failed.
This flag will not work correct, however, related to booleans specifications like AndNot. The reason for this is that the flag will indicate an error, where one was not as the ISpecification implementations looks at their own statements, not if they are part of an And, AndNot, etc.
This also means that it is possible for a validation to fail, but return a binary flag of 0.
