using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;

public class HumanResourceManager : MonoBehaviour
{
    public RectTransform human_resource_ui; // 인력소 UI
    public RectTransform human_resource_slots; // 인력소 슬롯 부모
    public TempManager temp_manager; // 골드 관리용 게임매니저(임시)

    public CampManager campManager;

    public Mage mage_Prefab;
    public Priest priest_Prefab;
    public Rogue rogue_Prefab;
    public Warrior warrior_Prefab;


    private void Awake()
    {
        ShopEntityDisplay();
    }

    public void HumanResourceEnterButton()
    {
        //human_resource_ui.gameObject.SetActive(true);
        human_resource_ui.anchoredPosition = Vector3.zero; // 상점 위치로 갖다 놓기
    }

    public void HumanResourceExitButton()
    {
        human_resource_ui.anchoredPosition = Vector3.right * 2000 + Vector3.up * 1000; // 안 보이게 갖다 놓기
        //human_resource_ui.gameObject.SetActive(false);
    }

    private void ShopEntityDisplay()
    // 인력소에 플레이어 엔티티 진열 함수
    {
        for (int i = 0; i < human_resource_slots.childCount; ++i)
        {
            int random_class = Random.Range(0, 4); // 0: Mage, 1: Priest, 2: Rogue, 3: Warrior

            switch (random_class)
            {
                case 0: // Mage
                    mage_Prefab.StartSpec();
                    mage_Prefab.SetSpec(human_resource_slots.GetChild(i).GetComponent<HumanResourceDisplay>().player_entity_data);
                    break;
                case 1: // Priest
                    priest_Prefab.StartSpec();
                    priest_Prefab.SetSpec(human_resource_slots.GetChild(i).GetComponent<HumanResourceDisplay>().player_entity_data);
                    break;
                case 2: // Rogue
                    rogue_Prefab.StartSpec();
                    rogue_Prefab.SetSpec(human_resource_slots.GetChild(i).GetComponent<HumanResourceDisplay>().player_entity_data);
                    break;
                case 3: // Warrior
                    warrior_Prefab.StartSpec();
                    warrior_Prefab.SetSpec(human_resource_slots.GetChild(i).GetComponent<HumanResourceDisplay>().player_entity_data);
                    break;
                default:
                    break;


            }

            
        }
    }

    public void BuyPlayer()
    {
        GameObject player_button = EventSystem.current.currentSelectedGameObject; // 클릭한 플레이어 버튼 오브젝트
        PlayerEntityData player_entity_data = player_button.GetComponent<HumanResourceDisplay>().player_entity_data; // 플레이어 데이터 정보
        string path = Path.Combine(Application.dataPath, "Scripts", "playerData.json"); // json 저장 경로

        // player_list에서 정보 뽑아와서 그 뒤에 추가
        campManager.player_data_list.Add(player_entity_data);

        campManager.playerList.playerEntityData = campManager.player_data_list.ToArray();


        string json_data = JsonUtility.ToJson(campManager.playerList, true);
        
        File.WriteAllText(path, json_data);

        player_button.SetActive(false);
    }

}
