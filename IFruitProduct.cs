using UnityEngine;

public interface IFruitProduct
{
    public string Name { get; set; }    
    public int Score { get; set; }

    public void Initialize();
    public void Behaviour(); 
}
