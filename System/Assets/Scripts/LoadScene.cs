using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    /// <summary>
    /// �������
    /// </summary>
    #region
    private Button addbutton;
    private Button deletebutton;
    private Button selectbutton;
    private Button updatebutton;

    //����
    public static LoadScene Instance;
    //��Ч������
    public AudioSource se;
    #endregion
    /// <summary>
    /// ����ģʽ
    /// </summary>
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        addbutton = transform.Find("��").GetComponent<Button>();
        deletebutton = transform.Find("ɾ").GetComponent<Button>();
        selectbutton = transform.Find("��").GetComponent<Button>();
        updatebutton = transform.Find("��").GetComponent<Button>();

        addbutton.onClick.AddListener(LoadAdd);
        deletebutton.onClick.AddListener(LoadDelete);
        selectbutton.onClick.AddListener(LoadSelect);
        updatebutton.onClick.AddListener(LoadUpdate);
    }
    /// <summary>
    /// ������Ч
    /// </summary>
    /// <param name="path"></param>
    public void PlaySe(string path)
    {
        //��Resources�ļ����м���һ����Ч�ļ�
        AudioClip clip = Resources.Load<AudioClip>(path);
        //������Ч
        se.PlayOneShot(clip);
    }
    /// <summary>
    /// ��ʱ��תAdd����
    /// </summary>
    /// <returns></returns>
    IEnumerator GameAdd()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Add");
    }
    /// <summary>
    /// ��ʱ��תDelete����
    /// </summary>
    /// <returns></returns>
    IEnumerator GameDelete()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Delete");
    }
    /// <summary>
    /// ��ʱ��תSelect����
    /// </summary>
    /// <returns></returns>
    IEnumerator GameSelect()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Select");
    }
    /// <summary>
    /// ��ʱ��תUpdate����
    /// </summary>
    /// <returns></returns>
    IEnumerator GameUpdate()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Update");
    }
    /// <summary>
    /// ����Э�̼��س�������������Ч
    /// </summary>
    #region
    void LoadAdd() { StartCoroutine("GameAdd");LoadScene.Instance.PlaySe("jian.mp3"); }
    void LoadDelete() { StartCoroutine("GameDelete"); LoadScene.Instance.PlaySe("jian.mp3"); }
    void LoadSelect() { StartCoroutine("GameSelect"); LoadScene.Instance.PlaySe("jian.mp3"); }
    void LoadUpdate() { StartCoroutine("GameUpdate"); LoadScene.Instance.PlaySe("jian.mp3"); }
    #endregion
}
