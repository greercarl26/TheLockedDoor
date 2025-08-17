Door door = new Door();
while(true)
{
Console.Write($"The door is {door._currentState} what do you want to do? ");
door.State();
}


class Door
{
    private DoorState currentState;
    private int pin;
    
    public Door()
{
    currentState = DoorState.Locked;
    pin = 0000;
}
    public DoorState _currentState 
    { 
        get
        {
            return currentState;
        }
    }
   
    public DoorState State()
    {
        string? userChoice = Console.ReadLine().ToLower();
        DoorState lockState;
        lockState = userChoice switch
        {
            "lock" => Lock(),
            "open" => Open(),
            "close" => Close(),
            "unlock" => Unlock(),
            _ => DoorState.Locked
        };
        currentState = lockState;
        return currentState;
    }
    
    public DoorState Unlock()
    {
        while(true)
        {
        if (currentState == DoorState.Locked)
        { 
            while (true)
            {
            Console.WriteLine(" The door is Locked Enter Your Pin: ");
            int userPin = Convert.ToInt32(Console.ReadLine());
            if (userPin == Password)
            {
                    currentState = DoorState.Closed;
                    Console.Write("Would You like to Change the password? Y or N: ");
                    string userInput = Console.ReadLine().ToLower();
                        if (userInput == "y")
                        {
                            Console.Write("Enter new Pin: ");
                            int newPin = Convert.ToInt32(Console.ReadLine());
                            Password = newPin;
                        }
                        else if (userInput == "n")
                        {
                            return currentState;
                        }   

                
            }
            else
            {
                Console.WriteLine("Pin Invalid Please Try Again.");
                currentState = DoorState.Locked;
                return currentState;
            }
             
            }
        }
        else if (currentState != DoorState.Locked)
        {
            Console.WriteLine("The door is not locked");
            return currentState;
        }

        }
    }

    public void PasswordChanger()
    {

    }
    public DoorState Lock()
    {
        while (true)
        { 
            if (currentState == DoorState.Closed)
            {
            currentState = DoorState.Locked;
            return currentState;
            }
            else if (currentState != DoorState.Closed)
            {
                Console.WriteLine($" A {_currentState} can't be Locked the door has to be in a closed state. ");
                return currentState;   
            }
        }

    }
    public DoorState Open()
    {
        while (true)
        {
            if (currentState == DoorState.Closed)
            {
                currentState = DoorState.Open;
                return currentState;
            }
            else if (currentState != DoorState.Closed)
            {
                Console.WriteLine($" A {_currentState} can't be Opened the door must be closed first. ");
                return currentState;
            }
              
                

        }
    }
    public DoorState Close()
    {
        while (true)
        {
            if (currentState == DoorState.Open)
            {
                currentState = DoorState.Closed;
                return currentState;
            }
            else if (currentState == DoorState.Locked)
            {
                Unlock();
            }
            else if (currentState != DoorState.Open || currentState != DoorState.Locked)
            {
                Console.WriteLine($"The {currentState} has to be either open or locked for do to be in a closed state.");
            }

        }
    }


    public int Password
    {
        get
        {
           return pin;
        }
        set
        {
            pin = value;
        }
    }
}
enum DoorState { Open, Closed, Locked,Unlocked,}