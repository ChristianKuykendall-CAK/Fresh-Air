/* Christian Kuykendall
 * Date: 4/26/2024
 * Purpose: This script is attached to the player gameobject. It is supposed to
 * move the player as well as activate animation upon certain actions. It also
 * holds data about the weapons used in a list so that the player can swap weapons.
 * The movement and animations were inspired from platformer24.
 * The weapon list was inspired from fps24
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Reference to the GameManager
    private GameManager gameManager;

    public float H;                           // gets the horizontal movement of the player
    protected float jumpForce = 7f;
    public GameObject groundCheck;            // Raycast down to check for ground

    protected float jumpGravityScale = 1f;    // Gravity
    protected float fallingGravityScale = 3f;

    public Vector2 facingDirection = Vector2.right; // Direction the player is facing. Default is right
    [SerializeField]         // Serializes
    private float speed;
    [SerializeField]
    private float moveForce;

    private bool jump;
    private bool inAir = false;  // Checks to see if player is in air
    private bool isDead = false; // Checks to see if hte player is dead

    //Components we are getting
    private SpriteRenderer rend;
    private Rigidbody2D rbody;
    private Animator anim;
    private AudioSource deathSound;

    // Weapon
    private Weapon defaultWeapon; // default weapon
    private Weapon activeWeapon;  // Sets the current weapon
    public List<Weapon> weapons = new List<Weapon>(); // List of weapons
    public int activeWeaponIndex = 0; // current weapon index

    // This is called to activate that the player is dead
    public bool isPlayerDead()
    {
        return isDead;
    }

    // Start is called before the first frame update
    protected void Start()
    {
        // Find the GameManager instance in the scene
        gameManager = FindObjectOfType<GameManager>();

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
        
        H = Input.GetAxis("Horizontal");  // Gets the horizontal input the player
        anim.SetFloat("H", Mathf.Abs(H)); // Used for animation of player running

        // This checks to see which direction the player is facing
        // so it sets gameobject to face the correct direction
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

        // Sets jump to true
        if (Input.GetButtonDown("Jump"))
            jump = true;

        // This shoots a projectile
        if (Input.GetButtonDown("Fire1"))
        {
            // Sets triggers for weapons
            anim.SetTrigger("IsPunching");
            anim.SetTrigger("IsVining");

            if (activeWeapon != null)
            {
                // Shoots projectile of current weapon
                activeWeapon.Use();
            }
        }

        // This switches the weapon the player is using
        if (Input.GetButtonDown("Fire2"))
        {
            if (activeWeaponIndex == 0) // Gun
            {
                anim.SetBool("GunActive", true);
            }
            else if (activeWeaponIndex == 1) // Vine
            {
                anim.SetBool("GunActive", false);
                anim.SetBool("VineActive", true);
            }
            else if(activeWeaponIndex == 2) // Fist
            {
                anim.SetBool("VineActive", false);
            }

            // Iterates through weapons
            if (activeWeaponIndex == weapons.Count - 1)
            {
                activeWeaponIndex = -1;
            }
            activeWeapon = weapons[++activeWeaponIndex];
        }
        
        // Reloads weapons, only if there are ammo boxes
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (gameManager.reload > 0)
            {
                foreach (Weapon aWeapon in weapons)
                {
                    if (aWeapon is Gun)
                        aWeapon.Reload();
                    else if (aWeapon is Vine)
                        aWeapon.Reload();
                }
                gameManager.reload -= 1;
            }
        }
        // Heals player if there are Medkits
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (gameManager.medkit > 0)
            {
                gameManager.medkit -= 1;
                gameManager.UseMedkit();
            }
        }

        // If player dies
        if (gameManager.health <= 0)
        {
            anim.SetBool("isDead", true);
            isDead = true;
            Invoke("Die", 1f); // after 1 second activate 'Die'
        }
    }
   
    private void FixedUpdate()
    {
        // Checks if player is not dead
        if (!isDead)
        {
            // This creates a raycast from groundCheck to check if the player is on the ground
            RaycastHit2D hitInfo = Physics2D.Raycast(groundCheck.transform.position, Vector2.down, .2f);
            Debug.DrawRay(groundCheck.transform.position, Vector2.down, Color.red, .2f);

            //horizontal movement
            if (rbody.velocity.x < 15 && rbody.velocity.x > -15 && !inAir)
                rbody.AddForce(Vector2.right * H * moveForce);
            // If the player is jumping
            if (jump)
            {
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
    
    // Detects collision
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
            gameManager.health -= 10;
            Debug.Log(gameManager.health);
            CanvasManager.instance.UpdateHealth(gameManager.health.ToString());
            
        }
    }
    // Detects triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Refillbox"))
        {
            gameManager.reload += 1;
            Debug.Log(gameManager.reload);
            CanvasManager.instance.UpdateReload(gameManager.reload.ToString());
        }
    }
   
    // This goes to the lose screen when the player loses
    private void Die()
    {
        SceneManager.LoadScene("Failed");
    }
}
