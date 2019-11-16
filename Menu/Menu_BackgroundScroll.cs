using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_BackgroundScroll : MonoBehaviour
{
    // Script for scrolling the background of the main menu
    // Simply going to move this to the left until we have moved half of our width, then reset
    float scrollSpeed = -0.0025f;
    float maxMoveWidth = 24;

    void LateUpdate() {
        Vector2 currentPosition = this.transform.position;
        
        if (currentPosition.x > maxMoveWidth) {
            this.transform.position = new Vector2(0, currentPosition.y);
        }
        else {
            this.transform.position = new Vector2(currentPosition.x - scrollSpeed, currentPosition.y);
        }
    }
}
