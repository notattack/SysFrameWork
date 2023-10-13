using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Add : MonoBehaviour
{
    /// <summary>
    /// �������
    /// </summary>
    #region
    private TMP_InputField Add_ID_Text;
    private TMP_InputField T;
    private TMP_InputField T1;
    private TMP_InputField T2;
    private TMP_InputField T3;
    private TMP_InputField T4;
    private Button B_return;
    private Button B_sure;

    public GameObject success_text;
    public GameObject fail_text;

    public int a_id;
    private int[] id;
    #endregion
    /// <summary>
    /// ���Ѵ���ID����ID����
    /// </summary>
    private void Awake()
    {
        string filePath = ConfigPath.Excel_path;

        FileInfo fileInfo = new FileInfo(filePath);

        //ͨ��Excel����ļ���Ϣ����Excel
        using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
        {
            //��ȡExcel��ĵ�һ�ű�
            ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[1];

            id = new int[excelWorksheet.Dimension.Rows];
            for (int i = 2; i <= excelWorksheet.Dimension.Rows; i++)
            {
                id[i - 2] = Convert.ToInt32(excelWorksheet.GetValue(i, 1));//���Ѵ��ڵ�ID����id����
            }
        }
    }
    /// <summary>
    /// ��ȡ���
    /// </summary>
    private void Start()
    {
        Add_ID_Text = GameObject.Find("IDArea").GetComponent<TMP_InputField>();
        T = GameObject.Find("T").GetComponent<TMP_InputField>();
        T1 = GameObject.Find("T1").GetComponent<TMP_InputField>();
        T2 = GameObject.Find("T2").GetComponent<TMP_InputField>();
        T3 = GameObject.Find("T3").GetComponent<TMP_InputField>();
        T4 = GameObject.Find("T4").GetComponent<TMP_InputField>();

        B_return = GameObject.Find("����").GetComponent<Button>();
        B_sure = GameObject.Find("ȷ��").GetComponent<Button>();

        B_return.onClick.AddListener(Return);
        B_sure.onClick.AddListener(Sure);
    }
    /// <summary>
    /// �첽����Menu����
    /// </summary>
    void Return()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
    /// <summary>
    /// ʧ�ܳɹ��жϣ���ʾ��ʾ
    /// </summary>
    void Sure()
    {
        string filePath = ConfigPath.Excel_path;

        FileInfo fileInfo = new FileInfo(filePath);

        //ͨ��Excel����ļ���Ϣ����Excel
        using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
        {
            //��ȡExcel��ĵ�һ�ű�
            ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[1];
            //excelPackage.Save();
            //int.TryParse(Add_ID_Text.text,out a_id);
            a_id = Convert.ToInt32(Add_ID_Text.text);
            //a_id = int.Parse(Add_ID_Text.text);
            //throw new ThrowOverflowOrFormatException();
            //Debug.Log(a_id);
            if (a_id >= 2)
            {
                for (int i = 2; i <= id.Length+1; i++)
                {
                    if (id[i - 2] != a_id)
                    {
                        excelWorksheet.Cells[a_id, 1].Value = Add_ID_Text.text;
                        excelWorksheet.Cells[a_id, 2].Value = T.text;
                        excelWorksheet.Cells[a_id, 3].Value = T1.text;
                        excelWorksheet.Cells[a_id, 4].Value = T2.text;
                        excelWorksheet.Cells[a_id, 5].Value = T3.text;
                        excelWorksheet.Cells[a_id, 6].Value = T4.text;
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
    /// �ɹ���ʾ
    /// </summary>
    void ActiveDes()
    {
        success_text.SetActive(false);
    }
    /// <summary>
    /// ʧ����ʾ
    /// </summary>
    void ActiveDef()
    {
        fail_text.SetActive(false);
    }
}
