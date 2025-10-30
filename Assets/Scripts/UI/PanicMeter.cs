using UnityEngine;
using UnityEngine.UI;

public class PanicMeter : MonoBehaviour
{
    #region Float Values

    public float PanicValue;
    public float MaxPanicValue;

    public float Timer;


    #endregion

    #region Bools

    public bool timeStart;

    #endregion

    #region UI Elements

    public Slider PanicSlider;
    public Slider TimerSlider;

    #endregion




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        TimerSlider.maxValue = Timer;
        TimerSlider.value = Timer;

        PanicSlider.maxValue = MaxPanicValue;
        PanicSlider.value = PanicValue;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timeStart == true)
        {

            Timer = Timer - Time.deltaTime;

            if (Timer <= 0 )
            {




            }

        }

    }


    public void UpdatePanic()
    {

        PanicSlider.value = PanicValue;

    }
}
