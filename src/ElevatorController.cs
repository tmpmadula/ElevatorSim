public class ElevatorController
{
    private readonly List<Elevator> elevators;
    private readonly int numberOfFloors;
    private readonly int elevatorCapacity;

    public ElevatorController(int numberOfElevators, int numberOfFloors, int elevatorCapacity)
    {
        elevators = new List<Elevator>();
        for (int i = 0; i < numberOfElevators; i++)
        {
            elevators.Add(new Elevator { Id = i, Capacity = elevatorCapacity });
        }
        this.numberOfFloors = numberOfFloors;
        this.elevatorCapacity = elevatorCapacity;
    }

    public void CallElevator(int floor, int numberOfPeople)
    {
        var elevator = GetNearestAvailableElevator(floor, numberOfPeople);
        if (elevator == null)
        {
            Console.WriteLine("No available elevators!");
            return;
        }

        elevator.MoveToFloor(floor);
        elevator.NumberOfPeople += numberOfPeople;

        Console.WriteLine($"Elevator {elevator.Id} is on its way to floor {floor}");
    }

    public void UpdateFloor(int elevatorId, int floor)
    {
        var elevator = elevators.FirstOrDefault(e => e.Id == elevatorId);
        if (elevator == null)
        {
            Console.WriteLine($"Elevator with id {elevatorId} does not exist!");
            return;
        }

        if (elevator.CurrentFloor == floor)
        {
            elevator.Direction = ElevatorDirection.None;
            elevator.NumberOfPeople = 0;
        }

        elevator.CurrentFloor = floor;

        Console.WriteLine($"Elevator {elevator.Id} is now on floor {floor}");
    }

    public void DisplayElevatorStatus()
    {
        foreach (var elevator in elevators)
        {
            Console.WriteLine($"Elevator {elevator.Id} is on floor {elevator.CurrentFloor} with {elevator.NumberOfPeople} people and is moving {elevator.Direction}");
        }
    }

    private Elevator GetNearestAvailableElevator(int floor, int numberOfPeople)
    {
        Elevator nearestElevator = null;
        int minDistance = int.MaxValue;

        foreach (var elevator in elevators)
        {
            if (elevator.IsFull || elevator.DestinationFloor != 0)
            {
                continue;
            }

            int distance = Math.Abs(elevator.CurrentFloor - floor);
            if (distance < minDistance)
            {
                nearestElevator = elevator;
                minDistance = distance;
            }
        }

        return nearestElevator;
    }
}
