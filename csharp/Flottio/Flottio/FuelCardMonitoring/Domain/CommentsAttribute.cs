using System;

namespace Flottio.FuelCardMonitoring.Domain
{
    public class CommentsAttribute : Attribute
    {
        public string Comments { get; }

        public CommentsAttribute(string comments)
        {
            Comments = comments;
        }
    }
}