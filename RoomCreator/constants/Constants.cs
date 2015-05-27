using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomCreator
{
    public enum Direction
    {
        Left = 0,
        Up,
        Right,
        Down
    };

    class Constants
    {
        public const double RECTANGLE_WIDTH = 40.0;
        public const double RECTANGLE_SPACE_WIDTH = 20.0;
        public const double CONNECTOR_WIDTH = 10.0;
        public const double CONNECTOR_HEIGHT = 20.0;
        public const double WINDOW_CENTER = 400;
    }
}
