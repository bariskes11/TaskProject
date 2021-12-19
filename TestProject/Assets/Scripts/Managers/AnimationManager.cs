using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class AnimationManager : MonoBehaviour
{
    #region Unity Fields
    [SerializeField]
    GameObject coinToAnimate;

    [SerializeField]
    GameObject gemToAnimate;

    [SerializeField]
    ParticleSystem gemSpawnObject;

    [SerializeField]
    ParticleSystem coinSpawnObject;
    #endregion

    [SerializeField]
    Transform gemTargetPos;
    [SerializeField]
    Transform coinTargetPos;
    #region Fields
    Vector3 clickedPos;
    bool isAnimating = false;
    #endregion

    #region Unity Methods
    private void Start()
    {

        if (gemSpawnObject == null)
        {
            Debug.Log($"<color=red>There is no Gem Object to animate");
        }
        if (coinSpawnObject == null)
        {
            Debug.Log($"<color=red> There is no Coin Object</color>");
        }
        if (coinToAnimate == null)
        {
            Debug.Log($"<color=red> There is no Coin To Animate</color>");
        }
        if (gemToAnimate == null)
        {
            Debug.Log($"<color=red> There is no Gem To Animate</color>");
        }

        EventManager.OnOwnedItem.AddListener(this.PlayAnimations);
    }
    #endregion
    #region Public Methods
    public void PlayAnimations(PublicHardCodeds.FinancialTypes type, GameObject button)
    {
        if (this.isAnimating) // animation is not finished
            return;
        this.AnimateButton(button);
        switch (type)
        {
            case PublicHardCodeds.FinancialTypes.Coin:
                //oinSpawnObject.transform.position = player.LastPos;
                //coinSpawnObject.transform.LookAt(gemTargetPos);
                AnimateCoin(button);
                break;
            case PublicHardCodeds.FinancialTypes.Gem:
                AnimateGem(button);
                break;
        }
    }


    #endregion
    #region Private Methods
    void AnimateCoin(GameObject button)
    {
        this.isAnimating = true;
        this.coinToAnimate.transform.DOMove(button.transform.position, 0F);
        this.coinToAnimate.transform.DOScale(Vector3.one, .2F).OnComplete(() =>
         {
             MoveTowardsTarget(this.coinToAnimate, this.coinTargetPos, this.coinSpawnObject);
         }
        );
    }
    void AnimateGem(GameObject button)
    {
        this.isAnimating = true;
        this.gemToAnimate.gameObject.SetActive(true);
        this.gemToAnimate.transform.DOMove(button.transform.position, 0F);
        this.gemToAnimate.transform.DOScale(Vector3.one, .2F).OnComplete(() =>
        {
            MoveTowardsTarget(this.gemToAnimate, this.gemTargetPos, this.gemSpawnObject);
        }
        );
    }

    void MoveTowardsTarget(GameObject obj, Transform target, ParticleSystem particle)
    {
        obj.transform.DOMove(target.position, 1F).OnComplete(() =>
        {
            obj.transform.DOScale(Vector3.zero, .2F).OnComplete(() =>
            {

                particle.Play();
                this.isAnimating = false;
            });
        }
        );
    }

    void AnimateButton(GameObject btn)
    {
        btn.transform.DOPunchScale(Vector3.one * 1.2F, .5F, 2, .2F);
    }

    #endregion





}
