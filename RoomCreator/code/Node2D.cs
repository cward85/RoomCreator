﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RoomCreator
{
    public class Node2D
    {
        public int id { get; set; }
        public Node2D LeftNode { get; set; }
        public Node2D RightNode { get; set; }
        public Node2D UpNode { get; set; }
        public Node2D DownNode { get; set; }
        public RectangleObject Rectangle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsSearched { get; set; }

        public Node2D()
        {
            Rectangle = new RectangleObject();
            Rectangle.RectangleColor = Brushes.Blue;
            IsSearched = false;
            id = NodeId.NodeID;
            NodeId.IncrementNodeID();
        }

        public Node2D SetLeftLink(Node2D p_objNodeToSet)
        {
            p_objNodeToSet.Rectangle.XCoordinate = this.Rectangle.XCoordinate - Constants.RECTANGLE_WIDTH - Constants.RECTANGLE_SPACE_WIDTH;
            p_objNodeToSet.Rectangle.YCoordinate = this.Rectangle.YCoordinate;

            this.LeftNode = p_objNodeToSet;
            this.LeftNode.RightNode = this;

            return p_objNodeToSet;
        }

        public Node2D SetRightLink(Node2D p_objNodeToSet)
        {
            p_objNodeToSet.Rectangle.XCoordinate = this.Rectangle.XCoordinate + Constants.RECTANGLE_WIDTH + Constants.RECTANGLE_SPACE_WIDTH;
            p_objNodeToSet.Rectangle.YCoordinate = this.Rectangle.YCoordinate;

            this.RightNode = p_objNodeToSet;
            this.RightNode.LeftNode = this;

            return p_objNodeToSet;
        }

        public Node2D SetUpLink(Node2D p_objNodeToSet)
        {
            p_objNodeToSet.Rectangle.XCoordinate = this.Rectangle.XCoordinate;
            p_objNodeToSet.Rectangle.YCoordinate = this.Rectangle.YCoordinate - Constants.RECTANGLE_WIDTH - Constants.RECTANGLE_SPACE_WIDTH;

            this.UpNode = p_objNodeToSet;
            this.UpNode.DownNode = this;

            return p_objNodeToSet;
       }

        public Node2D SetDownLink(Node2D p_objNodeToSet)
        {
            p_objNodeToSet.Rectangle.XCoordinate = this.Rectangle.XCoordinate;
            p_objNodeToSet.Rectangle.YCoordinate = this.Rectangle.YCoordinate + Constants.RECTANGLE_WIDTH + Constants.RECTANGLE_SPACE_WIDTH;

            this.DownNode = p_objNodeToSet;
            this.DownNode.UpNode = this;

            return p_objNodeToSet;
        }



    }
}
