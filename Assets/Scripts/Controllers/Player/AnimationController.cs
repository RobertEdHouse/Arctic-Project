
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    #region WALK

    public void WalkAnim()
    {
        animator.SetTrigger("IsWalking");
    }

    public void WalkAnimReset()
    {
        animator.ResetTrigger("IsWalking");
    }
    #endregion

    #region IDLE
    public void IdleAnim()
    {
        animator.SetTrigger("IsWalking");
    }

    public void IdleAnimReset()
    {
        animator.ResetTrigger("IsWalking");
    }

    #endregion

}
