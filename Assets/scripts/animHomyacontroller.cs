
using UnityEngine;

public class animHomyacontroller : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetBool("IsPlaying", true);

        //_sprite.color = Color.red;
        //transform.position += new Vector2(0, 1);

    }
    public void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("IsPlaying", false);

    }

}
