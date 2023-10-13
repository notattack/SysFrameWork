using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoginText : MonoBehaviour
{
    /// <summary>
    /// 定义组件
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
    /// 获取组件
    /// </summary>
    private void Start()
    {
        login = GameObject.Find("登录").GetComponent<Button>();
         sign = GameObject.Find("注册").GetComponent<Button>();
        number_text=GameObject.Find("账号Area/Text Area/Tn").GetComponent<TMP_Text>();
        password_text=GameObject.Find("密码Area/Text Area/Tp").GetComponent<TMP_Text>();
        
        login.onClick.AddListener(Login);
        sign.onClick.AddListener(Sign);
    }
    /// <summary>
    /// 延时跳转Login场景协程
    /// </summary>
    /// <returns></returns>
    IEnumerator GameLogin()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("ConfigPath");
    }
    /// <summary>
    /// 检测账号密码是否匹配
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
    /// 将注册信息存入变量
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
