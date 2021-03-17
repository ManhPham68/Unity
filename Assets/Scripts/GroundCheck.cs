using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Started st;
    // Start is called before the first frame update
    void Start() {  st = gameObject.GetComponentInParent<Started>();}
    void OnTriggerEnter2D(Collider2D collision) {  st.grounded = true; }
    private void OnTriggerStay2D(Collider2D collision) { st.grounded = true; }
    private void OnTriggerExit2D(Collider2D collision) { st.grounded = true; }

}
