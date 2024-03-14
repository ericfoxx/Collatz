using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collatz.Utilities
{
    public static class Display
    {
        /// <summary>
        /// Displays the result of a single run on the command line
        /// </summary>
        /// <param name="result">A RunResult object containing the run information</param>
        public static void ConsoleSingleResult(RunResult result)
        {
            Console.WriteLine($"Collatz of {result.InitialValue} with {result.Steps} steps and max {result.Max}:");
            Console.Write(result.InitialValue);
            result.Values.Skip(1).ToList().ForEach(x => Console.Write($"\t{x}"));
            Console.WriteLine();
        }

        /// <summary>
        /// Generates
        /// </summary>
        /// <param name="result"></param>
        /// <param name="dirPath"></param>
        public static void GenerateImageFromSingleResult(RunResult result, string dirPath)
        {

        }

        /// <summary>
        /// Opens a generated image of a single result run
        /// </summary>
        /// <remarks>
        /// Run a GenerateImage... method first
        /// </remarks>
        /// <param name="result">A RunResult object containing the run information</param>
        /// <param name="filePath">Either an absolute or relative path to a generated file</param>
        public static void OpenImageFromSingleResult(RunResult result, string filePath)
        {
            //determine path legality
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File {filePath} does not exist.");
            }

            Process.Start("cmd", $"/c {filePath}");
        }
    }
}
