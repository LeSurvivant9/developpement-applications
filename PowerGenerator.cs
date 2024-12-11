using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class PowerGenerator : MonoBehaviour
{
    [SerializeField] private Factory[] factories;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int nbrOfPower = 4;
    private Factory currentFactory;
    List<int> passedIndex = new List<int>();
    private int currentIndex;

    private void Start()
    {
        SpawnPower(nbrOfPower);
    }


    private void SpawnPower(int nbr)
    {
        //first fruit 



        for (int i = 0; i < factories.Length; i++)
        {
            do
            {
                currentIndex = Random.Range(0, spawnPoints.Length - 1);  //on prend un index aléatoire pour le point de spawn
            } while (passedIndex.Contains(currentIndex));     // on vérifie qu'il n'est pas déja passé sinon on le change

            passedIndex.Add(currentIndex); //on ajoute cet index aux indexs déja utilisé 
            factories[i].GetProduct(spawnPoints[currentIndex].position);  //on fait spawner le fruit

        }

        for (int i = 0; i < nbrOfPower - factories.Length; i++)
        {
            do
            {
                currentIndex = Random.Range(0, spawnPoints.Length - 1);  //on prend un index aléatoire pour le point de spawn
            } while (passedIndex.Contains(currentIndex));     // on vérifie qu'il n'est pas déja passé sinon on le change

            passedIndex.Add(currentIndex); //on ajoute cet index aux indexs déja utilisé 
            factories[Random.Range(0, factories.Length)].GetProduct(spawnPoints[currentIndex].position);  //on fait spawner le fruit
        }


    }



}
