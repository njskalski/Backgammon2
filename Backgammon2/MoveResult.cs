using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backgammon2
{
    public class MoveResult
    {
        public enum ResultType
        {
            Positive,
            Negative
        }

        public readonly ResultType Result;
        public readonly string Description;

        public MoveResult(ResultType _type, string _desc)
        {
            Result = _type;
            Description = _desc;
        }
    }
}
