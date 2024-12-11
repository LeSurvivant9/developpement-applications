using UnityEngine;

public class CherryFactory : FruitFactory
{
    [SerializeField] private CherryProduct prefab; 
    public override IFruitProduct GetProduct(Vector2 position)
    {
        GameObject created = Instantiate(prefab.gameObject , position, Quaternion.identity);    
        CherryProduct product = created.GetComponent<CherryProduct>();
        product.Initialize();
        return product; 

    }
}
