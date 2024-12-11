using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic; 

public class FruitGenerator : MonoBehaviour
{
    [SerializeField] private FruitFactory[] factories;
    [SerializeField] private Transform[] spawnPoints; 
    [SerializeField]private int nbrOfFruit = 4;
    private FruitFactory currentFactory;
    List<int> passedIndex = new List<int>();
    private int currentIndex;   

    private void Start()
    {
        SpawnFruit(nbrOfFruit); 
    }


    private void SpawnFruit(int nbr)
    {
        //first fruit 
        

        
        for (int i = 0; i < factories.Length ; i++)
        {
            do
            {
                currentIndex = Random.Range(0, spawnPoints.Length - 1);  //on prend un index al�atoire pour le point de spawn
            }while (passedIndex.Contains(currentIndex));     // on v�rifie qu'il n'est pas d�ja pass� sinon on le change
                       
            passedIndex.Add(currentIndex); //on ajoute cet index aux indexs d�ja utilis� 
            factories[i].GetProduct(spawnPoints[currentIndex].position);  //on fait spawner le fruit
            
        }
        
        for (int i = 0; i < nbrOfFruit - factories.Length; i++)
        {
            do
            {
                currentIndex = Random.Range(0, spawnPoints.Length - 1);  //on prend un index al�atoire pour le point de spawn
            } while (passedIndex.Contains(currentIndex));     // on v�rifie qu'il n'est pas d�ja pass� sinon on le change

            passedIndex.Add(currentIndex); //on ajoute cet index aux indexs d�ja utilis� 
            factories[Random.Range(0, factories.Length)].GetProduct(spawnPoints[currentIndex].position);  //on fait spawner le fruit
        }


    }



}
