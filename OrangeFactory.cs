using UnityEngine;

public class OrangeFactory : FruitFactory
{
    [SerializeField] private OrangeProduct prefab;
    public override IFruitProduct GetProduct(Vector2 position)
    {
        GameObject created = Instantiate(prefab.gameObject, position, Quaternion.identity);
        OrangeProduct product = created.GetComponent<OrangeProduct>();
        product.Initialize();
        return product;

    }
}
