using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PRS
{
    public Vector3 pos;
    public Quaternion rot;
    public Vector3 scale;

    public PRS(Vector3 pos, Quaternion rot, Vector3 scale)
    {
        this.pos = pos;
        this.rot = rot;
        this.scale = scale;
    }
}
public class Card : MonoBehaviour
{
    public PRS originePRS;
    void Start()
    {

    }


    void Update()
    {

    }

    public void MoveTransform(PRS prs, bool useLerp, float lerpTime = 0)
    {
        if (useLerp == false)
        {
            transform.position = prs.pos;
            transform.rotation = prs.rot;
            transform.localScale = prs.scale;
        }
    }

    public void DoMove( Vector3 targetPos, float time)
    {

        IEnumerator IDoMove(Vector3 targetPos, float time)
        {
            float current = 0;
            float percent = 0;
            Vector3 pos = transform.position;

            Vector3 startPos = transform.position;
            Vector3 endPos = targetPos;


            while(percent < 1)
            {
                current += Time.deltaTime;
                percent = current / time;
                pos = Vector3.Lerp(startPos, endPos, percent);

                transform.position = pos;
                yield return null;
            }

            yield break;
        }
    }



}


