using System;
using System.Text;

namespace YOOI
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            bool isParsable = Int32.TryParse(args[0], out number);

            if (isParsable)
            {
                String result = render(number);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Input could not be parsed into a number.");
            }
        }

        public static String render(int n)
        {
            int[,] spiralArray = createSpiralArray(n);
            return renderTableFromArray(spiralArray, n);
        }

        private static int[,] createSpiralArray(int n)
        {
            int[,] spiralArray = new int[n, n];
            int value = 1;

            int rowIndex = 0, columnIndex = 0;
            int rowDimension = n, columnDimension = n;

            while (rowIndex < rowDimension && columnIndex < columnDimension)
            {
                // Write the first row
                for (int i = columnIndex; i < columnDimension; ++i)
                {
                    spiralArray[rowIndex, i] = value++;
                }

                // Change to next row
                rowIndex++;

                // Write the last column
                for (int i = rowIndex; i < rowDimension; ++i)
                {
                    spiralArray[i, columnDimension - 1] = value++;
                }

                // Reduce cube size by one colunm
                columnDimension--;

                // Write last row
                if (rowIndex < rowDimension)
                {
                    // Write the row right to left
                    for (int i = columnDimension - 1; i >= columnIndex; --i)
                    {
                        spiralArray[rowDimension - 1, i] = value++;
                    }
                    // Reduce cube size by one row 
                    rowDimension--;
                }

                // Write first column 
                if (columnIndex < columnDimension)
                {
                    //Write it bottom up
                    for (int i = rowDimension - 1; i >= rowIndex; --i)
                    {
                        spiralArray[i, columnIndex] = value++;
                    }
                    // Remove first column for the cube
                    columnIndex++;
                }
            }

            return spiralArray;
        }

        private static String renderTableFromArray(int[,] spiral, int dimension)
        {
            StringBuilder sb = new StringBuilder("");

            if (spiral.Length > 0)
            {
                sb.Append("<table border=1><tr>");

                for (int i = 0; i < dimension; i++)
                {
                    for (int j = 0; j < dimension; j++)
                    {
                        sb.Append($"<td>{spiral[i, j]}</td>");
                    }
                }
                sb.Append("</tr></table>");
            }

            return sb.ToString();
        }
    }
}
