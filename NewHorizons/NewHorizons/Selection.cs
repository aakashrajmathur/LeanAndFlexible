﻿using System;
using System.Collections.Generic;
using System.Windows;

namespace NewHorizons
{
    public class Selection
    {
        public string name;
        public bool isSystemCreated;

        public List<Part> partsAlwaysIncluded;
        public List<Part> partsIncluded;
        public List<Part> partsNotIncluded;
        public List<Part> partsNeverIncluded;

        public List<Node> FromToMapAsList;

        public Selection()
        {
            partsAlwaysIncluded = new List<Part>();
            partsIncluded = new List<Part>();
            partsNotIncluded = new List<Part>();
            partsNeverIncluded = new List<Part>();

            FromToMapAsList = new List<Node>();
        }

        public void ComputeFromToInformation()
        {
            FromToMapAsList.Clear();

            foreach (Part p in partsAlwaysIncluded)
            {
                for (int i = 1; i < p.routing.Count; i++)
                {
                    //string currentMachinePair = p.routing[i - 1].name + "-" + p.routing[i].name;
                    Node node = GetNode(p.routing[i - 1], p.routing[i]); 
                    if(node == null)
                    {
                        FromToMapAsList.Add(new Node(p.routing[i - 1], p.routing[i], 1));
                    }
                    else
                    {
                        node.freq++;
                    }
                }
            }
            foreach (Part p in partsIncluded)
            {
                for (int i = 1; i < p.routing.Count; i++)
                {
                    Node node = GetNode(p.routing[i - 1], p.routing[i]);
                    if (node == null)
                    {
                        FromToMapAsList.Add(new Node(p.routing[i - 1], p.routing[i], (int)Math.Round(p.revenue)));
                    }
                    else
                    {
                        node.freq = (int)Math.Round(p.revenue);
                    }
                }
            }

            FromToMapAsList.Sort();

            //foreach(Node n in FromToMapAsList)
           // {
           //     MessageBox.Show(n.fromMachine.name.ToString() + " -> " + n.toMachine.name.ToString() + " = " + n.freq.ToString());
           // }

            
        }

        private Node GetNode(Machine machine1, Machine machine2)
        {
            foreach(Node node in FromToMapAsList)
            {
                if( (node.fromMachine.name == machine1.name) && (node.toMachine.name == machine2.name))
                {
                    return node;
                }
            }
            return null;
        }

        //Maintain the list of machines
        public List<Machine> GetListOfMachines()
        {
            List<Machine> list = new List<Machine>();
            foreach (Part p in partsAlwaysIncluded)
            {
                foreach (Machine m in p.routing)
                {
                    if (!list.Contains(m))
                    {
                        list.Add(m);
                    }
                }
            }

            foreach (Part p in partsIncluded)
            {
                foreach (Machine m in p.routing)
                {
                    if (!list.Contains(m))
                    {
                        list.Add(m);
                    }
                }
            }
            return list;
        }

        //Also maintain the score between machines for current selection: 
        //Given 
    }


    public class Node : IComparable<Node>
    {
        public Machine fromMachine;
        public Machine toMachine;
        public int freq;        

        public Node(Machine m1, Machine m2, int freq)
        {
            this.fromMachine = m1;
            this.toMachine = m2;
            this.freq = freq;
        }

        public int CompareTo(Node node2)
        {
            return node2.freq - this.freq;
        }
    }
}