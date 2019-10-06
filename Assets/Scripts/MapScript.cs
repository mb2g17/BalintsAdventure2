using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToFireArea()
    {
        SceneManager.LoadScene("FireArea");
    }

    public void GoToWaterArea()
    {
        SceneManager.LoadScene("WaterArea");
    }
    public void GoToWindArea()
    {
        SceneManager.LoadScene("WindArea");
    }
    public void GoToEarthArea()
    {
        SceneManager.LoadScene("EarthArea");
    }
    public void GoToThunderArea()
    {
        SceneManager.LoadScene("ThunderArea");
    }
}
