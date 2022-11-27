using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public static DayManager Instance;

    [Header("Variables")]
    [SerializeField] private float _dayTimeDuration;
    [SerializeField] private float _nightDuration;
    [SerializeField] private float _currentTime;
    private float _dayDuration;
    private enum DayState {day, night};
    [SerializeField] private DayState _state;
    [SerializeField]  private int _timeSpeed;


    [Header("Assigments")]
    public Light light;


    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Get time from save


        _dayDuration = _dayTimeDuration + _nightDuration;

        _state = DayState.day;
    }

    // Update is called once per frame
    void Update()
    {
        _currentTime += Time.deltaTime * _timeSpeed;

        if(_currentTime >=_dayDuration)
        {
            _currentTime= 0;
        }

        if(_state == DayState.day)
        {
            SetDayTime();
        }
        else if(_state== DayState.night)
        {
            SetNightTime();
        }

        if(_currentTime > 300 && _currentTime < 300 + _dayTimeDuration)
        {
            _state = DayState.day;
        }
        else if(_currentTime < 300 || _currentTime > 300 + _dayTimeDuration)
        {
            _state = DayState.night;
        }

        print($"DayState: {_state}");

        
    }

    public void SetTimeSpeed(int TimeSpeed)
    {
        _timeSpeed = TimeSpeed;
    }

    private void SetNightTime()
    {
        light.intensity = Mathf.Lerp(2f, 0.2f,1f);
    }
    public void SetDayTime()
    {
        light.intensity = Mathf.Lerp(0.2f, 2f, 1f);

    }
}
