public enum ElevatorDirection
{
    Up,
    Down,
    None
}

public class Elevator
{
    public int Id { get; set; }
    public int CurrentFloor { get; set; }
    public int DestinationFloor { get; set; }
    public int Capacity { get; set; }
    public int NumberOfPeople { get; set; }
    public ElevatorDirection Direction { get; set; }

    public bool IsFull => NumberOfPeople >= Capacity;

    public void MoveToFloor(int floor)
    {
        if (floor > CurrentFloor)
        {
            Direction = ElevatorDirection.Up;
        }
        else if (floor < CurrentFloor)
        {
            Direction = ElevatorDirection.Down;
        }
        else
        {
            Direction = ElevatorDirection.None;
        }

        DestinationFloor = floor;
    }
}
