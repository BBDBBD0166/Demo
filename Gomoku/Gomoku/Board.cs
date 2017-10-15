using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Gomoku
{
    class Board
    {
        private static readonly Point NO_MATCH_NODE = new Point(-1, -1);

        private static readonly int OFFSET = 75; //棋盤與程式邊框的間距
        private static readonly int NODE_RADIUS = 10;//棋子的半徑
        private static readonly int NODE_DISTRANCE = 75;//節點的間距

        public bool CanBePlaced(int x,int y)
        {
            // 找出最近的節點(Node)
            Point nodeId = FindTheClosetNode(x, y);

            // 如果沒有的話回傳false
            if (nodeId == NO_MATCH_NODE)
                return false;
            //如果有的話，檢查是否已經有棋子存在
            return true;
        }
        private Point FindTheClosetNode(int x,int y)
        {
            int nodeIdX = FindTheClosetNode(x);
            if (nodeIdX == -1)
                return NO_MATCH_NODE;

            int nodeIdY = FindTheClosetNode(y);
            if (nodeIdY == -1)
                return NO_MATCH_NODE;
            return new Point(nodeIdX, nodeIdY);
        }

        private int FindTheClosetNode(int pos)
        {
            if (pos < OFFSET - NODE_RADIUS)//判斷棋盤外圈
                return -1;

            pos -= OFFSET;

            int quotient = pos / NODE_DISTRANCE;//商數
            int remainder = pos % NODE_DISTRANCE;//餘數

            if (remainder <= NODE_RADIUS)
                return quotient;
            else if (remainder >= NODE_DISTRANCE - NODE_RADIUS)
                return quotient + 1;
            else
                return -1;
        }
    }
}
