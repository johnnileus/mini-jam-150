using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    public static LevelManager instance { get; private set; }

    [SerializeField] private GameObject endOfLevelMenu;
    
    private int currentLevel;
    


    public void LoadNextLevel(){
        SceneManager.LoadScene($"Scenes/Level {currentLevel}");
    }
    
    private void Awake(){
        //singleton
        if (instance != null && instance != this) { Destroy(this); } else { instance = this; } 
    }

    // Start is called before the first frame update
    void Start(){
        currentLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) {
            LoadNextLevel();
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            endOfLevelMenu.SetActive(true);
        }
    }
}
