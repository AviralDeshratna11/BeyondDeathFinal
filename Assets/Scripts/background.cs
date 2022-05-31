using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    Vector2 cameraPos;
    AudioSource myAudioSource;
    [SerializeField] AudioClip backgroundmusic;
    // Start is called before the first frame update
    void Start()
    {
        cameraPos = Camera.main.transform.position; ;
        myAudioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayingSound());

    }

    void BackgroundMusic()
    {
        AudioSource.PlayClipAtPoint(backgroundmusic, cameraPos);
    }
    public IEnumerator PlayingSound()
    {
        BackgroundMusic();
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(WaitForReload());
        

    }
    public IEnumerator WaitForReload()
    
    {
        yield return new WaitForSeconds(140f);
        StartCoroutine(PlayingSound());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
