using System;
using System.IO;
using System.Collections.Generic;
using Visualizer.Parser.Interfaces;
using Visualizer.Parser.ResultTypes;


namespace Visualizer.Parser.Implementation
{
    class MapParser : IMapParser
    {
        private string File;
        private StreamReader reader;
        public MapParser()
        {
            File = @"Map.txt";
            reader = new StreamReader(File);
        }

        public bool Finished
        {
            get
            {
                return (reader.Peek() == -1);
            }
        }

        private int[] MapString(string[] ListString)
        {
            int[] mapstring = new int[ListString.Length];
            for (int i = 0; i < ListString.Length - 1; i++)
            {
                mapstring[i] = int.Parse(ListString[i]);
            }
            return mapstring;
        }
        private void ToMatrix(ref int[][] Matrix, List<string[]> MapList)
        {
            int i = 0;
            while (i != MapList.Count)
            {
                Matrix[i] = MapString(MapList[i]);
                i++;
            }
        }
        public MapResult GetMap()
        {
            int termsize = int.Parse(reader.ReadLine());

            List<string[]> MapList = new List<string[]>();
            MapList.Add(reader.ReadLine().Split(' ', '\n'));
            int width = MapList[0].Length;
            while (!Finished)
            {
                MapList.Add(reader.ReadLine().Split(' ', '\n'));
            }
            reader.Close();

            int[][] Matrix = new int[width][];
            ToMatrix(ref Matrix, MapList);
            MapResult Map = new MapResult(termsize, Matrix);
            return Map;
        }

        public MapResult ParseLine()
        {
            throw new NotImplementedException();
        }
    }
}