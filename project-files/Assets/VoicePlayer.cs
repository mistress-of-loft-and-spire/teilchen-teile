using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class VoicePlayer : MonoBehaviour {

    string absolutePath = "./Sound/hits/"; // relative path to where the app is running

    public AudioSource src;
    List<AudioClip> clips = new List<AudioClip>();
    int soundIndex = 0;

    private int timer = 100;

    //compatible file extensions
    private List<string> validExtensions = new List<string> { ".ogg", ".wav" };

    FileInfo[] files;

    void Start () {
        //being able to test in unity
        if(Application.isEditor)    absolutePath = "Assets/Sound/hits/";
        if(src == null) src = gameObject.AddComponent<AudioSource>();
        reloadSounds();

        timer = Random.Range(108000,600000);
    }

    void setTimer()
    {
      timer = Random.Range(300,600);
    }

    void Update ()
  	{
      timer -= 1;

      if(timer < 0)
      {
          setTimer();

          src.clip = clips[soundIndex];
          src.Play();

          soundIndex += 1;

          if(soundIndex > 10)
          {
            timer = Random.Range(108000,600000);
            soundIndex = 0;
          }
      }
    }

    void reloadSounds() {
        DirectoryInfo info = new DirectoryInfo(absolutePath);
        files = info.GetFiles();

        //check if the file is valid and load it
        foreach(FileInfo f in files) {
            if(validFileType(f.FullName)) {
                Debug.Log("Start loading "+f.FullName);
                StartCoroutine(loadFile(f.FullName));
            }
        }
    }

    bool validFileType(string filename) {
        return validExtensions.Contains(Path.GetExtension(filename));
    }

    IEnumerator loadFile(string path) {
        WWW www = new WWW("file://"+path);

        AudioClip myAudioClip = www.GetAudioClip();
        while (!myAudioClip.isReadyToPlay)
        yield return www;

        AudioClip clip = www.GetAudioClip(false);
        string[] parts = path.Split('\\');
        clip.name = parts[parts.Length - 1];
        clips.Add(clip);
    }
}
