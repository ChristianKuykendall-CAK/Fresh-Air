/* Christian Kuykendall
 * Date:
 * Purpose: This script is attached to the player gameobject. It is supposed to
 * move the player as well as activate animation upon certain actions. It also
 * holds data about the weapons used in a list so that the player can swap weapons.
 * The movement and animations were inspired from platformer24.
 * The weapon list was inspired from fps24
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float H;                           // gets the horizontal movement of the player
    protected float jumpForce = 7f;           // force that player moves from ground
    public GameObject groundCheck;            // This is at the bottom of the player gameobject as a child -
                                              // It detects if the player is on the ground on not through raycasting
    protected float jumpGravityScale = 1f;    // Gravity
    protected float fallingGravityScale = 3f; // falling Gravity

    public Vector2 facingDirection = Vector2.right; // Direction the player is facing. Default is right
    [SerializeField]         // Serializes
    private float speed;     // Player speed
    [SerializeField]         // Serializes
    private float moveForce; // Force the player pushes on other object

    private bool jump;           // Used to make the player jump
    private bool inAir = false;  // Checks to see if player is in air
    private bool isDead = false; // Checks to see if hte player is dead

    //Components we are getting
    private SpriteRenderer rend;
    private Rigidbody2D rbody;
    private Animator anim;
    private AudioSource deathSound;

    // Weapon
    private Weapon defaultWeapon; // default weapon for player (punching)
    private Weapon activeWeapon;  // Sets the current weapon of the player
    public List<Weapon> weapons = new List<Weapon>(); // List of weapons
    private int activeWeaponIndex = 0; // current weapon index

    // This is called to activate that the player is dead
    public bool isPlayerDead()
    {
        return isDead;
    }

    // Start is called before the first frame update
    protected void Start()
    {
        // Sets the weapon index
        activeWeaponIndex = 0;

        // Instantiates the player components in variables
        rend = GetComponent<SpriteRenderer>();
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        deathSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        H = Input.GetAxis("Horizontal");  // Gets the horizontal input the player puts it as a float -
                                          // Used for animation
        anim.SetFloat("H", Mathf.Abs(H)); // Used for animation of player running
        // This checks to see which direction the player is facing so it sets gameobject to face the correct direction
        if (H < 0 && facingDirection == Vector2.right && !isDead)
        {
            FlipX();
            facingDirection = Vector2.left;
        }
        else if (H > 0 && facingDirection == Vector2.left && !isDead) {
            FlipX();
            facingDirection = Vector2.right;
        }

        // This method changes the direction of the player gameobject
        void FlipX()
        {
            Vector3 theScale = transform.localScale;
            theScale.x = theScale.x * -1;
            transform.localScale = theScale;
        }

        anim.SetFloat("H", Mathf.Abs(H));
        // This sets the jump value to true if the player presses the jump button (spacebar)
        if (Input.GetButtonDown("Jump"))
            jump = true;

        // This shoots a projectile
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("isShooting", true); // changes animation
            activeWeapon.Use(); // This shoots the projectile of the weapon the player is currently using
            //Debug.Log("Trying to use weapon");
        }
        else
            anim.SetBool("isShooting", false); // changes animation

        // This switches the weapon the player is using
        if (Input.GetButtonDown("Fire2")) // alternates between weapons
        {
            //Debug.Log(activeWeaponIndex);
            if (activeWeaponIndex == 0)
            {
                anim.SetBool("GunActive", true);
            }
            else if (activeWeaponIndex == 1)
            {
                anim.SetBool("GunActive", false);
                //anim.SetBool("VineIdle", true);
            }

            if (activeWeaponIndex == weapons.Count - 1)
            {
                activeWeaponIndex = -1;
            }
            activeWeapon = weapons[++activeWeaponIndex];
        }
        
        // This reloads the weapon the player is currently using
        if (Input.GetKeyDown(KeyCode.R)) // alternates between weapons
        {
            foreach (Weapon aWeapon in weapons)
            {
                if (aWeapon is Gun)
                    aWeapon.Reload();
            }
        }

        
    }
   
    // This method is FixedUpdate
    private void FixedUpdate()
    {
        // Checks if player is not dead
        if (!isDead)
        {
            // This creates a raycast form groundCheck to check if the player is on the ground
            RaycastHit2D hitInfo = Physics2D.Raycast(groundCheck.transform.position, Vector2.down, .2f);
            Debug.DrawRay(groundCheck.transform.position, Vector2.down, Color.red, .2f);

            //horizontal movement
            if (rbody.velocity.x < 15 && rbody.velocity.x > -15 && !inAir)
                rbody.AddForce(Vector2.right * H * moveForce);
            // If the player is jumping
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
    
    // When the player collides with something this method activates
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ground tiles
        if (collision.gameObject.CompareTag("Ground"))
        {
            inAir = false;
            anim.SetBool("inAir", inAir);
        }
        // Enemies
        if (collision.gameObject.CompareTag("Enemy"))
        {
            anim.SetBool("isDead", true);
            //GetComponent<Patrol>().enabled = false;
            deathSound.Play();
            Invoke("Die", 1f); // after 1 secondit activate 'Die'
        }
    }
   
    // This destroys the player gameobject
    private void Die()
    {
        Destroy(gameObject);
    }
}
