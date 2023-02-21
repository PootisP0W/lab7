using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhurkevich_lab7
{
    internal class ArrowsManager
    {
        private int min;
        private int max;
        private int current;

        public ArrowsManager(int min, int max)
        {
            this.min = min;
            this.max = max;
            current = min;
        }

        public void Down()
        {
            EraseArrow();
            if (current == max)
            {
                current = min;
                Console.SetCursorPosition(0, 0);
            }
            else
            {
                current++;
            }
            DrawArrow();
        }

        public void Up()
        {
            EraseArrow();
            if (current == min)
            {
                current = max;
            }
            else
            {
                current--;
            }
            DrawArrow();
        }


        private void DrawArrow()
        {
            Console.SetCursorPosition(0, current);
            Console.Write("->");
        }

        private void EraseArrow()
        {
            Console.SetCursorPosition(0, current);
            Console.Write("  ");
        }
    }
}
