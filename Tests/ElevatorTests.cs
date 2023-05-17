using NUnit.Framework;
using System;

[TestFixture]
public class ElevatorControllerTests
{
    [Test]
    public void CallElevator_WhenElevatorAvailable_MoveToFloor()
    {
        // Arrange
        var controller = new ElevatorController(numberOfElevators: 2, numberOfFloors: 10, elevatorCapacity: 10);

        // Act
        controller.CallElevator(floor: 3, numberOfPeople: 4);

        // Assert
        var elevator = controller.GetElevatorById(0);
        Assert.AreEqual(3, elevator.DestinationFloor);
        Assert.AreEqual(ElevatorDirection.Up, elevator.Direction);
        Assert.AreEqual(4, elevator.NumberOfPeople);
    }

    [Test]
    public void CallElevator_WhenNoAvailableElevators_ReturnErrorMessage()
    {
        // Arrange
        var controller = new ElevatorController(numberOfElevators: 1, numberOfFloors: 10, elevatorCapacity: 1);
        controller.CallElevator(floor: 3, numberOfPeople: 1);

        // Act
        using (StringAssert.Contains("No available elevators!", ConsoleOutputInterceptor.CaptureConsoleOutput(() =>
        {
            controller.CallElevator(floor: 7, numberOfPeople: 1);
        })))
        {
            // Assert
            var elevator = controller.GetElevatorById(0);
            Assert.AreEqual(3, elevator.DestinationFloor);
            Assert.AreEqual(ElevatorDirection.None, elevator.Direction);
            Assert.AreEqual(1, elevator.NumberOfPeople);
        }
    }

    [Test]
    public void UpdateFloor_WhenElevatorExists_UpdateCurrentFloor()
    {
        // Arrange
        var controller = new ElevatorController(numberOfElevators: 1, numberOfFloors: 10, elevatorCapacity: 10);

        // Act
        controller.UpdateFloor(elevatorId: 0, floor: 5);

        // Assert
        var elevator = controller.GetElevatorById(0);
        Assert.AreEqual(5, elevator.CurrentFloor);
    }

    [Test]
    public void UpdateFloor_WhenElevatorDoesNotExist_ReturnErrorMessage()
    {
        // Arrange
        var controller = new ElevatorController(numberOfElevators: 1, numberOfFloors: 10, elevatorCapacity: 10);

        // Act
        using (StringAssert.Contains("Elevator with id 1 does not exist!", ConsoleOutputInterceptor.CaptureConsoleOutput(() =>
        {
            controller.UpdateFloor(elevatorId: 1, floor: 5);
        })))
        {
            // Assert
            var elevator = controller.GetElevatorById(0);
            Assert.AreEqual(0, elevator.CurrentFloor);
        }
    }
}
