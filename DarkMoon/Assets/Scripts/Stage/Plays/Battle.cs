using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : PlayBase
{
     public override void PlayClear(){  // 버튼을 클릭하면 해당 play를 클리어한 것으로 간주
        
        base.PlayClear();
    }

    public override void PlayDead(){  // play에서 사망하였을 때 실행되는 함수
        base.PlayDead();
    }
}
