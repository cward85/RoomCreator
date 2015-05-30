using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoomCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NodeMap m_nodeMap;

        public MainWindow()
        {
            InitializeComponent();
            SetupNodes();
            
            DrawGraphics();
        }

        private void SetupNodes()
        {
            m_nodeMap = new NodeMap(MainCanvas.Width / 2, MainCanvas.Height / 2);
            m_nodeMap.AddNode(Direction.Left, null);
            m_nodeMap.AddNode(Direction.Up, null);
            m_nodeMap.AddNode(Direction.Left, null);
            m_nodeMap.AddNode(Direction.Up, null);
            m_nodeMap.AddNode(Direction.Up, null);
            m_nodeMap.AddNode(Direction.Right, null);
            m_nodeMap.AddNode(Direction.Down, null);
            m_nodeMap.DrawNodes(MainCanvas, m_nodeMap.StartNode);
            m_nodeMap.SetSearched(m_nodeMap.StartNode, false);
            btnRestart.Visibility = System.Windows.Visibility.Hidden;
        }

        private void DrawGraphics()
        {           
            
        }

        private void ShowRoomEdit()
        {
            RoomEditWindow objWindow = new RoomEditWindow();

            objWindow.PopulateData(m_nodeMap.CurrentNode);

            objWindow.ShowDialog();
        }

        private void AddNewNode(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void AddNode()
        {
            Node2D objNode = m_nodeMap.FindNode(m_nodeMap.StartNode, Mouse.GetPosition(MainCanvas).X, Mouse.GetPosition(MainCanvas).Y);
            Direction objNodeDirection = DetermineDirection(m_nodeMap.CurrentNode, Mouse.GetPosition(MainCanvas).X, Mouse.GetPosition(MainCanvas).Y);

            switch (objNodeDirection)
            {
                case Direction.Up:
                case Direction.Right:
                case Direction.Left:
                case Direction.Down:
                    m_nodeMap.AddNode(objNodeDirection, objNode);
                    break;
                case Direction.None:
                    if (objNode != null)
                    {
                        if (m_nodeMap.CurrentNode == objNode)
                        {
                            ShowRoomEdit();
                        }
                        else
                        {
                            m_nodeMap.CurrentNode = objNode;
                        }
                    };
                    break;
            }

            m_nodeMap.SetSearched(m_nodeMap.StartNode, false);
            m_nodeMap.DrawNodes(MainCanvas, m_nodeMap.StartNode);
            m_nodeMap.SetSearched(m_nodeMap.StartNode, false);
        }

        private void DeleteNode()
        {
            Node2D objNode = m_nodeMap.FindNode(m_nodeMap.StartNode, Mouse.GetPosition(MainCanvas).X, Mouse.GetPosition(MainCanvas).Y);

            if (objNode != null)
            {
                if (objNode.LeftNode != null)
                {
                    objNode.LeftNode.RightNode = null;
                    objNode.LeftNode = null;
                }

                if (objNode.UpNode != null)
                {
                    objNode.UpNode.DownNode = null;
                    objNode.UpNode = null;
                }

                if (objNode.DownNode != null)
                {
                    objNode.DownNode.UpNode = null;
                    objNode.DownNode = null;
                }

                if (objNode.RightNode != null)
                {
                    objNode.RightNode.LeftNode = null;
                    objNode.RightNode = null;
                }

                MainCanvas.Children.Clear();
                m_nodeMap.CurrentNode = m_nodeMap.StartNode;
                m_nodeMap.SetSearched(m_nodeMap.StartNode, false);
                m_nodeMap.DrawNodes(MainCanvas, m_nodeMap.StartNode);
                m_nodeMap.SetSearched(m_nodeMap.StartNode, false);                
            }
        }        
        
        private Direction DetermineDirection(Node2D p_objCurrentNode, double p_dblX, double p_dblY)
        {
            if (p_dblX > p_objCurrentNode.Rectangle.XCoordinate + Constants.RECTANGLE_WIDTH + Constants.RECTANGLE_SPACE_WIDTH && p_dblX < p_objCurrentNode.Rectangle.XCoordinate + Constants.RECTANGLE_WIDTH + Constants.RECTANGLE_WIDTH + Constants.RECTANGLE_SPACE_WIDTH &&
                p_dblY > p_objCurrentNode.Rectangle.YCoordinate && p_dblY < p_objCurrentNode.Rectangle.YCoordinate + Constants.RECTANGLE_WIDTH)
            {
                return Direction.Right;
            }
            else if (p_dblX < p_objCurrentNode.Rectangle.XCoordinate - Constants.RECTANGLE_SPACE_WIDTH && p_dblX > p_objCurrentNode.Rectangle.XCoordinate - Constants.RECTANGLE_WIDTH - Constants.RECTANGLE_SPACE_WIDTH &&
                p_dblY > p_objCurrentNode.Rectangle.YCoordinate && p_dblY < p_objCurrentNode.Rectangle.YCoordinate + Constants.RECTANGLE_WIDTH)
            {
                return Direction.Left;
            }
            else if (p_dblX > p_objCurrentNode.Rectangle.XCoordinate && p_dblX < p_objCurrentNode.Rectangle.XCoordinate + Constants.RECTANGLE_WIDTH &&
                p_dblY > p_objCurrentNode.Rectangle.YCoordinate + Constants.RECTANGLE_WIDTH + Constants.RECTANGLE_SPACE_WIDTH && p_dblY < p_objCurrentNode.Rectangle.YCoordinate + Constants.RECTANGLE_WIDTH + Constants.RECTANGLE_WIDTH + Constants.RECTANGLE_SPACE_WIDTH)
            {
                return Direction.Down;
            }
            else if (p_dblX > p_objCurrentNode.Rectangle.XCoordinate && p_dblX < p_objCurrentNode.Rectangle.XCoordinate + Constants.RECTANGLE_WIDTH &&
                p_dblY > p_objCurrentNode.Rectangle.YCoordinate - Constants.RECTANGLE_WIDTH - Constants.RECTANGLE_WIDTH && p_dblY < p_objCurrentNode.Rectangle.YCoordinate - Constants.RECTANGLE_SPACE_WIDTH)
            {
                return Direction.Up;
            }

            return Direction.None;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            MainCanvas.Children.Clear();
            btnRestart.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            SetupNodes();
            
        }

        private void MouseLeftClick(object sender, MouseButtonEventArgs e)
        {
            AddNode();
        }

        private void MouseRightClick(object sender, MouseButtonEventArgs e)
        {
            DeleteNode();
        }
    }
}
