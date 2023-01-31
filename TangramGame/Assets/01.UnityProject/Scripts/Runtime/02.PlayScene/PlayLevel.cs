using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayLevel : MonoBehaviour
{
    public int level = default;
    public List<PuzzleLvPart> puzzleLvParts = default;
    private const float LV_PUZZLE_DISTANCE_LIMIT = 1f;
    public void Awake()
    {
        GameManager.Instance.gameObjs.Add(gameObject.name, gameObject);
    }
    void Start()
    {
        // 자기 하위 오브젝트돌면서 하위오브젝트가 가진
        // PuzzleLvPart 스크립트를 리스트에 넣는다.
        puzzleLvParts = new List<PuzzleLvPart>();
        for(int i=0;i<transform.childCount;i++)
        {
            puzzleLvParts.Add( transform.GetChild(i).
                gameObject.GetComponentMust<PuzzleLvPart>());
        }       // loop : 레벨 하위에서 퍼즐 파츠를 모두 캐싱하는 루프
        //GameManager.Instance.gameObjs.Add(gameObject.name,gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //! 퍼즐 타입을 받아서 해당 타입과 같은 타입의 퍼즐을 리턴하는 함수
    private List<PuzzleLvPart> GetSameTypePuzzle(PuzzleType puzzleType)
    {
        List<PuzzleLvPart> sameTypes = new List<PuzzleLvPart>();
        foreach(var puzzleLvPart in puzzleLvParts)
        {
            if(puzzleLvPart.puzzleType.Equals(puzzleType))
            {
                sameTypes.Add(puzzleLvPart);
            }
            else{ continue; }
        }       // loop : 같은 타입의 퍼즐을 찾아주는 루프
        return sameTypes;
    }       // GetSameTypePuzzle()
     //! 가장 가까운 퍼즐을 찾아주는 함수
    public PuzzleLvPart GetCloseSameTypePuzzle(PuzzleType puzzleType,
     Vector3 puzzleWorldPos)
    {
        List<PuzzleLvPart> sameTypes = GetSameTypePuzzle(puzzleType);
        float minDistance = float.MaxValue;
        float distance = float.MaxValue;
        int index = 0;
        PuzzleLvPart result = default;
        foreach(var puzzleLvPart in sameTypes)
        {
            distance = Mathf.Abs((puzzleLvPart.transform.position - 
                puzzleWorldPos).magnitude);
            if(distance <= minDistance)
            {
                minDistance = distance;
                result = puzzleLvPart;
            }       // if : 가장 가까운 퍼즐을 캐싱한다.
            index++;
        }
        if(LV_PUZZLE_DISTANCE_LIMIT < minDistance)
        {
            result = default;
        }       // if : 너무 멀리있는 퍼즐은 생략한다.
        return result;
    }
}
