using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Delete : MonoBehaviour
{
    /// <summary>
    /// 定义组件
    /// </summary>
    #region 
    private TMP_InputField Delete_ID_Text;
    
    private Button B_return;
    private Button B_sure;

    public GameObject success_text;
    public GameObject fail_text;

    public int d_id;
    private int[] id;
    #endregion
    /// <summary>
    /// 失败成功判断，显示提示
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
                id[i-2] = Convert.ToInt32(excelWorksheet.GetValue(i, 1));
            }
        }
    }
    /// <summary>
    /// 获取组件
    /// </summary>
    private void Start()
    {
        Delete_ID_Text = GameObject.Find("IDArea").GetComponent<TMP_InputField>();

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
            //int.TryParse(Delete_ID_Text.text,out d_id);
            d_id = Convert.ToInt32(Delete_ID_Text.text);
            //d_id = int.Parse(Delete_ID_Text.text);
            //throw new ThrowOverflowOrFormatException();
            //Debug.Log(d_id);
            for (int i = 2; i <= id.Length+1; i++)
            {
                if (id[i - 2] == d_id)
                {
                    excelWorksheet.Cells[d_id, 1].Value = null;
                    excelWorksheet.Cells[d_id, 2].Value = null;
                    excelWorksheet.Cells[d_id, 3].Value = null;
                    excelWorksheet.Cells[d_id, 4].Value = null;
                    excelWorksheet.Cells[d_id, 5].Value = null;
                    excelWorksheet.Cells[d_id, 6].Value = null;
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
