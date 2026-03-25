using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP41.Behavioral;

public class CommandClientCode
{
    public void Run()
    {
        Console.CursorVisible = false;
        var player = new Player(10, 10);
        player.Render();

        var commands = new Queue<IPlayerCommand>();

        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.W:
                        commands.Enqueue(new MoveCommand(player, Direction.Up));
                        break;
                    case ConsoleKey.S:
                        commands.Enqueue(new MoveCommand(player, Direction.Down));
                        break;
                    case ConsoleKey.A:
                        commands.Enqueue(new MoveCommand(player, Direction.Left));
                        break;
                    case ConsoleKey.D:
                        commands.Enqueue(new MoveCommand(player, Direction.Right));
                        break;

                    case ConsoleKey.D1:
                        commands.Enqueue(new MoveCommand(player, Direction.Left));
                        commands.Enqueue(new MoveCommand(player, Direction.Left));
                        commands.Enqueue(new MoveCommand(player, Direction.Left));
                        commands.Enqueue(new MoveCommand(player, Direction.Left));
                        commands.Enqueue(new MoveCommand(player, Direction.Left));
                        commands.Enqueue(new MoveCommand(player, Direction.Up));
                        commands.Enqueue(new MoveCommand(player, Direction.Up));
                        commands.Enqueue(new MoveCommand(player, Direction.Up));
                        commands.Enqueue(new MoveCommand(player, Direction.Up));
                        commands.Enqueue(new MoveCommand(player, Direction.Up));
                        commands.Enqueue(new MoveCommand(player, Direction.Right));
                        commands.Enqueue(new MoveCommand(player, Direction.Right));
                        commands.Enqueue(new MoveCommand(player, Direction.Right));
                        commands.Enqueue(new MoveCommand(player, Direction.Right));
                        commands.Enqueue(new MoveCommand(player, Direction.Right));
                        commands.Enqueue(new MoveCommand(player, Direction.Down));
                        commands.Enqueue(new MoveCommand(player, Direction.Down));
                        commands.Enqueue(new MoveCommand(player, Direction.Down));
                        commands.Enqueue(new MoveCommand(player, Direction.Down));
                        commands.Enqueue(new MoveCommand(player, Direction.Down));
                        break;

                }
            }

            while (commands.Count > 0)
            {
                var command = commands.Dequeue();
                command.Execute();
                Thread.Sleep(100);
            }

        }

        // 10 - вліво, 10 - вниз, 10 - вправо, 10 - вверх
    }
}

public interface IPlayerCommand
{
    public void Execute();

    public void Undo();

}

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class MoveCommand : IPlayerCommand
{
    private Player _player;
    private Direction _direction;
    public MoveCommand(Player player, Direction direction)
    {
        _player = player;
        _direction = direction;
    }
    public void Execute()
    {
        switch (_direction)
        {
            case Direction.Up:
                _player.Up();
                break;
            case Direction.Down:
                _player.Down();
                break;
            case Direction.Left:
                _player.Left();
                break;
            case Direction.Right:
                _player.Right();
                break;
        }
    }

    public void Undo()
    {
        switch (_direction)
        {
            case Direction.Up:
                _player.Down();
                break;
            case Direction.Down:
                _player.Up();
                break;
            case Direction.Left:
                _player.Right();
                break;
            case Direction.Right:
                _player.Left();
                break;
        }
    }

}


public class Player
{
    public Player(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; private set; }
    public int Y { get; private set; }

    public void Render()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write("P");
    }

    public void Clear()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(" ");
    }

    public void Up()
    {
        Clear();
        Y--;
        Render();
    }

    public void Down()
    {
        Clear();
        Y++;
        Render();
    }

    public void Left()
    {
        Clear();
        X--;
        Render();
    }
    public void Right()
    {
        Clear();
        X++;
        Render();
    }

}



