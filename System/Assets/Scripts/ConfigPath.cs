using OfficeOpenXml;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfigPath : MonoBehaviour
{
    /// <summary>
    /// 定义组件
    /// </summary>
    #region
    private Button ok;
    private TMP_InputField T_path;
    private TMP_InputField attribute1;
    private TMP_InputField attribute2;
    private TMP_InputField attribute3;
    private TMP_InputField attribute4;
    private TMP_InputField attribute5;
    //private TMP_InputField attribute6;
    /// <summary>
    /// 表格路径
    /// </summary>
    static public string Excel_path;
    #endregion
    /// <summary>
    /// 配置表格头属性
    /// </summary>
    void My_Awake()
    {
        Excel_path = T_path.text;

        string filePath = Excel_path;

        FileInfo fileInfo = new FileInfo(filePath);

        //通过Excel表格文件信息，打开Excel
        using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
        {
            //excelPackage.Workbook.Worksheets.Add("Sheet1");

            //读取Excel里的第一张表
            ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[1];
            excelWorksheet.Cells[1, 1].Value = "ID";
            excelWorksheet.Cells[1, 2].Value = attribute1.text;
            excelWorksheet.Cells[1, 3].Value = attribute2.text;
            excelWorksheet.Cells[1, 4].Value = attribute3.text;
            excelWorksheet.Cells[1, 5].Value = attribute4.text;
            excelWorksheet.Cells[1, 6].Value = attribute5.text;
            //excelWorksheet.Cells[1, 7].Value = attribute6.text;
            excelPackage.Save();

            SceneManager.LoadSceneAsync("Menu");
        }
    }
    /// <summary>
    /// 获取组件
    /// </summary>
    private void Start()
    {
        T_path = transform.Find("WP").GetComponent<TMP_InputField>();
        attribute1 = transform.Find("1").GetComponent<TMP_InputField>();
        attribute2 = transform.Find("2").GetComponent<TMP_InputField>();
        attribute3 = transform.Find("3").GetComponent<TMP_InputField>();
        attribute4 = transform.Find("4").GetComponent<TMP_InputField>();
        attribute5 = transform.Find("5").GetComponent<TMP_InputField>();
        //attribute6 = transform.Find("6").GetComponent<TMP_InputField>();
        ok = transform.Find("OK").GetComponent<Button>();
        ok.onClick.AddListener(My_Awake);
    }
}
