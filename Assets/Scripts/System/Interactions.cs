using System;
using TdFactory.Entities;

namespace TdFactory.System
{
    public interface IInteractable
    {
        void Interact(Interaction interaction);
    }

    public struct Interaction
    {
        public static Interaction Identity = new Interaction(null, InteractionType.Primary);
        private static Func<bool> Always = () => true;

        public Entity Interactor;
        public InteractionType Type;

        public enum InteractionType
        {
            Primary,
            Secondary
        }

        public Interaction(Entity interactor, InteractionType type)
        {
            Interactor = interactor;
            Type = type;
        }

        public Interaction Primary<T>(Action<T> interact, Func<bool> test = null) where T : Entity
        {
            if (test == null)
            {
                test = Always;
            }
            
            if (test() && Type == InteractionType.Primary && Interactor is T target)
            {
                interact(target);
            }

            return this;
        }

        public Interaction Secondary<T>(Action<T> interact, Func<bool> test = null) where T : Entity
        {
            if (test == null)
            {
                test = Always;
            }
            
            if (test() && Type == InteractionType.Secondary && Interactor is T target)
            {
                interact(target);
            }

            return this;
        }
        
        public static bool operator ==(Interaction x, Interaction y) 
        {
            return x.Interactor == y.Interactor && x.Type == y.Type;
        }
        
        public static bool operator !=(Interaction x, Interaction y) 
        {
            return x.Interactor != y.Interactor || x.Type != y.Type;
        }
        
        public static Interaction Primary(Entity entity)
        {
            return new Interaction(entity, InteractionType.Primary);
        }
        
        public static Interaction Secondary(Entity entity)
        {
            return new Interaction(entity, InteractionType.Secondary);
        }
    }
}