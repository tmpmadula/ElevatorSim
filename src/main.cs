class Program
{
    static void Main(string[] args)
    {
        var elevatorController = new ElevatorController(numberOfElevators: 2, numberOfFloors: 10, elevatorCapacity: 10);

        elevatorController.CallElevator(floor: 3, numberOfPeople: 4);
        elevatorController.CallElevator(floor: 7, numberOfPeople: 2);

        // simulate elevators moving up
        for (int i = 0; i < 5; i++)
        {
            elevatorController.UpdateFloor(elevatorId: 0, floor: i + 1);
            elevatorController.UpdateFloor(elevatorId: 1, floor: i + 1);
        }

        // simulate elevators moving down
        for (int i = 4; i >= 0; i--)
        {
            elevatorController.UpdateFloor(elevatorId: 0, floor: i + 1);
            elevatorController.UpdateFloor(elevatorId: 1, floor: i + 1);
        }

        elevatorController.DisplayElevatorStatus();
    }
}
