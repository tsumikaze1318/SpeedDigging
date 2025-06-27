using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//©2024 Sekkirtech

/*
 * 作成　
 * 東京デザインテクノロジーセンター専門学校
 * スーパーIT科スーパーゲームクリエイター専攻
 * 関海斗
 */




public class MusicManager : MonoBehaviour
{

    [SerializeField] AudioClip[] BGMList;
    [SerializeField] AudioClip[] SEList;


    //BGM用コンポーネント格納用
    private AudioSource BGMAudio;

    //インスタンス定義
    public static MusicManager MusicManagerInstance;

    void Start()
    {
        //破棄不能化
        DontDestroyOnLoad(this);

        //AudioSource格納
        BGMAudio = gameObject.AddComponent<AudioSource>();

        //ゲーム開始時0番を再生
        BGMAudio.clip = BGMList[0];
        
        //Loopがfalseだった時用
        BGMAudio.loop = true;
        BGMAudio.Play();
    }

    //シングルトン
    private void Awake()
    {
        if (MusicManagerInstance == null)
        {
            MusicManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

 
/*    /// <summary>
    /// 名前を元にBGMを切り替えたいときに呼び出してもらう
    /// </summary>
    /// <param name="name">BGM名</param>
    /// <param name="MusicVolume">音量1-100</param>
    public void SetNameBGM(string name,float MusicVolume)
    {
        for (int i = 0; i < BGMList.Length; i++)
        {
            if (name == BGMList[i].name)
            {
                BGMAudio.clip = BGMList[i];
                BGMAudio.volume = MusicVolume*0.01f;
                BGMAudio.Play();
                Debug.Log("BGMの" + BGMList[i].name + " を " + MusicVolume + " で再生");
                break;
            }
        }
        Debug.LogError("BGM名を確認してください");
    }*/


    /// <summary>
    /// Track番号を元にBGMを切り替え
    /// </summary>
    /// <param name="track">トラック番号</param>
    /// <param name="MusicVolume">音量1-100</param>
    public void SetTrackBGM(int track,float MusicVolume)
    {
        Debug.Log("SetTrackBGM");
        BGMAudio.volume = 0.5f;
        BGMAudio.volume = 0;
        BGMAudio.clip = BGMList[track];
        BGMAudio.volume = MusicVolume*0.01f;
        BGMAudio.Play();
        Debug.Log("BGMの" + track + " 番 " + BGMList[track].name + " を " + MusicVolume + " で再生");
    }

    //SEの後処理用コルーチン
    IEnumerator SEBreaker(AudioSource audioSource,float SEwait)
    {
        yield return new WaitForSeconds(SEwait);
        Destroy(audioSource);
    }

/*    /// <summary>
    /// 名前を元にSEを切り替えたいときに呼び出してもらう
    /// </summary>
    /// <param name="name">SE名</param>
    /// <param name="MusicVolume">音量1-100</param>
    public void CallNameSE(string name, float MusicVolume) 
    {
        AudioSource Ss = this.gameObject.AddComponent<AudioSource>();
        for (int i = 0; i < SEList.Length; i++)
        {
            if (name == SEList[i].name)
            {
                Ss.clip = SEList[i];
                Ss.volume = MusicVolume * 0.01f;
                Ss.Play();
                Debug.Log("SEの"+SEList[i].name +" を " + MusicVolume + " で再生");
                StartCoroutine(SEBreaker(Ss, SEList[i].length));
            }
        }
        Debug.LogError("SE名を確認してください");
    }*/
   
    /// <summary>
    /// Track番号を元にSEを再生
    /// </summary>
    /// <param name="track">トラック番号</param>
    /// <param name="MusicVolume">音量1-100</param>
    public void CallTrackSE(int track, float MusicVolume)
    {
        AudioSource Se=this.gameObject.AddComponent<AudioSource>();
            Se.clip = SEList[track];
            Se.volume = MusicVolume * 0.01f;
            Se.Play();
            Se.loop = false;
            Debug.Log("SEの"+　track + " 番 " + SEList[track].name + " を "+MusicVolume+" で再生");
            StartCoroutine(SEBreaker(Se, SEList[track].length));
    }

    /// <summary>
    /// BGMのフェードアウト
    /// </summary>
    /// <param name="fadetime">何秒かけて消えるか</param>
    public void FadeOut(float fadetime)
    {
        Counttime = 0f;
        Fadetime = fadetime;
        Isfadein = false;
        Isfadeout = true;
    }
    bool Isfadeout=false;
    bool Isfadein = false;
    float Counttime = 0.0f;
    float Fadetime = 1f;
    void Update()
    {
        if (Isfadeout)
        {
            Counttime += Time.deltaTime;
            if (Counttime >= Fadetime)
            {
                Counttime = Fadetime;
                Isfadeout = false;
            }
            BGMAudio.volume =1.0f - Counttime / Fadetime;
        }
        if (Isfadein)
        {
            Counttime += Time.deltaTime;
            if (Counttime >= Fadetime)
            {
                Counttime = Fadetime;
                Isfadein = false;
            }
            BGMAudio.volume = Counttime / Fadetime;
        }
    }

    /// <summary>
    /// 途中から再生
    /// </summary>
    /// <param name="fadetime">かける秒数</param>
    /// <param name="Track">トラック番号</param>
    /// <param name="DuringTime">再生開始時間（秒）</param>
    public void DuringStart(float fadetime,int Track,float DuringTime)
    {
        BGMAudio.volume = 0f;
        BGMAudio.clip = BGMList[Track];
        BGMAudio.time = DuringTime;
        Counttime = 0.0f;
        BGMAudio.Play();
        Isfadeout = false;
        Isfadein = true;
    } 

    /// <summary>
    /// 引数型SE
    /// </summary>
    /// <param name="clip">再生したいSEClip</param>
    /// <param name="MusicVolume">音量1-100</param>
    public void ArgumentSE(AudioClip clip,float MusicVolume)
    {
        Debug.Log("ArgumentSE");
        AudioSource Se=this.AddComponent<AudioSource>();
        Se.clip = clip;
        Se.volume = MusicVolume*0.01f;
        Se.Play();
        StartCoroutine(SEBreaker(Se,clip.length));
    }
}