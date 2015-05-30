using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RoomCreator
{
    class NodeMap
    {
        public Node2D CurrentNode { get; set; }
        public Node2D StartNode { get; set; }

        public NodeMap(double p_dblX, double p_dblY)
        {
            StartNode = new Node2D();

            StartNode.Rectangle.XCoordinate = p_dblX;
            StartNode.Rectangle.YCoordinate = p_dblY;
            StartNode.Rectangle.RectangleColor = Brushes.Red;
            CurrentNode = StartNode;

        }

        public void SetSearched(Node2D p_objCurrentNode, bool p_blnSearchToSet)
        {
            if (p_objCurrentNode.IsSearched != p_blnSearchToSet)
            {
                p_objCurrentNode.IsSearched = p_blnSearchToSet;

            }

            if (p_objCurrentNode.LeftNode != null && p_objCurrentNode.LeftNode.IsSearched != p_blnSearchToSet)
            {
                SetSearched(p_objCurrentNode.LeftNode, p_blnSearchToSet);
            }

            if (p_objCurrentNode.RightNode != null && p_objCurrentNode.RightNode.IsSearched != p_blnSearchToSet)
            {
                SetSearched(p_objCurrentNode.RightNode, p_blnSearchToSet);
            }

            if (p_objCurrentNode.UpNode != null && p_objCurrentNode.UpNode.IsSearched != p_blnSearchToSet)
            {
                SetSearched(p_objCurrentNode.UpNode, p_blnSearchToSet);
            }

            if (p_objCurrentNode.DownNode != null && p_objCurrentNode.DownNode.IsSearched != p_blnSearchToSet)
            {
                SetSearched(p_objCurrentNode.DownNode, p_blnSearchToSet);
            }
        }

        public void DrawNodes(Canvas p_objCanvas, Node2D p_objCurrentNode)
        {
            if (!p_objCurrentNode.IsSearched)
            {
                SolidColorBrush objColorToUse; 

                if (p_objCurrentNode == CurrentNode)
                {
                    objColorToUse = Brushes.Yellow;
                }
                else
                {
                    objColorToUse = p_objCurrentNode.Rectangle.RectangleColor;
                }

                Rectangle objRectangle = DrawRectangle(Constants.RECTANGLE_WIDTH, Constants.RECTANGLE_WIDTH, objColorToUse);
                p_objCanvas.Children.Add(objRectangle);
                Canvas.SetTop(objRectangle, p_objCurrentNode.Rectangle.YCoordinate);
                Canvas.SetLeft(objRectangle, p_objCurrentNode.Rectangle.XCoordinate);
                p_objCurrentNode.IsSearched = true;
            }

            if (p_objCurrentNode.LeftNode != null)
            {
                DrawConnectors(p_objCanvas, p_objCurrentNode.LeftNode, Direction.Left);

                if (!p_objCurrentNode.LeftNode.IsSearched)
                {
                    DrawNodes(p_objCanvas, p_objCurrentNode.LeftNode);
                }
            }

            if (p_objCurrentNode.RightNode != null)
            {
                DrawConnectors(p_objCanvas, p_objCurrentNode.RightNode, Direction.Right);

                if (!p_objCurrentNode.RightNode.IsSearched)
                {
                    DrawNodes(p_objCanvas, p_objCurrentNode.RightNode);
                }
            }

            if (p_objCurrentNode.UpNode != null)
            {
                DrawConnectors(p_objCanvas, p_objCurrentNode.UpNode, Direction.Up);

                if (!p_objCurrentNode.UpNode.IsSearched)
                {
                    DrawNodes(p_objCanvas, p_objCurrentNode.UpNode);
                }
            }

            if (p_objCurrentNode.DownNode != null)
            {
                DrawConnectors(p_objCanvas, p_objCurrentNode.DownNode, Direction.Down);

                if (!p_objCurrentNode.DownNode.IsSearched)
                {
                    DrawNodes(p_objCanvas, p_objCurrentNode.DownNode);
                }
            }
        }

        private void DrawConnectors(Canvas p_objCanvas, Node2D p_objCurrentNode, Direction p_objDirection)
        {
            Rectangle objRectangle;

            switch (p_objDirection)
            {
                case Direction.Left:
                    objRectangle = DrawRectangle(Constants.CONNECTOR_HEIGHT, Constants.CONNECTOR_WIDTH, Brushes.Black);
                    p_objCanvas.Children.Add(objRectangle);
                    Canvas.SetTop(objRectangle, p_objCurrentNode.Rectangle.YCoordinate + Constants.RECTANGLE_WIDTH / 2 - Constants.CONNECTOR_WIDTH / 2);
                    Canvas.SetLeft(objRectangle, p_objCurrentNode.Rectangle.XCoordinate + Constants.RECTANGLE_WIDTH);
                    break;
                case Direction.Right:
                    objRectangle = DrawRectangle(Constants.CONNECTOR_HEIGHT, Constants.CONNECTOR_WIDTH, Brushes.Black);
                    p_objCanvas.Children.Add(objRectangle);
                    Canvas.SetTop(objRectangle, p_objCurrentNode.Rectangle.YCoordinate + Constants.RECTANGLE_WIDTH / 2 - Constants.CONNECTOR_WIDTH / 2);
                    Canvas.SetLeft(objRectangle, p_objCurrentNode.Rectangle.XCoordinate - Constants.RECTANGLE_SPACE_WIDTH);
                    break;
                case Direction.Up:
                    objRectangle = DrawRectangle(Constants.CONNECTOR_WIDTH, Constants.CONNECTOR_HEIGHT, Brushes.Black);
                    p_objCanvas.Children.Add(objRectangle);
                    Canvas.SetTop(objRectangle, p_objCurrentNode.Rectangle.YCoordinate + Constants.RECTANGLE_WIDTH);
                    Canvas.SetLeft(objRectangle, p_objCurrentNode.Rectangle.XCoordinate + Constants.RECTANGLE_WIDTH / 2 - Constants.CONNECTOR_WIDTH / 2);
                    break;
                case Direction.Down:
                    objRectangle = DrawRectangle(Constants.CONNECTOR_WIDTH, Constants.CONNECTOR_HEIGHT, Brushes.Black);
                    p_objCanvas.Children.Add(objRectangle);
                    Canvas.SetTop(objRectangle, p_objCurrentNode.Rectangle.YCoordinate - Constants.CONNECTOR_HEIGHT);
                    Canvas.SetLeft(objRectangle, p_objCurrentNode.Rectangle.XCoordinate + Constants.RECTANGLE_WIDTH / 2 - Constants.CONNECTOR_WIDTH / 2);
                    break;
            }
        }

        private Rectangle DrawRectangle(double p_dblWidth, double p_dblHeight, SolidColorBrush p_objColor)
        {
            Rectangle objRect = new Rectangle();

            objRect.Width = p_dblWidth;
            objRect.Height = p_dblHeight;
            objRect.Stroke = p_objColor;
            objRect.StrokeThickness = 2;

            return objRect;
        }

        public Node2D FindNode(Node2D p_objCurrentNode, double p_dblX, double p_dblY)
        {
            if (p_dblX >= p_objCurrentNode.Rectangle.XCoordinate && p_dblX < p_objCurrentNode.Rectangle.XCoordinate + Constants.RECTANGLE_WIDTH &&
                p_dblY >= p_objCurrentNode.Rectangle.YCoordinate && p_dblY < p_objCurrentNode.Rectangle.YCoordinate + Constants.RECTANGLE_WIDTH)
            {
                return p_objCurrentNode;
            }

            p_objCurrentNode.IsSearched = true;
            Node2D objNode;

            if (p_objCurrentNode.LeftNode != null && !p_objCurrentNode.LeftNode.IsSearched)
            {
                objNode = FindNode(p_objCurrentNode.LeftNode, p_dblX, p_dblY);

                if (objNode != null)
                {
                    return objNode;
                }
            }

            if (p_objCurrentNode.RightNode != null && !p_objCurrentNode.RightNode.IsSearched)
            {
                objNode = FindNode(p_objCurrentNode.RightNode, p_dblX, p_dblY);

                if (objNode != null)
                {
                    return objNode;
                }
            }

            if (p_objCurrentNode.UpNode != null && !p_objCurrentNode.UpNode.IsSearched)
            {
                objNode = FindNode(p_objCurrentNode.UpNode, p_dblX, p_dblY);

                if (objNode != null)
                {
                    return objNode;
                }
            }

            if (p_objCurrentNode.DownNode != null && !p_objCurrentNode.DownNode.IsSearched)
            {
                objNode = FindNode(p_objCurrentNode.DownNode, p_dblX, p_dblY);

                if (objNode != null)
                {
                    return objNode;
                }
            }

            return null;
        }

        public void AddNode(Direction p_objDirection, Node2D p_objNodeToConnect = null)
        {
            if (p_objNodeToConnect == null)
            {
                p_objNodeToConnect = new Node2D();
            }

            switch (p_objDirection)
            {
                case Direction.Down:
                    CurrentNode = CurrentNode.SetDownLink(p_objNodeToConnect);
                    break;
                case Direction.Left:
                    CurrentNode = CurrentNode.SetLeftLink(p_objNodeToConnect);
                    break;
                case Direction.Right:
                    CurrentNode = CurrentNode.SetRightLink(p_objNodeToConnect);
                    break;
                case Direction.Up:
                    CurrentNode = CurrentNode.SetUpLink(p_objNodeToConnect);
                    break;
            }
        }     
    }
}
