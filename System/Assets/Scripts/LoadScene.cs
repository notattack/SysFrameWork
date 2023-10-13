using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    /// <summary>
    /// 定义组件
    /// </summary>
    #region
    private Button addbutton;
    private Button deletebutton;
    private Button selectbutton;
    private Button updatebutton;

    //单例
    public static LoadScene Instance;
    //音效播放器
    public AudioSource se;
    #endregion
    /// <summary>
    /// 单例模式
    /// </summary>
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        addbutton = transform.Find("增").GetComponent<Button>();
        deletebutton = transform.Find("删").GetComponent<Button>();
        selectbutton = transform.Find("查").GetComponent<Button>();
        updatebutton = transform.Find("改").GetComponent<Button>();

        addbutton.onClick.AddListener(LoadAdd);
        deletebutton.onClick.AddListener(LoadDelete);
        selectbutton.onClick.AddListener(LoadSelect);
        updatebutton.onClick.AddListener(LoadUpdate);
    }
    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="path"></param>
    public void PlaySe(string path)
    {
        //从Resources文件夹中加载一个音效文件
        AudioClip clip = Resources.Load<AudioClip>(path);
        //播放音效
        se.PlayOneShot(clip);
    }
    /// <summary>
    /// 延时跳转Add场景
    /// </summary>
    /// <returns></returns>
    IEnumerator GameAdd()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Add");
    }
    /// <summary>
    /// 延时跳转Delete场景
    /// </summary>
    /// <returns></returns>
    IEnumerator GameDelete()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Delete");
    }
    /// <summary>
    /// 延时跳转Select场景
    /// </summary>
    /// <returns></returns>
    IEnumerator GameSelect()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Select");
    }
    /// <summary>
    /// 延时跳转Update场景
    /// </summary>
    /// <returns></returns>
    IEnumerator GameUpdate()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Update");
    }
    /// <summary>
    /// 开启协程加载场景，并播放音效
    /// </summary>
    #region
    void LoadAdd() { StartCoroutine("GameAdd");LoadScene.Instance.PlaySe("jian.mp3"); }
    void LoadDelete() { StartCoroutine("GameDelete"); LoadScene.Instance.PlaySe("jian.mp3"); }
    void LoadSelect() { StartCoroutine("GameSelect"); LoadScene.Instance.PlaySe("jian.mp3"); }
    void LoadUpdate() { StartCoroutine("GameUpdate"); LoadScene.Instance.PlaySe("jian.mp3"); }
    #endregion
}
