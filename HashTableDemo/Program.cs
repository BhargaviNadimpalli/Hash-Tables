using System;
using System.Collections;
using System.Collections.Generic;


namespace HashTableDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to hash table programs");

            MyMapNode<string, string> mapNode = new MyMapNode<string, string>(5);
            Console.WriteLine("Adding KeyValue pair");
            mapNode.Add("0", "to");
            mapNode.Add("1", "be");
            mapNode.Add("2", "or");
            mapNode.Add("3", "to");
            mapNode.Add("4", "be");
            mapNode.Add("5", "not");
            Console.WriteLine("------------");
            mapNode.GetFrequence("or");


        }
    }
}
