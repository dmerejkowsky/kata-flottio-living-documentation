using System;

namespace Flottio.Annotations
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