using System;
using System.Collections.Generic;
using System.Net;

namespace KahootHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                
                int currentint = 0;
                int currentquestion = 1;
                int questiontype = 2;
                string randomtemp = "";
                string[] temparray;
               // string[] temparraytwo;
                string[] goodstrings;
                string[] allstring;
                string link;
                string newlink;
                string roomid;
               
                List<int> curanswers = new List<int>();
                List<string> curanswersstring = new List<string>();
                List<string[]> allanswerslist = new List<string[]>();
                WebClient Client;
                try
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("");
                    Console.WriteLine("Put kahoot link or host id for normal rooms and the link for static games: ");


                    link = Console.ReadLine();



                    if (link.Contains("challenge-id="))
                    {
                        roomid = link.Split("challenge-id=")[1];

                        newlink = @"https://kahoot.it/rest/challenges/" + roomid + @"/answers";
                        Client = new WebClient();

                        allstring = Client.DownloadString(newlink).Split(",\"brainstorming\":[],");
                        goodstrings = allstring[allstring.Length - 1].Split(',');
                        //   normalroom = false;
                    }
                    else if (link.Contains("quizId="))
                    {
                        roomid = link.Split("quizId=")[1];


                        newlink = @"https://play.kahoot.it/rest/kahoots/" + roomid;
                        Client = new WebClient();
                        goodstrings = Client.DownloadString(newlink).Split(',');

                        //   normalroom = true;
                    }
                    else
                    {
                        roomid = link;


                        newlink = @"https://play.kahoot.it/rest/kahoots/" + roomid;
                        Client = new WebClient();
                        goodstrings = Client.DownloadString(newlink).Split(',');

                        //    normalroom = true;
                    }


                    //  allstring = Client.DownloadString(newlink).Split(',');




                    /*  switch (normalroom)
                      {
                          case false:
                                  allstring = Client.DownloadString(newlink).Split(",\"brainstorming\":[],");
                                  goodstrings = allstring[allstring.Length - 1].Split(',');



                              Console.ForegroundColor = ConsoleColor.Green;
                              foreach (string curthing in goodstrings)
                              {
                                  if (curthing.Contains("\"correct\":false"))
                                  {
                                      Console.WriteLine(curthing);
                                      currentint++;
                                      //   totalthings++;
                                  }
                                  else if (curthing.Contains("\"correct\":true"))
                                  {
                                      Console.WriteLine(curthing);

                                         // if (allanswerslist[currentquestion] == null)
                                      //    {
                                             // allanswerslist.Add(new int[] { currentquestion, currentint + 1 });
                                              curanswers.Add(currentint + 1);
                                      //    }
                                    //      else if (allanswerslist[currentquestion] != null)
                                     //     {
                                            //  allanswerslist.Add(currentquestion, (currentint + 1));
                                    //      }
                                     // foundcur = true;
                                      //   currentint = 0;
                                      //     totalthings++;
                                  }
                                  if (curthing.Contains("\"correct\"") && curthing.Contains(']'))
                                  {
                                          temparray = new int[curanswers.Count + 1];
                                          temparray[0] = currentquestion;
                                          for(int tempe = 0; curanswers.Count > tempe; tempe++)
                                          {
                                              temparray[tempe+ 1] = curanswers[tempe];
                                          }
                                          allanswerslist.Add(temparray);
                                          //    foundcur = false;
                                          curanswers.Clear();
                                          currentint = 0;
                                          currentquestion++;
                                  }
                                  //          }
                              }
                              break;
                          case true:


      */

                    //allstring = Client.DownloadString(newlink).Split(",\"brainstorming\":[],");
                    // goodstrings = Client.DownloadString(newlink).Split(',');



                   
                    foreach (string curthing in goodstrings)
                    {
                        if (curthing.Contains("{\"type\":\"content\""))
                        {
                            allanswerslist.Add(new string[] { currentquestion.ToString(), "not question" });
                            questiontype = 2;
                            currentquestion++;
                        }
                        else if (curthing.Contains("{\"type\":\"quiz\"")) 
                        {
                            questiontype = 0;
                        }
                        else if (curthing.Contains("{\"type\":\"open_ended\""))
                        {
                            questiontype = 1;
                        }
                        else if (curthing.Contains("{\"type\":\"multiple_select_quiz\""))
                        {
                            questiontype = 3;
                        }
                        else if (curthing.Contains("{\"type\":\"survey\""))
                        {
                            questiontype = 4;
                        }
                        if (questiontype != 2)
                        {
                            switch (questiontype)
                            {
                                case 0:
                                case 3:
                                case 4:
                                    if (curthing.Contains("\"correct\":false"))
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine(curthing);
                                        currentint++;
                                        //   totalthings++;
                                    }
                                    else if (curthing.Contains("\"correct\":true"))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.WriteLine(curthing);

                                        // if (allanswerslist[currentquestion] == null)
                                        //    {
                                        // allanswerslist.Add(new int[] { currentquestion, currentint + 1 });
                                        currentint++;
                                        curanswers.Add(currentint);
                                        //    }
                                        //      else if (allanswerslist[currentquestion] != null)
                                        //     {
                                        //  allanswerslist.Add(currentquestion, (currentint + 1));
                                        //      }
                                        // foundcur = true;
                                        //   currentint = 0;
                                        //     totalthings++;
                                    }
                                    if (curthing.Contains("\"correct\"") && curthing.Contains(']'))
                                    {

                                        temparray = new string[curanswers.Count + 1];
                                        if (questiontype == 0)
                                            temparray[0] = currentquestion.ToString();
                                        else if (questiontype == 3)
                                            temparray[0] = currentquestion.ToString() + "must choose all";
                                        else if (questiontype == 4)
                                            temparray[0] = currentquestion.ToString() + "any works";
                                        for (int tempe = 0; curanswers.Count > tempe; tempe++)
                                        {
                                          
                                            temparray[tempe + 1] = curanswers[tempe].ToString();
                                         
                                        }
                                       

                                        allanswerslist.Add(temparray);
                                        //    foundcur = false;
                                        curanswers.Clear();
                                        currentint = 0;
                                        currentquestion++;
                                        questiontype = 2;
                                    }

                                    break;
                                case 1:

                                    if(curthing.Contains("\"correct\":true}]"))
                                    {
                                        temparray = new string[curanswersstring.Count + 1];
                                        temparray[0] = currentquestion.ToString();
                                        for (int tempe = 0; curanswersstring.Count > tempe; tempe++)
                                        {
                                            temparray[tempe + 1] = curanswersstring[tempe];
                                        }
                                        allanswerslist.Add(temparray);
                                        questiontype = 2;
                                        currentquestion++;
                                        curanswersstring.Clear();
                                    }
                                    if (curthing.Contains("{\"answer\":"))
                                    {
                                        temparray = curthing.Split('"');
                                        curanswersstring.Add(temparray[temparray.Length - 2]);
                                        Console.WriteLine(temparray);
                                    }



                                    break;
                            }
                        }
                    }







                    //    break;
                    //    }










                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("ANSWERS: ");
                for(int curanswer = 0; allanswerslist.Count > curanswer; curanswer++)
                {
                        randomtemp += "Q" + allanswerslist[curanswer][0] + "= ";
                        for (int curquestionanswers = 1; allanswerslist[curanswer].Length > curquestionanswers; curquestionanswers++)
                        {
                            randomtemp += allanswerslist[curanswer][curquestionanswers].ToString() + " ";
                           
                        }
                        Console.WriteLine(randomtemp);
                        randomtemp = "";
                }
               









                }
                catch(Exception ex)
                {
                //    allstring = null;
                
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Error somewhere, maybe invalid link or something, maybe typo on id or whatever");
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(ex.Message);
                }
                Console.ReadKey();
            }
        }
    }
}
