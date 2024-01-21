using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    
    public static LevelManager instance { get; private set; }

    [SerializeField] private GameObject levelFailMenu;
    
    private int currentLevel;

    [SerializeField] private float[] levelLengths;
    private int levelAmt;

    private float timeLevelLoaded;
    private bool levelLoaded;

    private bool playerDead;
    
    public void KillPlayer(){
        levelFailMenu.SetActive(true);
        playerDead = true;
    }

    public bool GetPlayerState(){
        return playerDead;
    }

    public float getTimeLevelLoaded(){
        return timeLevelLoaded;
    }
    
    public void LoadNextLevel(){
        print($"a {currentLevel} {levelAmt}");
        
        if (currentLevel == levelAmt) {
            print("b");
            SceneManager.LoadScene("Scenes/MainMenu");
            currentLevel = -1;
            levelLoaded = false;
        }
        else {
            currentLevel++;
            SceneManager.LoadScene($"Scenes/Levels/Level {currentLevel}");
            timeLevelLoaded = Time.time;
            levelFailMenu.SetActive(false);
            levelLoaded = true;
        }

        playerDead = false;
    }

    public void ReloadLevel(){
        SceneManager.LoadScene($"Scenes/Levels/Level {currentLevel}");
        timeLevelLoaded = Time.time;
        levelFailMenu.SetActive(false);
        levelLoaded = true;
        playerDead = false;
    }
    
    private void Awake(){
        //singleton
        if (instance != null && instance != this) {
            Destroy(instance.gameObject);
            instance = this;
        }
        else {
            instance = this;
        } 
    }

    // Start is called before the first frame update
    void Start(){
        currentLevel = -1;
        levelLoaded = false;
        levelAmt = levelLengths.Length - 1;
        playerDead = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R)) {
            LoadNextLevel();
        }
        
        if (levelLoaded && timeLevelLoaded + levelLengths[currentLevel] < Time.time) {
            levelFailMenu.SetActive(true);
        }
        
    }
}
