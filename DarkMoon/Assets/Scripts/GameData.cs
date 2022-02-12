using System.Collections;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public List<Dictionary<string, string>> card_list = new List<Dictionary<string, string>>();     // 파싱 된 json 내용이 저장 될 list
    // Start is called before the first frame update
    void Start()
    {
        ReadJsonData("CardList.json");              // CardList.json 파일을 파싱
    }
    public void ReadJsonData(string file_name)      // 게임에 쓰일 카드 정보들이 기록되어 있는 json 파일을 파싱하는 함수
    {
        string path = Application.dataPath + "/Scripts/Card/" + file_name;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            var cards = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);
            foreach (var card in cards)
            {
                card_list.Add(new Dictionary<string, string>(card));    // 파싱한 데이터를 list에 저장
            }
        }
    }
}
