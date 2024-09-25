using System;
using System.Collections.Generic;

public enum MoveDirection { UP, DOWN, RIGHT, LEFT }

public struct Coordinates
{
    public int PosX { get; set; }
    public int PosY { get; set; }

    public Coordinates(int x, int y)
    {
        PosX = x;
        PosY = y;
    }
}

public class Map
{
    private int maxWidth;
    private int maxHeight;
    private List<Coordinates> barriers;

    public Map(int w, int h, List<Coordinates> obs)
    {
        maxWidth = w;
        maxHeight = h;
        barriers = obs;
    }

    public bool CanMove(Coordinates pos)
    {
        return pos.PosX >= 0 && pos.PosX < maxWidth && pos.PosY >= 0 && pos.PosY < maxHeight &&
               !barriers.Contains(pos);
    }
}

public class Vehicle
{
    private Coordinates currentPos;
    private MoveDirection facingDirection;
    private Map terrain;

    public Vehicle(Coordinates pos, MoveDirection dir, Map map)
    {
        currentPos = pos;
        facingDirection = dir;
        terrain = map;
    }

    public void MoveForward()
    {
        Coordinates newPos = currentPos;
        switch (facingDirection)
        {
            case MoveDirection.UP:
                newPos.PosY += 1;
                break;
            case MoveDirection.DOWN:
                newPos.PosY -= 1;
                break;
            case MoveDirection.RIGHT:
                newPos.PosX += 1;
                break;
            case MoveDirection.LEFT:
                newPos.PosX -= 1;
                break;
        }

        if (terrain.CanMove(newPos))
        {
            currentPos = newPos;
        }
    }

    public void RotateLeft()
    {
        switch (facingDirection)
        {
            case MoveDirection.UP:
                facingDirection = MoveDirection.LEFT;
                break;
            case MoveDirection.DOWN:
                facingDirection = MoveDirection.RIGHT;
                break;
            case MoveDirection.RIGHT:
                facingDirection = MoveDirection.UP;
                break;
            case MoveDirection.LEFT:
                facingDirection = MoveDirection.DOWN;
                break;
        }
    }

    public void RotateRight()
    {
        switch (facingDirection)
        {
            case MoveDirection.UP:
                facingDirection = MoveDirection.RIGHT;
                break;
            case MoveDirection.DOWN:
                facingDirection = MoveDirection.LEFT;
                break;
            case MoveDirection.RIGHT:
                facingDirection = MoveDirection.DOWN;
                break;
            case MoveDirection.LEFT:
                facingDirection = MoveDirection.UP;
                break;
        }
    }

    public string GetPositionReport()
    {
        return string.Format("Vehicle is at ({0}, {1}) facing {2}.", currentPos.PosX, currentPos.PosY, facingDirection);
    }
}

public interface IOperation
{
    void Perform(Vehicle vehicle);
}

public class MoveOperation : IOperation
{
    public void Perform(Vehicle vehicle) { vehicle.MoveForward(); }
}

public class RotateLeftOperation : IOperation
{
    public void Perform(Vehicle vehicle) { vehicle.RotateLeft(); }
}

public class RotateRightOperation : IOperation
{
    public void Perform(Vehicle vehicle) { vehicle.RotateRight(); }
}

public class ActionFactory
{
    private Dictionary<char, IOperation> operations;

    public ActionFactory()
    {
        operations = new Dictionary<char, IOperation>();
        operations.Add('M', new MoveOperation());
        operations.Add('L', new RotateLeftOperation());
        operations.Add('R', new RotateRightOperation());
    }

    public IOperation GetAction(char action)
    {
        IOperation op;
        operations.TryGetValue(action, out op);
        return op;
    }
}

public class Runner
{
    public static void Main(string[] args)
    {
        List<Coordinates> barriers = new List<Coordinates>();
        barriers.Add(new Coordinates(2, 2));
        barriers.Add(new Coordinates(3, 5));
        Map terrain = new Map(10, 10, barriers);

        Vehicle rover = new Vehicle(new Coordinates(0, 0), MoveDirection.UP, terrain);

        ActionFactory factory = new ActionFactory();

        char[] actions = { 'M', 'M', 'R', 'M', 'L', 'M' };
        foreach (char action in actions)
        {
            IOperation op = factory.GetAction(action);
            if (op != null)
            {
                op.Perform(rover);
            }
        }

        Console.WriteLine(rover.GetPositionReport());
    }
}
