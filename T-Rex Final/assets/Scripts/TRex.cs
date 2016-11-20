using UnityEngine;
using System.Collections;
/// <TRex>
/// Kelas TRex berfungsi untuk menangani input dari user dan mengeluarkan
/// output ke layar berupa pergerakan dari TRex
/// </Trex>
public class TRex : MonoBehaviour
{
    /// <moveSpeed>
    /// Attribute moveSpeed berfungsi untuk mengatur kecepatan gerak TRex
    /// </moveSpeed>
    public float moveSpeed;

    /// <jumpForce>
    /// Attribute jumpForce berfungsi untuk mengatur kekuatan loncat TRex.
    /// </jumpForce>
    public float jumpForce;

    /// <trexRigidBody>
    /// Attribute trexRigidBody berfungsi untuk membuat suatu object memiliki
    /// berat dan berpengaruh terhadap gravitasi.
    /// </trexRigidBody>
    private Rigidbody2D tRexRigidBody;

    /// <isGrounded>
    /// Attribute isGrounded berfungsi untuk mencek apakah TRex menempel dengan
    /// ground atau tidak.
    /// </isGrounded>
    public bool isGrounded;

    /// <whatIsGround>
    /// Attribute yang berisi layer yang berfungsi untuk memberikan informasi apakah
    /// TRex berada di ground atau tidak yang berfungsi untuk menangani TRex agar tidak dapat melakukan
    /// dua kali loncatan.
    /// </whatIsGround>
    public LayerMask whatIsGround;

    /// <myCollider>
    /// Attribute yang berfungsi untuk menangani kasus-kasus dimana TRex akan menabrak suatu obstacle.
    /// </myCollider>
    private Collider2D myCollider;

    /// <Start>
    /// Method start berfungsi untuk melakukan inisialisasi pertama pada saat game dimulai.
    /// </Start>
    void Start()
    {
        tRexRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
    }

    /// <Update>
    /// Method update berfungsi untuk menangani kasus-kasus disaat terjadi perubahan frame
    /// pada saat game sedang berjalan.
    /// </Update>
    void Update()
    {
        this.Jump(); 
    }

     /// </Jump>
    ///   Method jump berfungsi untuk menangani kasus jika TRex ingin meloncat pada saat game 
     ///   sedang berjalan.
    /// </Jump>
    void Jump()
    {

        isGrounded = true;
            //Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        tRexRigidBody.velocity = new Vector2(moveSpeed, tRexRigidBody.velocity.y);
        if (isGrounded&&transform.position.y<-1.23)
        {
            if (Input.GetKeyDown(KeyCode.Space) || (Input.GetTouch(0).phase == TouchPhase.Began))
            {
                tRexRigidBody.velocity = new Vector2(tRexRigidBody.velocity.x, jumpForce);
            }

        }
    }
}