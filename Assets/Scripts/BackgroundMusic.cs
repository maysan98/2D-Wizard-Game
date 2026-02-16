using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{       
    [SerializeField] AudioSource music;
    void Start()
    {
                music.Play();

    }

    // Update is called once per frame
    void Update()
    {
    }
}
