using UnityEngine;

public class ComputerPlayer : Player
{
    public WaitForSeconds TurnWaitForSeconds { get; private set; }

    [SerializeField]
    private float _turnTime;

    private void Start()
    {
        TurnWaitForSeconds = new WaitForSeconds(_turnTime);
    }

    
    public void UpdateBehaviour(Hand humanHand)
    {
        int computerTotalValue = Hand.TotalValue;

       
        if (Hand.AcesCount == 0 || Hand.AcesTotalValue < 11) {
           
            if ((humanHand.AcesCount == 1 || humanHand.ContainsEqualOrHigher(7)) && computerTotalValue < 17) {
                IsHitting = true;
            }
            
            else if (humanHand.ContainsEqual(4, 5, 6) && computerTotalValue < 12) {
                IsHitting = true;
            }
           
            else if (humanHand.ContainsEqual(2, 3) && computerTotalValue < 13) {
                IsHitting = true;
            }
            else {
                IsHitting = false;
            }
        }
       
        else {
            
            if (computerTotalValue >= 19) {
                IsHitting = false;
            }
           
            else if (computerTotalValue == 18 && Hand.Count >= 3) {
               
                if (humanHand.AcesCount > 0 || humanHand.ContainsEqualOrHigher(9)) {
                    IsHitting = true;
                }
                else {
                    IsHitting = false;
                }
            }
            else {
                IsHitting = true;
            }
        }
    }
}