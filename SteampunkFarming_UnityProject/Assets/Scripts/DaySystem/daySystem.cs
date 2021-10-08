using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daySystem : MonoBehaviour
{
      public enum Time 
    {
      Morning, 
      Noon, 
      Night
    }

     public Time currentTime;
    // Start is called before the first frame update
    void Start()
    {
       currentTime = Time.Morning;
    }

    void Update ()
    {
        switch(currentTime)
        {
        case Time.Morning:
            Debug.Log("Morning");
            break;
        case Time.Noon:
            Debug.Log("Noon");
            break;
        case Time.Night:
            Debug.Log("Night");
            break;




        }



    }
    
}
