using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoginText : MonoBehaviour
{
    /// <summary>
    /// �������
    /// </summary>
    #region
    private Button login;
    private Button sign;
    private TMP_Text number_text;
    private TMP_Text password_text;
   
    public GameObject success_text;
    public GameObject error_text;
    public string num_t;
    public string pass_t;
    #endregion
    /// <summary>
    /// ��ȡ���
    /// </summary>
    private void Start()
    {
        login = GameObject.Find("��¼").GetComponent<Button>();
         sign = GameObject.Find("ע��").GetComponent<Button>();
        number_text=GameObject.Find("�˺�Area/Text Area/Tn").GetComponent<TMP_Text>();
        password_text=GameObject.Find("����Area/Text Area/Tp").GetComponent<TMP_Text>();
        
        login.onClick.AddListener(Login);
        sign.onClick.AddListener(Sign);
    }
    /// <summary>
    /// ��ʱ��תLogin����Э��
    /// </summary>
    /// <returns></returns>
    IEnumerator GameLogin()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("ConfigPath");
    }
    /// <summary>
    /// ����˺������Ƿ�ƥ��
    /// </summary>
    void Login()
    {
        if (number_text.text == num_t && password_text.text == pass_t) { StartCoroutine("GameLogin"); }
        //else return;
        else
            error_text.SetActive(true);
            Destroy(error_text, 2);
    }
    /// <summary>
    /// ��ע����Ϣ�������
    /// </summary>
    void Sign()
    {
        //if (number_text.text == null || password_text.text == null) return;
      
            num_t = number_text.text;
            pass_t = password_text.text;

            success_text.SetActive(true);
            Destroy(success_text, 2);
    }
}
