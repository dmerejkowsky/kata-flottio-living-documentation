using System;

namespace Flottio.Annotations
{
    /**
    * The list of all principles the team agrees on.
*/
    public enum Codex
    {

        /**
         * We have no clue to explain this decision
         */
        NO_CLUE,

        /**
         * There must be only one single authoritative place for each piece of data
         */
        SINGLE_GOLDEN_SOURCE,

        /** Keep your middleware dumb, and keep the smarts in the endpoints. */
        DUMP_MIDDLEWARE
    }

    public class CodexClass
    {
        private readonly String author;

        public CodexClass(String author)
        {
            this.author = author;
        }

        public string GetValue(Codex codex)
        {
            switch (codex)
            {
                case Codex.NO_CLUE:
                    return "Nobody";
                case Codex.SINGLE_GOLDEN_SOURCE:
                    return "Team";
                case Codex.DUMP_MIDDLEWARE:
                    return "Sam Newman";
                default:
                    throw new InvalidCastException();
            }
        }
    }
}