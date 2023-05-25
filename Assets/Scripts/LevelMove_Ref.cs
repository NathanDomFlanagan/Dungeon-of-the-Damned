using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class LevelMove_Ref : MonoBehaviour
{
    public int sceneBuildIndex;
    public bool isEnter;

    private GameObject spawnPoint;
    private PlayerTransition pt;

    // Level move zoned enter, if collider is a player
    // Move game to another scene
    private void OnTriggerEnter2D(Collider2D other) 
    {
        //Print statements to see if the trigger worked
        print("Trigger Entered");

        // I might use other.GetComponent<Player>() to see if the game object has a Player component
        // Ill use Tags as Tags work.
        // If statement simply grabs the tag of an object that collides with the trigger,
        // if the object has the tag of "Player" then it will trigger code 
        if (other.tag == "Player")
        {
            // Player entered, so move level to next scene and print the scene id
            print("Switching Scene to " + sceneBuildIndex);
            // Simple way to grab the next scene, and load it while unloading the previous scene
            // to have oly one active room (saving space)
            other.GetComponent<PlayerController>().isEnter = isEnter;
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
