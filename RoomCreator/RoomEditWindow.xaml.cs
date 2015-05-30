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
using System.Windows.Shapes;

namespace RoomCreator
{
    /// <summary>
    /// Interaction logic for RoomEditWindow.xaml
    /// </summary>
    public partial class RoomEditWindow : Window
    {
        Node2D m_objNode;

        public RoomEditWindow()
        {
            InitializeComponent();
        }

        public void PopulateData(Node2D p_objNode)
        {
            txtRoomName.Text = p_objNode.Title;            
            txtDescription.Document.Blocks.Clear();
            txtDescription.AppendText(p_objNode.Description);
            m_objNode = p_objNode;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            m_objNode.Title = txtRoomName.Text;
            m_objNode.Description = new TextRange(txtDescription.Document.ContentStart, txtDescription.Document.ContentEnd).Text;

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
