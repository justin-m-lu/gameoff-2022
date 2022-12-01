using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{

private float timer = 60.0f;
public Text disvar;

void Update() 
    {     
        if(timer>0)     
            {         
                timer -= Time.deltaTime;     
            }     
            double b = System.Math.Round (timer, 2);     
            disvar.text = b.ToString ();     

        if(timer < 0)     
            {         
            SceneManager.LoadScene("Win");
            } 
    }
}