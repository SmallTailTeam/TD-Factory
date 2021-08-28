using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SmallTail.TdFactory.Core.Networking;

namespace SmallTail.TdFactory.Core.Entities
{
    public class Entity : Networked
    {
        private static List<Entity> _entities = new();

        public Vector2 Position;
        
        private List<EntityComponent> _components = new();

        protected Entity()
        {
        }

        public static void ForEach(Action<Entity> action)
        {
            foreach (Entity entity in _entities)
            {
                action(entity);
            }
        }
        
        public static T Create<T>() where T : Entity, new()
        {
            T entity = new T();
            
            _entities.Add(entity);
            
            return entity;
        }

        public void Destroy()
        {
            _entities.Remove(this);
        }
        
        public T GetComponent<T>() where T : EntityComponent
        {
            foreach (EntityComponent entityComponent in _components)
            {
                if (entityComponent.GetType() == typeof(T))
                {
                    return entityComponent as T;
                }
            }

            return null;
        }

        public List<EntityComponent> GetComponents()
        {
            return _components;
        }

        public void AddComponent(EntityComponent component)
        {
            component.Target = this;
            
            _components.Add(component);
        }

        public void RemoveComponent(EntityComponent component)
        {
            _components.Remove(component);
        }

        public void Update(GameTime gameTime)
        {
            foreach (EntityComponent entityComponent in _components)
            {
                entityComponent.Update(gameTime);
            }
        }
    }
}