using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum WeaponType { Melee, Gun, Vine }; // attacks

    protected WeaponType type;

    protected int ammo;
    protected int damage;

    public float H;

    protected float jumpForce = 7f;
    public GameObject groundCheck;
    protected float jumpGravityScale = 1f;
    protected float fallingGravityScale = 3f;

    public GameObject fire;
    public Transform firePoint;

    public Vector2 facingDirection = Vector2.right;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float moveForce;

    private bool jump;
    private bool inAir = false;
    private float fireDelay = 0.25f;
    private float nextTimeToFire = 0;
    private bool isDead = false;

    //Components we are getting
    private SpriteRenderer rend;
    private Rigidbody2D rbody;
    private Animator anim;
    private AudioSource deathSound;

    // WEAPONS v
    private Weapon defaultWeapon;

    private Weapon activeWeapon;

    public List<Weapon> weapons = new List<Weapon>();

    private int activeWeaponIndex = 0;

    // WEAPONS ^

    void Use()
    {
        //nothing
    }

    //*************************************
    public bool isPlayerDead()
    {
        return isDead;
    }
    //*************************************


    //*************************************
    protected void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        deathSound = GetComponent<AudioSource>();
    }
    //*************************************

    //*************************************
    void Update()
    {
        H = Input.GetAxis("Horizontal");
        anim.SetFloat("H", H);
        //transform.Translate(new Vector3(H, 0, 0) * speed * Time.deltaTime);
        if (H < 0 && facingDirection == Vector2.right && !isDead)
        {
            FlipX();
            facingDirection = Vector2.left;
        }
        else if (H > 0 && facingDirection == Vector2.left && !isDead) {
            FlipX();
            facingDirection = Vector2.right;
        }

        void FlipX()
        {
            Vector3 theScale = transform.localScale;
            theScale.x = theScale.x * -1;
            transform.localScale = theScale;
        }
        anim.SetFloat("H", H);
        if (Input.GetButtonDown("Jump"))
            jump = true;

        // to switch means == left alt or right click
        if (Input.GetButtonDown("Fire2")) // alternates between weapons
        {
            if (activeWeaponIndex == weapons.Count - 1)
            {
                activeWeaponIndex = -1;
                anim.SetBool("isShooting", true); // should be shooting idle animation
            }else if(activeWeaponIndex == weapons.Count - 1)
            {
                anim.SetBool("isShooting", false);
                activeWeaponIndex = -1;
                anim.SetBool("isVining", true);
            }
            //activeWeaponIndex++;
            activeWeapon = weapons[++activeWeaponIndex];
        }
        // to switch means == left alt or right click
        //if (Input.GetKeyDown(KeyCode.R)) // alternates between weapons
        //{
        //    foreach (Weapon aWeapon in weapons)
        //    {
        //        if (aWeapon is Gun)
        //            aWeapon.Reload();
        //    }
        //}

        //-------------------------------------
        //anim.SetFloat("H", Mathf.Abs(h));
        if (Input.GetButton("Fire1") && Time.time > nextTimeToFire && !isDead)
        {
            Instantiate(fire, firePoint.position, facingDirection == Vector2.left ? Quaternion.Euler(0, 180, 0): firePoint.rotation);
            nextTimeToFire = Time.time + fireDelay;
            anim.SetBool("isShooting", true); // change
        }
        else
            anim.SetBool("isShooting", false); // change
        //-------------------------------------
    }
    //*************************************

    //*************************************
    private void FixedUpdate()
    {
        if (!isDead)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(groundCheck.transform.position, Vector2.down, .2f);
            Debug.DrawRay(groundCheck.transform.position, Vector2.down, Color.red, .2f);

            //horizontal movement
            if (rbody.velocity.x < 15 && rbody.velocity.x > -15 && !inAir)
                rbody.AddForce(Vector2.right * H * moveForce);
            //if(H == 0)
            //rbody.velocity = Vector2.zero;
            if (jump)
            {
                Debug.Log(hitInfo.collider.name);
                if (hitInfo.collider != null)
                {
                    rbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    inAir = true;
                    anim.SetBool("inAir", inAir);
                }

                jump = false;
            }

            //Used to make the player fall faster
            if (rbody.velocity.y >= 0)
                rbody.gravityScale = jumpGravityScale;
            else
                rbody.gravityScale = fallingGravityScale;
        }
        
    }
    //*************************************

    //*************************************
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            inAir = false;
            anim.SetBool("inAir", inAir);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            anim.SetBool("isDead", true);
            //GetComponent<Patrol>().enabled = false;
            deathSound.Play();
            Invoke("Die", 1f);
        }
    }
    //*************************************

    //*************************************
    private void Die()
    {
        Destroy(gameObject);
    }
    //*************************************
}
