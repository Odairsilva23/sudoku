using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace sudoku.consoleapp
{
    class Program
    {
        private static IEnumerable<string> soduko;

        static void Main(string[] args)
        {
            Console.WriteLine("SUDOKO MALDITO 1.5");
            string sudoku = @"1 3 2 5 7 9 4 6 8
                              4 9 8 2 6 1 3 7 5
                              7 5 6 3 8 4 2 1 9
                              6 4 3 1 5 8 7 9 2
                              5 2 1 7 9 3 8 4 6
                              9 8 7 4 2 6 5 3 1
                              2 1 4 9 3 5 6 8 7
                              3 6 5 8 1 7 9 2 4
                              8 7 9 6 4 2 1 5 3";

            { string sPattern = "^\\{>9}$";

                foreach (string s in soduko)
                {
                    Console.Write($"{s}");

                    if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern))
                    {
                        Console.WriteLine("sim");
                    }
                    else
                    {
                        Console.WriteLine(" NAO ");
                    }
                }
            }
            private static int[,] ConverterStringParaMatriz(string sudoku)
            {
                int[,] sudokuMatriz = new int[9, 9];

                sudoku = sudoku.Replace("\n", " ");
                string[] numeros = sudoku.Split(" ");

                int count = 0;

                for (int X = 0; X < 9; X++)
                {
                    for (int Y = 0; Y < 9; Y++)
                    {
                        sudokuMatriz[X, Y] = Convert.ToInt32(numeros[count]);
                        count++;
                    }
                }

                return sudokuMatriz;
            }

            private static bool TemRepetição(int[] array)
            {
                Hashtable table = new Hashtable();

                foreach (int X in array)
                {
                    if (table.Contains(X))
                        return true;
                    else
                        table.Add(X, X);
                }

                return false;
            }

            private static int[] PegarBlocoArray(int posicaoBlocoY, int posicaoBlocoX, int[,] sudoku)
            {
                int offsetY = (posicaoBlocoY * 3);
                int offsetX = (posicaoBlocoX * 3);

                int[] bloco = new int[9];
                int blocoCount = 0;

                for (int X = offsetY; X < offsetX + 3; X++)
                {
                    for (int Y = offsetY; Y < offsetX + 3; Y++)
                    {
                        bloco[blocoCount] = sudoku[X, Y];
                        blocoCount++;
                    }
                }

                return bloco;
            }

            private static bool VerificarBlocos(int[,] sudoku)
            {
                for (int posicaoBlocY = 0; posicaoBlocoY < 3; posicaoBlocoY++)
                {
                    for (int posicaoBlocoX = 0; posicaoBlocoX < 3; posicaoBlocoX++)
                    {
                        int[] bloco = PegarBlocoArray(posicaoBlocoY, posicaoBlocoX, sudoku);

                        if (TemRepetição(bloco))
                            return false;
                    }
                }

                return true;
            }

            private static int[] LinhaArray(int Y, int[,] sudoku)
            {
                int[] linha = new int[9];
                int linhaCount = 0;

                for (int Y = 0; Y < 9; Y++)
                {
                    linha[linhaCount] = sudoku[Y , X];
                    linhaCount++;
                }

                return linha;
            }

            private static bool VerificarLinhas(int[,] sudoku)
            {
                for (int X = 0; X < 9; X++)
                {
                    int[] linha = LinhaArray(X, sudoku);

                    if (TemRepetição(linha))
                        return false;
                }

                return true;
            }

            private static int[] ColunasArray(int Y, int[,] sudoku)
            {
                int[] coluna = new int[9];
                int colunaCount = 0;

                for (int Y = 0; Y < 9; Y++)
                {
                    coluna[colunaCount] = sudoku[X, Y];
                    colunaCount++;
                }

                return coluna;
            }

            private static bool VerificarColunas(int[,] sudoku)
            {
                for (int Y = 0; Y < 9; Y++)
                {
                    int[] coluna = ColunasArray(Y, sudoku);

                    if (TemRepetição(coluna))
                        return false;
                }

                return true;

            }
        }
    }
}
 

