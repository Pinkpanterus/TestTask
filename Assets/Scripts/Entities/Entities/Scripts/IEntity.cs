namespace Entities
{
    public interface IEntity
    {
        T Element<T>();

        T[] Elements<T>();

        bool TryElement<T>(out T element);

        object[] Elements();
        
        void AddElement(object element);

        void RemoveElement(object element);
    }
}