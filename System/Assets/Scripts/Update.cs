using TMPro;
using System.IO;
using OfficeOpenXml;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Update : MonoBehaviour
{
    /// <summary>
    /// 定义组件
    /// </summary>
    #region 
    private TMP_InputField Update_ID_Text;
    private TMP_InputField T;
    private TMP_InputField T1;
    private TMP_InputField T2;
    private TMP_InputField T3;
    private TMP_InputField T4;
    private Button B_return;
    private Button B_sure;

    public GameObject success_text;
    public GameObject fail_text;

    public int u_id;
    private int[] id;
    #endregion
    /// <summary>
    /// 将已存在ID放入ID数组
    /// </summary>
    private void Awake()
    {
        string filePath = ConfigPath.Excel_path;

        FileInfo fileInfo = new FileInfo(filePath);

        //通过Excel表格文件信息，打开Excel
        using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
        {
            //读取Excel里的第一张表
            ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[1];

            id = new int[excelWorksheet.Dimension.Rows];
            for (int i = 2; i <= excelWorksheet.Dimension.Rows; i++)
            {
                id[i - 2] = Convert.ToInt32(excelWorksheet.GetValue(i, 1));
            }
        }
    }
    /// <summary>
    /// 获取组件
    /// </summary>
    private void Start()
    {
        Update_ID_Text = GameObject.Find("IDArea").GetComponent<TMP_InputField>();
        T = GameObject.Find("T").GetComponent<TMP_InputField>();
        T1 = GameObject.Find("T1").GetComponent<TMP_InputField>();
        T2 = GameObject.Find("T2").GetComponent<TMP_InputField>();
        T3 = GameObject.Find("T3").GetComponent<TMP_InputField>();
        T4 = GameObject.Find("T4").GetComponent<TMP_InputField>();

        B_return = GameObject.Find("返回").GetComponent<Button>();
        B_sure = GameObject.Find("确定").GetComponent<Button>();

        B_return.onClick.AddListener(Return);
        B_sure.onClick.AddListener(Sure);
    }
    /// <summary>
    /// 异步加载Menu场景
    /// </summary>
    void Return()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
    /// <summary>
    /// 失败成功判断，显示提示
    /// </summary>
    void Sure()
    {
        string filePath = ConfigPath.Excel_path;

        FileInfo fileInfo = new FileInfo(filePath);

        //通过Excel表格文件信息，打开Excel
        using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
        {
            //读取Excel里的第一张表
            ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[1];
            //excelPackage.Save();
            //int.TryParse(Update_ID_Text.text,out u_id);
            u_id = Convert.ToInt32(Update_ID_Text.text);
            //s_id = int.Parse(Update_ID_Text.text);
            //throw new ThrowOverflowOrFormatException();
            //Debug.Log(u_id);
            if (u_id >= 2)
            {
                for (int i = 2; i <= id.Length+1; i++)
                {
                    if (id[i - 2] == u_id)
                    {
                        //excelWorksheet.Cells[u_id, 1].Value = Update_ID_Text.text;
                        excelWorksheet.Cells[u_id, 2].Value = T.text;
                        excelWorksheet.Cells[u_id, 3].Value = T1.text;
                        excelWorksheet.Cells[u_id, 4].Value = T2.text;
                        excelWorksheet.Cells[u_id, 5].Value = T3.text;
                        excelWorksheet.Cells[u_id, 6].Value = T4.text;
                        excelPackage.Save();

                        success_text.SetActive(true);
                        Invoke("ActiveDes", 1);
                    }
                    else 
                    {
                        fail_text.SetActive(true);
                        Invoke("ActiveDef", 1);
                    }
                }
            }
        }
    }
    /// <summary>
    /// 成功提示
    /// </summary>
    void ActiveDes()
    {
        success_text.SetActive(false);
    }
    /// <summary>
    /// 失败提示
    /// </summary>
    void ActiveDef()
    {
        fail_text.SetActive(false);
    }
}
