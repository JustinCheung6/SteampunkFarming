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

       public Day currentDay; //Define Day

    // Start is called before the first frame update
    void Start()
    {
       currentDay = Day.Monday; //Day at Start of Game
       dayNumber = 1;
    }

    void FixedUpdate ()
    {
      if (currentDay == Day.Monday)
         {
            StartCoroutine (delayPlease ());
         }

         IEnumerator delayPlease()
         {
            currentDay = Day.Monday;
            Debug.Log("Monday");
            yield return new WaitForSeconds (2);
            StartCoroutine (delayPlease2());
         }

         IEnumerator delayPlease2()
         {
            currentDay = Day.Tuesday;
            Debug.Log("Tuesday");
            yield return new WaitForSeconds (2);
            StartCoroutine (delayPlease3());
         }
         
         IEnumerator delayPlease3()
         {
            currentDay = Day.Wednesday;
            Debug.Log("Wednesday");
            yield return new WaitForSeconds (2);
            StartCoroutine (delayPlease4());
         }
         
         IEnumerator delayPlease4()
         {
            currentDay = Day.Thursday;
            Debug.Log("Thursday");
            yield return new WaitForSeconds (2);
            StartCoroutine (delayPlease5());
         }
        
         IEnumerator delayPlease5()
         {
            currentDay = Day.Friday;
            Debug.Log("Friday");
            yield return new WaitForSeconds (2);
            StartCoroutine (delayPlease6());
         }
         
         IEnumerator delayPlease6()
         {
            currentDay = Day.Saturday;
            Debug.Log("Saturday");
            yield return new WaitForSeconds (2);
            StartCoroutine (delayPlease7());
         }

         IEnumerator delayPlease7()
         {
            currentDay = Day.Sunday;
            Debug.Log("Sunday");
            yield return new WaitForSeconds (2);
            currentDay = Day.Monday;
         }

      

         
         
         
         
         

         
         


    }
 
}
