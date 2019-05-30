using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FullNameSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            string strError = "";
            string[] names;
            //string[] names = GetSplitNames("Aauvince Marc,Marie Kane B", ref strError);
            // string[] names = GetSplitNames("Mountbatten-Windsor, Archie Harrison", ref strError);
            // string[] names = GetSplitNames("Jonshon, Marry Ann Sue Butler", ref strError);
            //string[] names = GetSplitNames("Marry Ann Sue Butler", ref strError);
            string strFullName;
            do
            {
                Console.WriteLine("Enter Full Name (Type exit to close program): ");
                strFullName = Console.ReadLine();
                names = GetSplitNames(strFullName, ref strError);
                Console.WriteLine("First Name:" + names[0]);
                Console.WriteLine("Middle Name:" + names[1]);
                Console.WriteLine("Last Name:" + names[2]);
                Console.WriteLine("Error if any: " + strError);

            } while (strFullName != "exit");

            // string[] names = GetSplitNames("Williams,Valerie L", ref strError);


            //Console.WriteLine("First Name:" + names[0]);
            // Console.WriteLine("Middle Name:" +names[1]);
            // Console.WriteLine("Last Name:" + names[2]);
            // Console.WriteLine("Error if any: " + strError);
            // Console.ReadLine();
        }

        public static string[] GetSplitNames(string strFullName, ref string strError)
        {
            //Returns as FirstName, MiddleName, LastName
            //strErrorCode: NO-NAME - empty name, ONE-WORD - Only one word, MORE-THAN-FOUR - More than 4 words, Else Error message
            if (strFullName.Trim() == "")
            {
                strFullName = "NO-NAME";
                return null;
            }
            string[] strNames = new string[3];
            //If Comman is there - LastName, FirstName
            Regex regularEx = new Regex(@",");
            if (regularEx.IsMatch(strFullName.Trim()))
            {
                string[] strTemp = strFullName.Trim().Split(',');
                //First part before comma , is the Last Name
                strNames[2] = strTemp[0].Trim();   //Last Name
                                                   //Split 2nd part for fist name and last name
                string[] strTemp2 = strTemp[1].Trim().Split(' ');  //Split by space
                switch (strTemp2.Length)
                {
                    case (0):
                        strNames[0] = "";   //first Name
                        strNames[1] = "";   //Middle Name
                        strError = "NO-FIRST-NAME";
                        break;
                    case (1):
                        strNames[0] = strTemp2[0].Trim();
                        strNames[1] = "";
                        strError = "";
                        break;
                    case (2):
                        strNames[0] = strTemp2[0].Trim();
                        strNames[1] = strTemp2[1].Trim();
                        strError = "";
                        break;
                    case (3):
                        strNames[0] = strTemp2[0].Trim() + " " + strTemp2[1].Trim();
                        strNames[1] = strTemp2[2].Trim();
                        strError = "";
                        break;
                    case (4):
                        strNames[0] = strTemp2[0].Trim() + " " + strTemp2[1].Trim() + " " + strTemp2[2].Trim();
                        strNames[1] = strTemp2[3].Trim();
                        break;
                    default:
                        strError = "MORE-THAN-FOUR";
                        break;
                }
            }
            else
            {
                //IF no comma and only with spaces
                string[] strTemp2 = strFullName.Trim().Split(' ');  //Split by space

                switch (strTemp2.Length)
                {
                    case (0):   //This case never happened
                        strNames[0] = "";   //first Name
                        strNames[1] = "";   //Middle Name
                        strNames[1] = "";   //Last Name
                        strError = "NO-NAME";
                        break;
                    case (1):
                        strNames[0] = strTemp2[0].Trim();
                        strNames[1] = "";
                        strNames[2] = "";
                        strError = "NO-LAST-MIDDLE-NAME";
                        break;
                    case (2):
                        strNames[0] = strTemp2[0].Trim();
                        strNames[1] = "";
                        strNames[2] = strTemp2[1].Trim();
                        strError = "";
                        break;
                    case (3):
                        strNames[0] = strTemp2[0].Trim();
                        strNames[1] = strTemp2[1].Trim();
                        strNames[2] = strTemp2[2].Trim();
                        strError = "";
                        break;
                    case (4):
                        strNames[0] = strTemp2[0].Trim() + " " + strTemp2[1].Trim();
                        strNames[1] = strTemp2[2].Trim();
                        strNames[2] = strTemp2[3].Trim();
                        strError = "";
                        break;
                    default:
                        strError = "MORE-THAN-FOUR";
                        break;
                }

            }
            return strNames;
        }
    }
}
