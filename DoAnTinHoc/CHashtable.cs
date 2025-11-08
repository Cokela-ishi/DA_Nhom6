using System;
using System.Text;
using System.Xml;

namespace DoAnTinHoc
{
    class Node
    {
        #region attributes
        private MatHang data;
        public Node next;
        #endregion
        #region properties
        public MatHang Data
        {

            get => data;
            set => data = value;
        }
        public Node Next
        {
            get => next;
            set => next = value;
        }
        #endregion
        #region methods
        public Node(MatHang mh)
        {
            this.data = mh;
            this.Next = null;
        }
        public Node()
        {
            this.data = null;
            this.Next = null;
        }
        #endregion
    }
    public class HashTable
    {
        #region attributes
        private const int M = 1009;
        private Node[] buckets = new Node[M];
        private int count = 0;// tổng số node đã được thêm vào tất cả các bucket của hashtable
        #endregion
        #region properties
        public int Count
        {
            get { return count; }
        }
        #endregion
        #region method
        public HashTable()
        {
            buckets = new Node[M];
            count = 0;

        }
        #endregion

        private int HashFunction(string ma)
        {
            long h = 0;
            int basevalue = 37;// cơ số hàm băm horner giúp cho vị trí của kí tự trong chuỗi tạo ra ảnh hưởng khách nhau
            foreach (char c in ma)
            {
                h = h * basevalue + c;
            }
            return (int)h % M;
        }
        public void Add(MatHang mh)
        {
            int index = HashFunction(mh.MaMatHang);
            Node newNode = new Node(mh);
            newNode.Next = buckets[index];
            buckets[index] = newNode;
            count++;

        }
        public MatHang Search(string ma)
        {
            int index = HashFunction(ma);
            Node t = buckets[index];
            while (t != null)
            {
                if (t.Data.MaMatHang.Equals(ma))
                {
                    return t.Data;
                }
                t = t.Next;
            }
            return null;
        }
        public bool Remove(string mh)
        {
            int index = HashFunction(mh);
            Node t = buckets[index];
            Node pre = null;
            while (t != null)
            {
                if (t.Data.MaMatHang == mh)
                {
                    if (pre == null)
                        buckets[index] = t.Next;
                    else
                        pre.Next = t.Next;
                    count--;
                    return true;
                }
                pre = t;
                t = t.Next;
            }
            return false;
        }
        public void PrintHashTable()
        {
            for (int i = 0; i < M; i++)
            {
                Console.WriteLine($"Bucket[{i}]: ");
                Node t = buckets[i];
                while (t != null)
                {
                    t.Data.XuatThongTin();
                    t = t.Next;
                }

            }
        }

    }
}


