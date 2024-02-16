using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scripts : MonoBehaviour
{

    public Transform HourHand;
    public Transform MinuteHand;
    public Transform SecondHand;


    public int PreviousSeconds;
    public int timeInSeconds;

    public bool motionInSecondHand = true;

    void Update()
    {
        if (motionInSecondHand == true)
        { 
            SystemTime();
            RotateHands();
        }
    }

    public void SystemTime()
    {
        int CurrentHour = System.DateTime.Now.Hour;
        int CurrentMinute = System.DateTime.Now.Minute;
        int CurrentSecond = System.DateTime.Now.Second;

        //        Debug.Log(CurrentHour + " " + CurrentMinute + " " + CurrentSecond);

        if (CurrentHour >= 12)
        {
            CurrentHour -= 12;
        }

        timeInSeconds = CurrentSecond + (CurrentMinute * 60) + (CurrentHour * 60 * 60);
//        Debug.Log(timeInSeconds);
    }

    public void RotateHands()
    {
        float SecondHandPerSecond = 360f / 60f ;
        float MinuteHandPerSecond = 360f / (60f * 60f);
        float HourHandPerSecond = 360f / (60f * 60f * 12f);

        //Debug.Log(HourHandPerSecond + " " + MinuteHandPerSecond + " " + SecondHandPerSecond);

/*        var rotationSeconds = ((float)(System.DateTime.Now.Second + System.DateTime.Now.Millisecond / 1000f) / 60f) * 360;
        secondHandInMotion.transform.localEulerAngles = new Vector3(0, 0, rotationSeconds);
*/

        if (timeInSeconds != PreviousSeconds)
        { 
            SecondHand.localRotation = Quaternion.Euler(0, 0, -timeInSeconds * SecondHandPerSecond);
            MinuteHand.localRotation = Quaternion.Euler(0, 0, -timeInSeconds * MinuteHandPerSecond);
            HourHand.localRotation = Quaternion.Euler(0, 0, -timeInSeconds * HourHandPerSecond);
        }

        PreviousSeconds = timeInSeconds;
    }


    public Transform secondHandInMotion;
    float rotationSpeed = 6f;

    public void RotateHandsInMotion()
    {
        float SecondHandPerSecond = 360f;
        float MinuteHandPerSecond = 360f / (60f * 60f);
        float HourHandPerSecond = 360f / (60f * 60f * 12f);

        float seconds = Time.time % 360;
        float rotate = seconds * -6f;
        Debug.Log(rotate);
        //Debug.Log(HourHandPerSecond + " " + MinuteHandPerSecond + " " + SecondHandPerSecond);

        if (timeInSeconds != PreviousSeconds)
        {
                        Quaternion Target = Quaternion.Euler(0, 0, rotate);
                        secondHandInMotion.localRotation = Quaternion.Lerp(secondHandInMotion.transform.rotation, Target, rotationSpeed * 60f * Time.deltaTime);
            
            //            secondHandInMotion.eulerAngles = new Vector3(0,0, -Time.realtimeSinceStartup * 90f);

            //transform.position = Vector3.Lerp(.transform.position, );

            MinuteHand.localRotation = Quaternion.Euler(0, 0, -timeInSeconds * MinuteHandPerSecond);
            HourHand.localRotation = Quaternion.Euler(0, 0, -timeInSeconds * HourHandPerSecond);
        }

        PreviousSeconds = timeInSeconds;
    }


/*    void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        //or
        //other.GetComponent<Renderer>().enabled = false;
    }
*/
}
