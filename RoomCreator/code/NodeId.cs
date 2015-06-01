using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomCreator
{
    public static class NodeId
    {
        static int m_NodeID = 0;

        public static int NodeID { get { return m_NodeID; } set { m_NodeID = value; } }

        public static void IncrementNodeID()
        {
            m_NodeID++;
        }
    }
}
