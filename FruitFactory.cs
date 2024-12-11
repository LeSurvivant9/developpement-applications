using UnityEditor;
using UnityEngine;

public abstract class FruitFactory : MonoBehaviour
{
    [SerializeField] private IFruitProduct prefab;

    public abstract IFruitProduct GetProduct(Vector2 position); 
    
}
