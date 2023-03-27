using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    [AddComponentMenu("Entities/Entity")]
    public class MonoEntity : MonoBehaviour, IEntity, ISerializationCallbackReceiver
    {
        [SerializeField]
        private List<MonoBehaviour> elements = new List<MonoBehaviour>();

        private Entity entity;

        public virtual T Element<T>()
        {
            return this.entity.Element<T>();
        }

        public virtual T[] Elements<T>()
        {
            return this.entity.Elements<T>();
        }

        public object[] Elements()
        {
            return this.entity.Elements();
        }

        public virtual void AddElement(object element)
        {
            this.entity.AddElement(element);
        }

        public virtual void RemoveElement(object element)
        {
            this.entity.RemoveElement(element);
        }

        public virtual bool TryElement<T>(out T element)
        {
            return this.entity.TryElement(out element);
        }

        public virtual void OnAfterDeserialize()
        {
            this.entity = new Entity(this.elements);
        }

        public virtual void OnBeforeSerialize()
        {
        }

#if UNITY_EDITOR
        public void Editor_AddElement(MonoBehaviour elements)
        {
            this.elements.Add(elements);
        }
#endif
    }
}