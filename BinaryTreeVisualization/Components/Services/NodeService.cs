﻿namespace BinaryTreeVisualization.Components.Services
{
    public class NodeService
    {
        public int Value { get; set; }  // Giá trị của node
        public NodeService? LeftChild { get; set; }   // Node con bên trái (nullable)
        public NodeService? RightChild { get; set; }  // Node con bên phải (nullable)
        public NodeService? Parent { get; set; }      // Node cha (nullable)

        // Thuộc tính hỗ trợ trực quan hóa
        public double PositionX { get; set; }    // Tọa độ X của node
        public double PositionY { get; set; }    // Tọa độ Y của node
        public bool IsHighlighted { get; set; }  // Trạng thái highlight của node (true/false)

        // Thuộc tính dùng cho việc kiểm tra cân bằng cây AVL
        public int Height { get; set; }   // Chiều cao của node trong cây
        public int Depth { get; set; }    // Độ sâu của node trong cây

        // Định danh duy nhất cho mỗi node
        public Guid NodeID { get; set; }  // ID duy nhất của node

        public bool IsRoot { get; set; }  // Đánh dấu node gốc

        public bool IsVisible { get; set; } // Thuộc tính mới

        // Constructor của NodeService
        public NodeService(int value)
        {
            Value = value;
            LeftChild = null;
            RightChild = null;
            Parent = null;
            PositionX = 0;
            PositionY = 0;
            IsHighlighted = false;
            Height = 1;   // Mặc định chiều cao của node khi mới tạo là 1
            Depth = 0;    // Mặc định độ sâu khi node mới được thêm vào là 0
            NodeID = Guid.NewGuid();   // Tạo ID duy nhất cho node
            IsRoot = false;
        }

        // Cập nhật chiều cao của node dựa trên chiều cao của con trái và con phải
        public void UpdateHeight()
        {
            int leftHeight = LeftChild?.Height ?? 0;
            int rightHeight = RightChild?.Height ?? 0;
            Height = 1 + Math.Max(leftHeight, rightHeight);
        }

        // Cập nhật độ sâu của node dựa trên độ sâu của node cha
        public void UpdateDepth()
        {
            Depth = Parent != null ? Parent.Depth + 1 : 0;
        }
    }
}
