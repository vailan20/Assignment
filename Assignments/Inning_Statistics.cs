using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Assignments
{
    class Score_PreviousMatch
    {
        ArrayList scores { get; set; }
        int[,] run { get; set; }
        int match, over;
        internal void GetScores()
        {
            int match = 5, over = 5;
            int[,] run = new int[match, over * 6];
            for (int i = 0; i < match; i++)
            {
                for (int j = 0; j < over * 6; j++)
                {
                    Random rn = new Random();
                    int num = rn.Next(0, 7);
                    run[i, j] = num;
                }
            }
            this.run = run;
            this.match = match;
            this.over = over;
        }
        internal void AverageScoreLast5()
        {
            int sum = 0;
            float average;

            for (int i = 0; i < match; i++)
            {
                for (int j = 0; j < over * 6; j++)
                {
                    sum = sum + run[i, j];
                }
            }
            average = sum / match;
            Console.WriteLine("Total runs: {0}", sum);
            Console.WriteLine("Average of 5 matches: {0}", average);
        }
        internal void CountRuns5()
        {
            int count0 = 0, count1 = 0, count2 = 0, count3 = 0, count4 = 0, count5 = 0, count6 = 0;
            for (int i = 0; i < match; i++)
            {
                for (int j = 0; j < over * 6; j++)
                {
                    if (run[i, j] == 0) count0++;
                    else if (run[i, j] == 1) count1++;
                    else if (run[i, j] == 2) count2++;
                    else if (run[i, j] == 3) count3++;
                    else if (run[i, j] == 4) count4++;
                    else if (run[i, j] == 5) count5++;
                    else if (run[i, j] == 6) count6++;
                }
            }
            Console.WriteLine("\n0 Runs: {0} times \n1 Runs: {1} times \n2 Runs: {2} times \n3 Runs: {3} times \n4 Runs: {4} times \n5 Runs: {5} times \n6 Runs: {6} times", count0, count1, count2, count3, count4, count5, count6);
        }
        internal void StrikeRate5()
        {
            int sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, sum5 = 0;
            float averagestrikerate;
            for (int j = 0; j < over * 6; j++)
            {
                sum1 = sum1 + run[0, j];
            }
            for (int j = 0; j < over * 6; j++)
            {
                sum2 = sum2 + run[1, j];
            }
            for (int j = 0; j < over * 6; j++)
            {
                sum3 = sum3 + run[2, j];
            }
            for (int j = 0; j < over * 6; j++)
            {
                sum4 = sum4 + run[3, j];
            }
            for (int j = 0; j < over * 6; j++)
            {
                sum5 = sum5 + run[4, j];
            }
            averagestrikerate = ((sum1 / 30) + (sum2 / 30) + (sum3 / 30) + (sum4 / 30) + (sum5 / 30)) / 5;
            Console.WriteLine("\nAverage Strike Rate: {0}", averagestrikerate);
        }
    }

    class Inning_Statistics
    {
        ArrayList runs { get; set; }
        int TotalRuns { get; set; }
        Inning_Statistics(ArrayList runs)
        {
            this.runs = runs;
        }
        void DisplayRuns()
        {
            Console.Write("Runs\n");
            foreach (int run in runs)
            {
                Console.Write(run.ToString() + ", ");
            }
        }
        void TotalRunsSum()
        {
            int TotalRuns = 0;
            foreach (int run in runs)
            {
                TotalRuns = TotalRuns + run;
            }
            Console.WriteLine("\n\nTotal Runs: {0}", TotalRuns);
            this.TotalRuns = TotalRuns;
        }
        void CountRuns()
        {
            int count0 = 0, count1 = 0, count2 = 0, count3 = 0, count4 = 0, count5 = 0, count6 = 0;
            foreach (int run in runs)
            {
                if (run == 0) count0++;
                else if (run == 1) count1++;
                else if (run == 2) count2++;
                else if (run == 3) count3++;
                else if (run == 4) count4++;
                else if (run == 5) count5++;
                else if (run == 6) count6++;
            }
            Console.WriteLine("\n0 Runs: {0} times \n1 Runs: {1} times \n2 Runs: {2} times \n3 Runs: {3} times \n4 Runs: {4} times \n5 Runs: {5} times \n6 Runs: {6} times", count0, count1, count2, count3, count4, count5, count6);
        }
        void StrikeRate()
        {
            double Rate;
            int Count = runs.Count;
            Rate = Convert.ToDouble(TotalRuns / Count);
            Console.WriteLine("\nStrike rate: {0}", Rate);
        }
        static void Main()
        {
            int overs = 5;
            Random rn = new Random();
            ArrayList runs = new ArrayList();
            for (int i = 0; i < overs * 6; i++)
            {
                int num = rn.Next(0, 7);
                runs.Add(num);
            }
            Inning_Statistics inst = new Inning_Statistics(runs);
            inst.DisplayRuns();
            inst.TotalRunsSum();
            inst.CountRuns();
            inst.StrikeRate();

            Console.WriteLine("\n------------------------------------\n");

            Score_PreviousMatch spm = new Score_PreviousMatch();
            spm.GetScores();
            spm.AverageScoreLast5();
            spm.CountRuns5();
            spm.StrikeRate5();
        }
    }
}
