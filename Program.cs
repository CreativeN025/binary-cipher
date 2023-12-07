using System.Text;
using System.Diagnostics;

namespace MyApp 
{
  
    internal class Program
    {
     
        [STAThreadAttribute]
        static void Main(string[] args)
        {
            string ver = getconsoleinput("input 1 if you want to create an encrypted message and press 2 if you want to decrypt");
            if (ver == "1")
            {
                string message = getconsoleinput("Input text");
                string binary = getconsoleinput("Input binary");

                binary = binary.Replace(" ", "");
                string fin_msg = "";
                char[] C_binary = binary.ToCharArray();
                char[] C_msg = message.ToCharArray();

                int i = 0;
                int space = 0;
                while (i <= C_binary.Length - 1)
                {
                    if (space == 8)
                    {
                        fin_msg = fin_msg + ",";
                        space = 0;
                    }
                    space++;
             
                    fin_msg = fin_msg+ checkstring(C_binary[i], C_msg[i],fin_msg,"0","_").ToLower();
                    fin_msg = fin_msg+ checkstring(C_binary[i], C_msg[i],fin_msg,"1","-").ToUpper();
                  
                    i++;
                }
                
                fin_msg = fin_msg + " // ";
                while (i < C_msg.Length)
                {
                    fin_msg = fin_msg + C_msg[i].ToString();
                    i++;
                }

                Console.WriteLine(fin_msg);
                SetClipboard(fin_msg); 
            }
            else
            {
                string message = getconsoleinput("input text");
                var C_msg = message.ToCharArray();
                int i = 0;
                string fin_msg = "";
                bool stopread=false;
                while (C_msg.Length >= i+1&&!stopread)
                {
                    
                    
                    switch (C_msg[i])
                    {
                        case ',':
                            fin_msg = fin_msg + "";
                            break;
                        case '_':
                            fin_msg = fin_msg + "0";
                            break;
                        case '-':
                            fin_msg = fin_msg + "1";
                            break;
                        case '/':
                            stopread= true;
                            break;

                    }
                   
                    
                    if (char.IsLetter(C_msg[i]))
                    {
                        if (char.IsUpper(C_msg[i]) == true)
                        {
                            fin_msg = fin_msg + "1";
                        }
                        else if (char.IsLower(C_msg[i]) == true)
                        {
                            fin_msg = fin_msg + "0";
                        }
                    }

                    i++;
                }
                Console.WriteLine(fin_msg);
                Byte[] GetBytesFromBinaryString(String binary)
                {
                    var list = new List<Byte>();

                    for (int i = 0; i < binary.Length; i += 8)
                    {
                        String t = binary.Substring(i, 8);

                        list.Add(Convert.ToByte(t, 2));
                    }

                    return list.ToArray();
                }
            
            var data = GetBytesFromBinaryString(fin_msg);
                var text = Encoding.ASCII.GetString(data);
                Console.WriteLine(text);
                SetClipboard(text);
            }

        }
        static string getconsoleinput(string write)
        {
            Console.WriteLine(write);
            return Console.ReadLine();
        }
        static string checkstring(char C_binary, char C_msg,string fin_msg,string checkchar,string replacechar)
        {
            if (C_binary.ToString() == checkchar)
            {
                if (C_msg.ToString() == " ")
                {
                    return replacechar;
                }
                else
                {
                    return  C_msg.ToString();
                }

            }
            else { return ""; }
        }
        public static void SetClipboard(string value)
        {
            if (value == null)
                throw new ArgumentNullException("Attempt to set clipboard with null");

            Process clipboardExecutable = new Process();
            clipboardExecutable.StartInfo = new ProcessStartInfo // Creates the process
            {
                RedirectStandardInput = true,
                FileName = @"clip",
            };
            clipboardExecutable.Start();

            clipboardExecutable.StandardInput.Write(value); // CLIP uses STDIN as input.
                                                            // When we are done writing all the string, close it so clip doesn't wait and get stuck
            clipboardExecutable.StandardInput.Close();

            return;
        }

    }
}
        