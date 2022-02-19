using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanResourceManager : MonoBehaviour
{
    public RectTransform human_resource_ui; // 인력소 UI
    public RectTransform human_resource_slots; // 인력소 슬롯 부모
    public TempManager temp_manager; // 골드 관리용 게임매니저(임시)

    public List<PlayerEntity> player_entity_Prefab = new List<PlayerEntity>();

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
                case 0:
                    human_resource_slots.GetChild(i).GetComponent<HumanResourceDisplay>().player_entity = player_entity_Prefab[random_class];
                    human_resource_slots.GetChild(i).GetComponent<HumanResourceDisplay>().player_entity.GetComponent<Mage>().StartSpec();

                    break;
                case 1:
                    human_resource_slots.GetChild(i).GetComponent<HumanResourceDisplay>().player_entity = player_entity_Prefab[random_class];
                    human_resource_slots.GetChild(i).GetComponent<HumanResourceDisplay>().player_entity.GetComponent<Priest>().StartSpec();

                    break;
                case 2:
                    human_resource_slots.GetChild(i).GetComponent<HumanResourceDisplay>().player_entity = player_entity_Prefab[random_class];
                    human_resource_slots.GetChild(i).GetComponent<HumanResourceDisplay>().player_entity.GetComponent<Rogue>().StartSpec();

                    break;
                case 3:
                    human_resource_slots.GetChild(i).GetComponent<HumanResourceDisplay>().player_entity = player_entity_Prefab[random_class];
                    human_resource_slots.GetChild(i).GetComponent<HumanResourceDisplay>().player_entity.GetComponent<Warrior>().StartSpec();

                    break;
                default:
                    break;


            }

            
        }
    }

}
