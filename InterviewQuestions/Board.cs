using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class Board
    {
        private char[,] _board;

        public Board(char[,] board, params string[] rows)
        {
            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    board[i, j] = rows[i][j];
                }
            }
        }

        public int TotalTypesVertically()
        {
            return -1;
        }

        public int TotalTypesHorizontally()
        {
            return -1;
        }

        public int TotalTypesDiagonal()
        {
            return -1;
        }

        public void MoveHorizionally()
        {

        }

        public void MoveVertically()
        {

        }

        public void MoveDiagonally()
        {

        }
    }
}
