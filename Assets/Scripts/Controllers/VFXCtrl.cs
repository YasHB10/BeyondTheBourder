using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class shows all the visual special effects
/// </summary>
public class VFXCtrl : MonoBehaviour {
    public static VFXCtrl VFXCtrlInstance;
    public VFX vfx;

    private void Awake(){
        if (VFXCtrlInstance == null) {
            VFXCtrlInstance = this;
        } 
    }

    /// <summary>
    /// Show dust when the player lands
    /// </summary>
    /// <param name="pos"></param>
    public void ShowPlayerLanding(Vector3 pos){
        Instantiate(vfx.sfx_playerLands, pos, Quaternion.identity);
    }
}
