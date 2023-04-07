using System;
using System.Xml.Serialization;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ver = Console.ReadLine();
            if (ver == "1")
            {
                Console.WriteLine("input text");
                string message = Console.ReadLine();
                Console.WriteLine("input binary");
                string binary = Console.ReadLine();

                binary = binary.Replace(" ", "");
                string fin_msg = "";
                var C_binary = binary.ToCharArray();
                var C_msg = message.ToCharArray();

                int i = 0;
                int space = 0;
                while (i <= C_binary.Length - 1)
                {
                    /*
                    if (C_binary == null)
                    {
                        int j = i;
                        while(j <= C_msg.Length)
                        {
                            fin_msg = C_msg[j].ToString();
                            j++;
                        }
                        Console.WriteLine(fin_msg);
                        break;
                    }
                    */
                    if (space == 8)
                    {
                        fin_msg = fin_msg + ",";
                        space = 0;
                    }
                    space++;
                    if (C_binary[i].ToString() == "0")
                    {
                        if (C_msg[i].ToString() == " ")
                        {
                            fin_msg = fin_msg + "_";
                        }
                        else
                        {
                            fin_msg = fin_msg + C_msg[i].ToString().ToLower();
                        }

                    }
                    if (C_binary[i].ToString() == "1")
                    {
                        if (C_msg[i].ToString() == " ")
                        {
                            fin_msg = fin_msg + "-";
                        }
                        else
                        {
                            fin_msg = fin_msg + C_msg[i].ToString().ToUpper();
                        }

                    }
                    i++;
                }
                int j = i;
                fin_msg = fin_msg + " // ";
                while (j <= C_msg.Length - 1)
                {
                    fin_msg = fin_msg + C_msg[j].ToString();
                    j++;
                }

                Console.WriteLine(fin_msg);
            }
            else
            {
                Console.WriteLine("input text");
                string message = Console.ReadLine();
                var C_msg = message.ToCharArray();
                int i = 0;
                int space = 0;
                string fin_msg = "";
                while (C_msg.Length >= i+1)
                {
                    /*
                    if(space==8) {
                        fin_msg = fin_msg + " ";
                        space = 0;
                    }
                    space++;
                    */

                    if (C_msg[i].ToString() == ",")
                    {
                        fin_msg = fin_msg + " ";
                    }
                    if (C_msg[i].ToString() == "_")
                    {
                        fin_msg = fin_msg + "0";
                    }
                    if (C_msg[i].ToString() == "-")
                    {
                        fin_msg = fin_msg + "1";
                    }
                    if (char.IsLetter(C_msg[i]))
                    {
                        if (char.IsUpper(C_msg[i]) == true)
                        {
                            fin_msg = fin_msg + "1";
                        }
                        if (char.IsLower(C_msg[i]) == true)
                        {
                            fin_msg = fin_msg + "0";
                        }
                    }
                    i++;
                }
                Console.WriteLine(fin_msg);
            }
        }
    }
}