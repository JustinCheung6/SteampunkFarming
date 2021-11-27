using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class daySystem : MonoBehaviour
{
      public int dayNumber;

      public enum Day //One Week
    {
      Monday, 
      Tuesday, 
      Wednesday,
      Thursday,
      Friday,
      Saturday,
      Sunday
    } 
    private string[] dayNames = 
    {
    "Monday",
    "Tuesday",
    "Wednesday",
    "Thursday",
    "Friday",
    "Saturday",
    "Sunday"
    };
      private float timer = 00.0f;
      private string dayName = "";

      public Day currentDay; //Define Day

    // Start is called before the first frame update
    void Start()
    {
       currentDay = Day.Monday; //Day at Start of Game
       Debug.Log("Monday");
       dayNumber = 1;
    }
    
    private void FixedUpdate()
    {
         timer += Time.deltaTime;
         if(timer >= 10)
         {
            timer = 0;
            ChangeDay();
         }

    void ChangeDay()
     {
         dayNumber++;
         if (currentDay == Day.Sunday)
         {
            currentDay = Day.Monday;
         }
   
        else
         {
              currentDay++;
         }

         dayName = dayNames[(int)currentDay];

         Debug.Log(dayName);
      }   


      

         
         
         
         
         

         
         


    }
 
}
