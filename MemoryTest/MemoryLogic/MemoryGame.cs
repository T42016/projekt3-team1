﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MineSweeperLogic;

namespace MemoryLogic
{
    public class MemoryGame
    {
        enum Gamestate
        {
            Running,
            Won
        }

        private static char[] symbols = { '*', '!', 'w', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o' };
        Gamestate state;
        public int posX { get; private set; }
        public int posY { get; private set; }
        private bool check = false;
        public int SizeX { get; }
        public int SizeY { get; }
        public int Moves { get; private set; }
        public int Draws { get; private set; }
        public bool HasMismatch => lastOpened.Count == 2;
        public GameState State { get; private set; }

        public MemoryGame(int sizeX, int sizeY)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            _board = new PositionInfo[sizeX, sizeY];
            ResetBoard();
        }

        private PositionInfo[,] _board;
        private List<PositionInfo> lastOpened = new List<PositionInfo>();

        public void ResetBoard()
        {
            Random rnd = new Random();
            List<int> values = new List<int>();
            Draws = 0;

            for (int i = 0; i < SizeX*SizeY; i++)
                values.Add(i/2);

            for (int x = 0; x < SizeX; x++)
                for (int y = 0; y < SizeY; y++)
                {
                    int index = rnd.Next(values.Count);
                    _board[x, y] = new PositionInfo()
                    {
                        X = x,
                        Y = y,
                        Value = values[index]
                    };
                    values.RemoveAt(index);
                }
        }

        public PositionInfo GetCoordinate(int x, int y)
        {
            if (x < 0 || x >= SizeX || y < 0 || y > SizeY)
                throw new IndexOutOfRangeException();

            return _board[x, y];
        }

        public void CloseMismatch()
        {
            if (lastOpened.Count == 0)
                return;

            lastOpened.ForEach(c => c.IsOpen = false);
            lastOpened.Clear();
        }

        public void ClickCoordinate(int x, int y)
        {
            var coord = GetCoordinate(x, y);
            if (coord.IsOpen || lastOpened.Count == 2)
                return;

            coord.IsOpen = true;
            if (lastOpened.Count == 1 && lastOpened.First().Value == coord.Value)
            {
                coord.IsFound = true;
                lastOpened.First().IsFound = true;
                lastOpened.Clear();
                Draws++;
            }
            else
            {
                lastOpened.Add(coord);
                if(lastOpened.Count == 2)
                    Draws++;
            }
        }

        public void Update(ConsoleKey key)
        {
            if (HasMismatch)
            {
                CloseMismatch();

            }
            if (key == ConsoleKey.LeftArrow && posX > 0)
                posX--;
            if (key == ConsoleKey.RightArrow && posX < SizeX - 1)
                posX++;
            if (key == ConsoleKey.UpArrow && posY > 0)
                posY--;
            if (key == ConsoleKey.DownArrow && posY < SizeY - 1)
                posY++;
            if (key == ConsoleKey.R)
                ResetBoard();
        }

        public void DrawBoard()
        {
            Console.Clear();


            for (int y = 0; y < SizeY; y++)
            {
                for (int x = 0; x < SizeX; x++)
                {
                    if (x == posX && y == posY)
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                    else
                        Console.BackgroundColor = ConsoleColor.Black;

                    var info = GetCoordinate(x, y);
                    if (info.IsOpen)
                    {
                        Console.ForegroundColor = info.IsFound ? ConsoleColor.Green : ConsoleColor.Cyan;
                        Console.Write(symbols[info.Value] + " ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(". ");
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Moves: " + Moves);
            if (HasMismatch)
                Console.WriteLine("Press any key");
        }


        private void GameWon()
        {
            Console.WriteLine("You won");
            Console.ReadLine();
            ResetBoard();
        }
    }
}
