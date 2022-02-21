using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanResourceManager : MonoBehaviour
{
    public RectTransform human_resource_ui; // 인력소 UI
    public RectTransform human_resource_slots; // 인력소 슬롯 부모
    public TempManager temp_manager; // 골드 관리용 게임매니저(임시)

    //public List<PlayerEntity> player_entity_Prefab = new List<PlayerEntity>();
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

}
