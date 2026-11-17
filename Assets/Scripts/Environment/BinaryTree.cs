using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BinaryTree {
    private class Node {
        public string DateKey;
        public List<Worker> Workers;
        public Node Left;
        public Node Right;

        public Node(string dateKey, Worker worker) {
            DateKey = dateKey;
            Workers = new List<Worker> { worker };
        }
    }

    private Node root;

    public void Insert(Worker worker) {
        string key = worker.LastEntranceInEngineRoom.Split('T')[0];
        root = InsertRec(root, key, worker);
    }

    private Node InsertRec(Node current, string key, Worker worker) {
        if(current == null) {
            return new Node(key, worker);
        }

        int compare = string.CompareOrdinal(key, current.DateKey);

        if(compare < 0) {
            current.Left = InsertRec(current.Left, key, worker);
        }
        else if(compare > 0) {
            current.Right = InsertRec(current.Right, key, worker);
        }
        else {
            current.Workers.Add(worker);
        }

        return current;
    }

    public Worker[] Search(string dateQuery) {
        Node result = SearchRec(root, dateQuery);

        if(result != null) {
            return result.Workers.ToArray();
        }

        return new Worker[0];
    }


    private Node SearchRec(Node current, string dateQuery) {
        if(current == null) {
            return null;
        }

        int compare = string.CompareOrdinal(dateQuery, current.DateKey);

        if(compare == 0) {
            return current;
        }
        else if(compare < 0) {
            return SearchRec(current.Left, dateQuery);
        }
        else {
            return SearchRec(current.Right, dateQuery);
        }
    }

    public Worker[] SearchRange(string startDate, string endDate) {
        List<Worker> results = new List<Worker>();
        SearchRangeRec(root, startDate, endDate, results);
        return results.ToArray();
    }

    private void SearchRangeRec(Node current, string startDate, string endDate, List<Worker> results) {
        if(current == null) {
            return;
        }

        int compareStart = string.CompareOrdinal(startDate, current.DateKey);
        int compareEnd = string.CompareOrdinal(endDate, current.DateKey);

        if(compareStart < 0) {
            SearchRangeRec(current.Left, startDate, endDate, results);
        }

        if(compareStart <= 0 && compareEnd >= 0) {
            results.AddRange(current.Workers);
        }

        if(compareEnd > 0) {
            SearchRangeRec(current.Right, startDate, endDate, results);
        }
    }

    public void Clear() {
        root = null;
    }
}
