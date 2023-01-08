using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveOpject : MonoBehaviour
{
    public bool Ischake;
    public AnimationCurve curve;
    public float duration = 1f;

    public Animator m_Animator;

    private void Update() {

        if (m_Animator.GetBool("isSit"))
        {
            Debug.Log("SHAKE");
            StartCoroutine(Shaking());
            //If the "Crouch" parameter is enabled, disable it as the Animation should no longer be crouching
            // m_Animator.SetBool("isWalking", false);
        }

    }

    IEnumerator Shaking(){
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration){
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime/duration);
            transform.position = startPosition + UnityEngine.Random.insideUnitSphere * strength;
            yield return null;
        }
        transform.position = startPosition;
    }
}
