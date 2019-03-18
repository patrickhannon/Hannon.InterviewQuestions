using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    class SpiralWrite
    {
        private int _max = 4;
        public int max_i = 4, max_j = 4, min_i = 0, min_j = 0;
        public char[,] matrix = new char[5, 5] {
            {'i',   'l',    'o',    'v',    'e' },
            {'d',   'i',    'n',    't',    'e' },
            {'n',   'e',    'w',    'e',    'p' },
            {'a',   'i',    'v',    'r',    'i' },
            {'m',   'a',    'x',    'e',    'c' }
        };
    }
}
