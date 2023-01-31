using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleInitZone : MonoBehaviour
{
    // 퍼즐플레이파츠 찾기 쉽도록 변수설정
    public Canvas parentCanvas = default;
    // Start is called before the first frame update
    void Start()
    {
        // 부모 캔버스가 비었을 때 경고호출
        GFunc.Assert(parentCanvas != null || parentCanvas != default);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
