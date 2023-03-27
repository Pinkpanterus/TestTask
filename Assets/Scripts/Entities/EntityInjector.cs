using Entities;
using UnityEngine;

public sealed class EntityInjector : MonoBehaviour
{
    private MonoEntity _entity;

    private void Awake()
    {
        _entity = GetComponent<MonoEntity>();

        /*
        foreach (Transform child in _entity.gameObject.transform)
        {
            var entityInjective = child.TryGetComponent(out IEntityInjective component);
            if (entityInjective)
            {
                component.Entity = _entity;
            }
        }*/
        
        
        var injectives = _entity.Elements<IEntityInjective>();

        foreach (var injective in injectives)
        {
            injective.Entity = _entity;
        }
    }
}
