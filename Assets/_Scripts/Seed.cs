using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public static Seed Instance;
   [SerializeField] private string GameSeed = "Deafult";
   public int CurrentSeed; 

   private void Awake() {
    Instance = this;
    CurrentSeed = GameSeed.GetHashCode();
    Random.InitState(CurrentSeed);

    
   }

}
