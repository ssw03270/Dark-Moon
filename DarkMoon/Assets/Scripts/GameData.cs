using System.Collections;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public List<Dictionary<string, string>> card_list = new List<Dictionary<string, string>>();     // �Ľ� �� json ������ ���� �� list
    // Start is called before the first frame update
    void Start()
    {
        ReadJsonData("CardList.json");              // CardList.json ������ �Ľ�
    }
    public void ReadJsonData(string file_name)      // ���ӿ� ���� ī�� �������� ��ϵǾ� �ִ� json ������ �Ľ��ϴ� �Լ�
    {
        string path = Application.dataPath + "/Scripts/Card/" + file_name;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            var cards = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);
            foreach (var card in cards)
            {
                card_list.Add(new Dictionary<string, string>(card));    // �Ľ��� �����͸� list�� ����
            }
        }
    }
}
