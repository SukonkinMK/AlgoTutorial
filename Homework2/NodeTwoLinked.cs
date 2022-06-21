using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    public class NodeTwoLinked : ILnkedList
    {
        public int Value { get; set; }
        public NodeTwoLinked NextItem { get; set; }
        public NodeTwoLinked PrevItem { get; set; }

        public void AddNodeAfter(NodeTwoLinked node, int value)
        {
            NodeTwoLinked newNode = new NodeTwoLinked() { Value = value };
            NodeTwoLinked nextNode = node.NextItem;
            node.NextItem = newNode;
            newNode.PrevItem = node;
            nextNode.PrevItem = newNode;
            newNode.NextItem = nextNode;
        }

        public void AddNote(int value)
        {
            NodeTwoLinked newNode = new NodeTwoLinked() { Value = value };
            NodeTwoLinked currentNode = this;
            if (NextItem != null)
            {
                currentNode = currentNode.NextItem;
            }
            currentNode.NextItem = newNode;
            newNode.PrevItem = currentNode;
        }

        public NodeTwoLinked FindNode(int searchValue)
        {
            NodeTwoLinked startNode = this;
            NodeTwoLinked currentNode = startNode;
            while (currentNode != null)
            {
                if (searchValue == currentNode.Value)
                {
                    return currentNode;
                }
                currentNode = currentNode.NextItem;
            }
            currentNode = startNode.PrevItem;
            while (currentNode != null)
            {
                if (searchValue == currentNode.Value)
                {
                    return currentNode;
                }
                currentNode = currentNode.PrevItem;
            }
            return null;
        }

        public int GetCount()
        {
            int count = 1;
            if (NextItem == null)
            {
                return count;
            }
            count++;
            NodeTwoLinked node = NextItem;
            while (node.NextItem != null)
            {
                count++;
                node = node.NextItem;
            }
            return count;
        }

        public void RemoveNode(int index)
        {
            NodeTwoLinked currentNode = this;
            NodeTwoLinked startNode = currentNode;
            while (currentNode != null)
            {
                startNode = currentNode;
                currentNode = currentNode.PrevItem;
            }
            int currentIndex = 0;
            currentNode = startNode;
            while (currentNode != null)
            {
                if (index == currentIndex)
                {
                    RemoveNode(currentNode);
                    return;
                }
                currentNode = currentNode.NextItem;
                currentIndex++;
            }
        }

        public void RemoveNode(NodeTwoLinked node)
        {
            NodeTwoLinked prevNode = node.PrevItem;
            NodeTwoLinked nextNode = node.NextItem;
            prevNode.NextItem = nextNode;
            nextNode.PrevItem = prevNode;
        }
    }
    public interface ILnkedList
    {
        int GetCount(); //количество элементов в списке
        void AddNote(int value); //добавляет новый элемент в список
        void AddNodeAfter(NodeTwoLinked node, int value); //добавляет новый элемент в список после определ эл-та
        void RemoveNode(int index);
        void RemoveNode(NodeTwoLinked node);
        NodeTwoLinked FindNode(int searchValue);
    }
}
