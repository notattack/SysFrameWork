using TMPro;
using System.IO;
using OfficeOpenXml;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Select : MonoBehaviour
{
    /// <summary>
    /// �������
    /// </summary>
    #region
    private TMP_InputField Select_ID_Text;
    private TMP_Text T;
    private TMP_Text T1;
    private TMP_Text T2;
    private TMP_Text T3;
    private TMP_Text T4;
    private Button B_return;
    private Button B_sure;
    public GameObject success_text;
    public GameObject failure_text;

    public int s_id;
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
                id[i-2] = Convert.ToInt32(excelWorksheet.GetValue(i, 1));
            }
        }
    }
    /// <summary>
    /// ��ȡ���
    /// </summary>
    private void Start()
    {
        Select_ID_Text=GameObject.Find("IDArea").GetComponent<TMP_InputField>();
        T = GameObject.Find("T").GetComponent<TMP_Text>();
        T1 = GameObject.Find("T1").GetComponent<TMP_Text>();
        T2 = GameObject.Find("T2").GetComponent<TMP_Text>();
        T3 = GameObject.Find("T3").GetComponent<TMP_Text>();
        T4 = GameObject.Find("T4").GetComponent<TMP_Text>();

        B_return = GameObject.Find("����").GetComponent<Button>();
        B_sure = GameObject.Find("ȷ��").GetComponent<Button>();

        B_return.onClick.AddListener(Return);
        B_sure.onClick.AddListener(Sure);
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
            //int.TryParse(Select_ID_Text.text,out s_id);
            s_id = Convert.ToInt32(Select_ID_Text.text);
            //s_id = int.Parse(Select_ID_Text.text);
            //throw new ThrowOverflowOrFormatException();
            //Debug.Log(s_id);

            for (int i = 2; i <= id.Length+1; i++)
            {
                if (id[i - 2] == s_id)
                {
                    T.text = excelWorksheet.Cells[s_id, 2].Value.ToString();
                    T1.text = excelWorksheet.Cells[s_id, 3].Value.ToString();
                    T2.text = excelWorksheet.Cells[s_id, 4].Value.ToString();
                    T3.text = excelWorksheet.Cells[s_id, 5].Value.ToString();
                    T4.text = excelWorksheet.Cells[s_id, 6].Value.ToString();

                    success_text.SetActive(true);
                    Invoke("ActiveDes", 1);
                }
                else 
                {
                    failure_text.SetActive(true);
                    Invoke("ActiveDef", 1);
                }
            }
        }
    }
    /// <summary>
    /// �첽����Menu����
    /// </summary>
    void Return()
    {
        SceneManager.LoadSceneAsync("Menu");
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
        failure_text.SetActive(false);
    }
}
