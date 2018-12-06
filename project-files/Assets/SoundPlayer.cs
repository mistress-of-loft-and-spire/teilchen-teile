using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class SoundPlayer : MonoBehaviour {

    string absolutePath = "./Sound/loops/"; // relative path to where the app is running

    public AudioSource src;
    List<AudioClip> clips = new List<AudioClip>();
    int soundIndex = 0;

    //compatible file extensions
    private List<string> validExtensions = new List<string> { ".ogg", ".wav" };

    FileInfo[] files;

    void Start () {
        //being able to test in unity
        if(Application.isEditor)    absolutePath = "Assets/Sound/loops/";
        if(src == null) src = gameObject.AddComponent<AudioSource>();
        reloadSounds();
    }

    public void PlayRnd()
    {
      if(clips.Count > 0) Play(Random.Range(0, clips.Count));
      else { Invoke ("PlayRnd", 2); Debug.Log("retry PlayRnd in 2 sec..."); }
    }

    void Play(int i)
    {
      src.clip = clips[i];
      src.Play();
    }

    void reloadSounds() {
        DirectoryInfo info = new DirectoryInfo(absolutePath);
        files = info.GetFiles();

        //check if the file is valid and load it
        foreach(FileInfo f in files) {
            if(validFileType(f.FullName)) {
                //Debug.Log("Start loading "+f.FullName);
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
