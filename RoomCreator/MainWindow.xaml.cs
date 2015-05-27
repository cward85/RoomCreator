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
            m_nodeMap.AddLeftNode(0, 0);
            m_nodeMap.AddUpNode(0, 0);
            m_nodeMap.AddLeftNode(0, 0);
            m_nodeMap.AddUpNode(0, 0);
            m_nodeMap.AddUpNode(0, 0);
            m_nodeMap.AddRightNode(0, 0);
            m_nodeMap.AddDownNode(0, 0);
            m_nodeMap.DrawNodes(MainCanvas, m_nodeMap.StartNode);

            btnRestart.Visibility = System.Windows.Visibility.Hidden;
        }

        private void DrawGraphics()
        {           
            
        }

        private void AddNewNode(object sender, MouseButtonEventArgs e)
        {

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
    }
}
