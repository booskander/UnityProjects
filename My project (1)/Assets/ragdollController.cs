using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdollController : MonoBehaviour
{
    // Start is called before the first frame update
    // first videp pour desactiver ou activer la rigidite du corps
    private List<Vector3> childPositions_;
    private List<Quaternion> childRotations_;
    private Animator anim_;

    public bool ragDollTest_ = false;
    public bool resetRagDoll_;

    // deuxieme video pour faire bouger le corps

    public float speed_;
    public float strafeSpeed_;
    public float jumpForce_;
    public Rigidbody hips_;
    bool isGrounded_;
    void Start()
    {
        childPositions_ = new List<Vector3>();
        childRotations_ = new List<Quaternion>();
        hips_ = GetComponentInChildren<Rigidbody>().GetComponent
        anim_ = GetComponent<Animator>();
        getPose();
        ragDollOn(false);
        
    }
    private void FixedUpdate() // quand on veut faire des changements physiques faut utiliser des fixed updates
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
                moveforward();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveRight();
        }
    }

    public void ragDollOn(bool ragDoll)
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach(var rb in bodies)
        {
            rb.isKinematic = !ragDoll;
        }
        anim_.enabled = !ragDoll;
    }
    private void Update()
    {
        if (ragDollTest_)
        {
            ragDollOn(true);
        }
        if (resetRagDoll_)
        {
            resetDoll();
        }
        

    }
    public void resetDoll()
    {
        ragDollOn(false);
        Transform[] children = GetComponentsInChildren<Transform>();
        for(int i = 0; i < children.Length; i++)
        {
            children[i].localPosition = childPositions_[i];
            children[i].localRotation = childRotations_[i];
        }
    }


    private void getPose()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        foreach(var transform in children)
        {
            childPositions_.Add(transform.localPosition);
            childRotations_.Add(transform.localRotation);
        }
    }

    private void moveforward()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
            hips_.AddForce(hips_.transform.forward * speed_ * 1.5f);
        hips_.AddForce(hips_.transform.forward * speed_ * 1.5f);

    }
    private void moveRight()
    {

    }
    private void moveLeft()
    {

    }
    private void backwards()
    {

    }

    
}
