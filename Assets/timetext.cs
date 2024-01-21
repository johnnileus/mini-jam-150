using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timetext : MonoBehaviour{


    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI timeinittext;

    private float initTime;
    
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        initTime = LevelManager.instance.getTimeLevelLoaded();
        timeText.text = $"time: {Time.time}";
        timeinittext.text = $"init time: {Time.time - initTime}";
    }
}
