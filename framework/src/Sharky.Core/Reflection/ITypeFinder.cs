using System;
using System.Collections.Generic;

namespace Sharky.Core.Reflection
{
    public interface ITypeFinder
    {
        IReadOnlyList<Type> Types { get; }
    }
}
