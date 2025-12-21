using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    void Awake()
    {
        if(instance!=null && instance!=this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance=this;
        }
        
        DontDestroyOnLoad(this.gameObject);
    }

    public void ScoreAudio()
    {
        
    }

}
