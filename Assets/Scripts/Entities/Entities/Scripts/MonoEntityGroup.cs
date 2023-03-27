using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    [AddComponentMenu("Entities/Entity Group")]
    public sealed class MonoEntityGroup : MonoEntity
    {
        [SerializeField]
        private MonoEntity[] entities = new MonoEntity[0];

        public override T Element<T>()
        {
            if (base.TryElement(out T result))
            {
                return result;
            }
            
            for (int i = 0, count = this.entities.Length; i < count; i++)
            {
                var entity = this.entities[i];
                if (entity.TryElement(out T element))
                {
                    return element;
                }
            }

            throw new Exception($"Element of type {typeof(T).Name} is not found!");
        }

        public override T[] Elements<T>()
        {
            var rootElements = base.Elements<T>();

            var list = new List<T>();
            list.AddRange(rootElements);
            
            for (int i = 0, count = this.entities.Length; i < count; i++)
            {
                var entity = this.entities[i];
                if (entity.TryElement(out T element))
                {
                    list.Add(element);
                }
            }

            return list.ToArray();
        }
        
        public override bool TryElement<T>(out T element)
        {
            if (base.TryElement(out element))
            {
                return true;
            }
            
            for (int i = 0, count = this.entities.Length; i < count; i++)
            {
                var entity = this.entities[i];
                if (entity.TryElement(out element))
                {
                    return true;
                }
            }

            return false;
        }
    }
}