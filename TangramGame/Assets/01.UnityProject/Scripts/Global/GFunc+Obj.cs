using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public static partial class GFunc
{
    //! Æ¯ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½Æ®ï¿½ï¿½ ï¿½Ú½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½Æ®ï¿½ï¿½ ï¿½ï¿½Ä¡ï¿½Ø¼ï¿½ Ã£ï¿½ï¿½ï¿½Ö´ï¿½ ï¿½Ô¼ï¿½
    public static GameObject FindChildObj(
        this GameObject targetObj_, string objName_)
    {
        GameObject searchResult = default;
        GameObject searchTarget = default;
        for (int i=0; i< targetObj_.transform.childCount; i++)
        {
            searchTarget = targetObj_.transform.GetChild(i).gameObject;
            if (searchTarget.name.Equals(objName_))
            {
                searchResult = searchTarget;
                return searchResult;
            }
            else
            {
                searchResult = FindChildObj(searchTarget, objName_);
            }
        }       // loop

        // ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½
        if(searchResult == null || searchResult == default) { /* Pass */ }
        else { return searchResult; }

        return searchResult;
    }       // FindChildObj()


    //! ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½Æ® ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½Æ®ï¿½ï¿½ ï¿½ï¿½Ä¡ï¿½Ø¼ï¿½ Ã£ï¿½ï¿½ï¿½Ö´ï¿½ ï¿½Ô¼ï¿½
    public static GameObject GetRootObj(string objName_)
    {
        Scene activeScene_ = GetActiveScene();
        GameObject[] rootObjs_ = activeScene_.GetRootGameObjects();

        GameObject targetObj_ = default;
        foreach(GameObject rootObj in rootObjs_)
        {
            if(rootObj.name.Equals(objName_))
            {
                targetObj_ = rootObj;
                return targetObj_;
            }
            else { continue; }
        }       // loop

        return targetObj_;
    }       // GetRootObj()
    public static RectTransform GetRect(this GameObject obj_)
    {
        return obj_.GetComponentMust<RectTransform>();
    }
    //! RectTransform ï¿½ï¿½ï¿½ï¿½ sizeDeltaï¿½ï¿½ Ã£ï¿½Æ¼ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½Ï´ï¿½ ï¿½Ô¼ï¿½
    public static Vector2 GetRectSizeDelta(this GameObject obj_)
    {
        return obj_.GetComponentMust<RectTransform>().sizeDelta;
    }       // GetRectSizeDelta()

    //! ï¿½ï¿½ï¿½ï¿½ È°ï¿½ï¿½È­ ï¿½Ç¾ï¿½ ï¿½Ö´ï¿½ ï¿½ï¿½ï¿½ï¿½ Ã£ï¿½ï¿½ï¿½Ö´ï¿½ ï¿½Ô¼ï¿½
    public static Scene GetActiveScene()
    {
        Scene activeScene_ = SceneManager.GetActiveScene();
        return activeScene_;
    }       // GetActiveScene()

    //! ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½Æ®ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½Ï´ï¿½ ï¿½Ô¼ï¿½
    public static void SetLocalPos(this GameObject obj_, 
        float x, float y, float z)
    {
        obj_.transform.localPosition = new Vector3(x, y, z);
    }       // SetLocalPos()

    //! ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½Æ®ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½Ï´ï¿½ ï¿½Ô¼ï¿½
    public static void AddLocalPos(this GameObject obj_, 
        float x, float y, float z)
    {
        obj_.transform.localPosition = 
            obj_.transform.localPosition + new Vector3(x, y, z);
    }       // AddLocalPos()
    //! ¿ÀºêÁ§Æ®ÀÇ ¾ÞÄ¿ Æ÷Áö¼ÇÀ» ¿¬»êÇÏ´Â ÇÔ¼ö
    public static void AddAnchorPos(this GameObject obj_, float x, float y)
    {
        obj_.GetRect().anchoredPosition+= new Vector2(x,y);
    }       // AddAnchorPos()

    //! ¿ÀºêÁ§Æ®ÀÇ ¾ÞÄ¿ Æ÷Áö¼ÇÀ» ¿¬»êÇÏ´Â ÇÔ¼ö
    public static void AddAnchorPos(this GameObject obj_, Vector2 position2D)
    {
        obj_.GetRect().anchoredPosition+=position2D;
    }       // AddAnchorPos()

    //! Æ®ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½Ø¼ï¿? ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½Æ®ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½Ì´ï¿½ ï¿½Ô¼ï¿½
    public static void Translate(this Transform transform_, Vector2 moveVector)
    {
        transform_.Translate(moveVector.x, moveVector.y, 0f);
    }       // Translate()

    //! ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½Æ® ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½Ô¼ï¿½
    public static T GetComponentMust<T>(this GameObject obj)
    {
        T component_ = obj.GetComponent<T>();

        GFunc.Assert(component_.IsValid<T>() != false, 
            string.Format("{0}ï¿½ï¿½ï¿½ï¿½ {1}ï¿½ï¿½(ï¿½ï¿½) Ã£ï¿½ï¿½ ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½Ï´ï¿½.",
            obj.name, component_.GetType().Name));

        return component_;
    }       // GetComponentMust()

    //! »õ·Î¿î ¿ÀºêÁ§Æ®¸¦ ¸¸µå¾î¼­ ÄÄÆ÷³ÍÆ®¸¦ ¸®ÅÏÇÏ´Â ÇÔ¼ö
    public static T CreateObj<T>(string objName) where T :Component
    {
        GameObject newobj = new GameObject(objName);
        return newobj.AddComponent<T>();
    }
}
