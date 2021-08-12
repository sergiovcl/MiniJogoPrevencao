using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePrevencaoContamined : MonoBehaviour
{
    public float range;
    public Transform player;
    public float Speed;
    public bool canDamage = true;

    void Start()
    {

    }

    void Update()
    {
        if(Vector3.Distance(player.position, transform.position) <= range)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);
            
           SetContaminated(true);
        } 
        else 
        {
            SetContaminated(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if(collider.gameObject.CompareTag("Player") && canDamage) 
        {
            collider.gameObject.GetComponent<MiniGamePrevencaoPlayer>().OnDamage();
            canDamage = false;
 
        }
    }

    public void DisableContaminated()
    {
        enabled = false;
        
        SetContaminated(false);

    }

    private void SetContaminated(bool contaminated)
    {   
        if(GetComponent<Animator>() != null)
        {
            GetComponent<Animator>().SetBool("Contaminated", contaminated);
        }
    }

}
