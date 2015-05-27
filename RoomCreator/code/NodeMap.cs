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

        public void DrawNodes(Canvas p_objCanvas, Node2D p_objCurrentNode)
        {           
            if (!p_objCurrentNode.IsSearched)
            {
                Rectangle objRectangle = DrawRectangle(Constants.RECTANGLE_WIDTH, Constants.RECTANGLE_WIDTH, p_objCurrentNode.Rectangle.RectangleColor);
                p_objCanvas.Children.Add(objRectangle);
                Canvas.SetTop(objRectangle, p_objCurrentNode.Rectangle.YCoordinate);
                Canvas.SetLeft(objRectangle, p_objCurrentNode.Rectangle.XCoordinate);
                p_objCurrentNode.IsSearched = true;                
            }

            if (p_objCurrentNode.LeftNode != null && !p_objCurrentNode.LeftNode.IsSearched)
            {
                DrawConnectors(p_objCanvas, p_objCurrentNode.LeftNode, Direction.Left);
                DrawNodes(p_objCanvas, p_objCurrentNode.LeftNode);
            }

            if (p_objCurrentNode.RightNode != null && !p_objCurrentNode.RightNode.IsSearched)
            {
                DrawConnectors(p_objCanvas, p_objCurrentNode.RightNode, Direction.Right);
                DrawNodes(p_objCanvas, p_objCurrentNode.RightNode);
            }

            if (p_objCurrentNode.UpNode != null && !p_objCurrentNode.UpNode.IsSearched)
            {
                DrawConnectors(p_objCanvas, p_objCurrentNode.UpNode, Direction.Up);
                DrawNodes(p_objCanvas, p_objCurrentNode.UpNode);
            }

            if (p_objCurrentNode.DownNode != null && !p_objCurrentNode.DownNode.IsSearched)
            {
                DrawConnectors(p_objCanvas, p_objCurrentNode.DownNode, Direction.Down);
                DrawNodes(p_objCanvas, p_objCurrentNode.DownNode);
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

        public void AddLeftNode(double p_fltCurrentX, double p_fltCurrentY)
        {
            CurrentNode = CurrentNode.SetLeftLink(new Node2D(), p_fltCurrentX, p_fltCurrentY);
        }

        public void AddRightNode(double p_fltCurrentX, double p_fltCurrentY)
        {
            CurrentNode = CurrentNode.SetRightLink(new Node2D(), p_fltCurrentX, p_fltCurrentY);
        }

        public void AddUpNode(double p_fltCurrentX, double p_fltCurrentY)
        {
            CurrentNode = CurrentNode.SetUpLink(new Node2D(), p_fltCurrentX, p_fltCurrentY);
        }

        public void AddDownNode(double p_fltCurrentX, double p_fltCurrentY)
        {
            CurrentNode = CurrentNode.SetDownLink(new Node2D(), p_fltCurrentX, p_fltCurrentY);
        }


    }
}
