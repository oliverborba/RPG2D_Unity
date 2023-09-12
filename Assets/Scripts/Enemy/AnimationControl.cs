using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;

    private PlayerAnim player;
    private Animator anim;

    
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindAnyObjectByType<PlayerAnim>();

    }
    public void PlayAnim(int value)
    {
        anim.SetInteger("transition", value);
    }
    public void Attack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, playerLayer);

        if(hit != null)
        {
            //detecta colisão com player
            player.OnHit();
        }
        else
        {

        }       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }
}
