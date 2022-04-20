using System;

namespace Flottio.Annotations
{
    /**
    * Declares an external actor
*/
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class)]
    public class ExternalActorAttribute : Attribute
    {
        private readonly Direction direction;

        public string Name { get; }
        public ActorType Type { get; }

        public ExternalActorAttribute():
            this(default, ActorType.PEOPLE, default)
        {
        }

        public ExternalActorAttribute(string name, ActorType type, Direction direction)
        {
            Name = name;
            Type = type;
            this.direction = direction;
        }
        //String name() { return default; }

        //Direction direction() { return default; }

        //ActorType type() { return ActorType.PEOPLE; }

        String pictureLink() { return ""; }

        String link() { return ""; }
    }

    /**
     * The direction of who's calling who between the system and its external
     * actors
     */
    public enum Direction
    {
        /**
         * Calls the system
         */
        API,
        /**
         * Is called by the syste
         */
        SPI,

        /**
         * Calls the system and is called by the system
         */
        API_SPI
    }

    public enum ActorType
    {
        PEOPLE, SYSTEM
    }
}