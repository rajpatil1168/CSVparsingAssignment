using System;
using System.Collections.Generic;

namespace CsvParsingAssignment
{
    class Global
    {
        public static int blankLinesCounter=0;
        public static int blankLinesCounter1 = 0;
        public static List<int> noCount = new List<int>();
    }
    class CsvParsingHelper
    {
        public static void IsSucecssfunction(bool issucess)
        {

            if (issucess)
                Console.WriteLine("PROGRAM SUCCESSFULLY EXECUTED\n\n");
            else
                Console.WriteLine("\n PROGRAM NOT* SUCCESSFULLY EXECUTED\n\n");

        }

        public static List<String> CheckAcceptedCsvLines(string[] csvLines)
        {
            List<String> acceptedCsvLinesfun = new List<String>();
            foreach (string line in csvLines)
                    {                     
                        string[] data = line.Split(',');
                        Global.blankLinesCounter++;
                        bool isAppend = false;
                        bool isAppend1=true;                
                        for (int i=0;i<data.Length;i++)
                        {
                            string first = Convert.ToString(data[0]);
                            if (Convert.ToString(data[i]) != first)
                            {
                                isAppend1=false;
                                break;
                            }                    
                        }
                        if(isAppend1 == true)
                        {
                            Console.WriteLine("{0}th Line of CSV FILE is blank line ", Global.blankLinesCounter);
                        }


                        foreach (string word in data )
                        {
                                if (Convert.ToString(word) != string.Empty )
                                    {
                                        isAppend = true;                                
                                    }
                                    else
                                    {
                                        isAppend = false;
                                        break;
                                    }
                                }
                                if (isAppend == true)
                                {
                                    acceptedCsvLinesfun.Add(line);
                                    Global.noCount.Add(Global.blankLinesCounter);
                                 }
                                else if(isAppend1==false)
                                {
                                    Console.WriteLine("{0}th Line of CSV FILE is  contain missing some values", Global.blankLinesCounter);
                                }
                        }            
            return acceptedCsvLinesfun;
        }
    }
//out pass--> ref 
    /// <summary>
    /// This class converts String of strings to respective object.
    /// </summary>
    public class IPL
    {
        public int id;
        public string season;
        public string city;
        public string date;
        public string team1;
        public string team2;
        public string toss_winner;
        public string toss_decision;
        public string result;
        public int dl_applied;
        public string winner;
        public int win_by_runs;
        public int win_by_wickets;
        public string player_of_match;
        public string venue;
        public string umpire1;
        public string umpire2;

        public IPL IPL_parse(string rowDATA,int exceptionIncrementVariable)
        {            
            string[] data = rowDATA.Split(',');
            int number_of_coloumn = data.Length;

            try
            {
                //parse data into property
                if (data.Length == number_of_coloumn)
                {
                    this.id = Convert.ToInt32(data[0]);
                    this.season = data[1];
                    this.city = data[2];
                    this.date = data[3];
                    this.team1 = data[4];
                    this.team2 = data[5];
                    this.toss_winner = data[6];
                    this.toss_decision = data[7];
                    this.result = data[8];
                    this.dl_applied = Convert.ToInt32(data[9]);
                    this.winner = data[10];
                    this.win_by_runs = Convert.ToInt32(data[11]);
                    this.win_by_wickets = Convert.ToInt32(data[12]);
                    this.player_of_match = data[13];
                    this.venue = data[14];
                    this.umpire1 = data[15];
                    this.umpire2 = data[16];
                    return this;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Parsing string have less or more records than total number of coloumn");
                    Console.WriteLine(data.Length);
                    return null;
                }
            }
            catch (System.FormatException)
            {
                
                Console.WriteLine("{0}th Line in CSV is currputed *,where input is not in proper format**.", Global.noCount[ exceptionIncrementVariable]);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine(data.Length);
                Console.WriteLine();
                Console.WriteLine();
                return null;
            }
        }
    }
}
