using System;
using UnityEngine;

public class PaladinCharges
{
    private int chargesNumber;

    public void SetCharges(int numberOfCharges)
    {
        chargesNumber = Mathf.Clamp(numberOfCharges, 0, 3);
    }

    public void UseCharges()
    {

    }


}
