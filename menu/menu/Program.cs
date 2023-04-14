using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using menu.BL;

namespace menu
{
   public class Program
    {
        //%%%%%%%%%%% Main %%%%%%%%%%%%
        static void Main(string[] args)
        {
            string path = "D:\\C#\\week2\\pd\\menu\\member.txt";
            List<Member> add = new List<Member>();
            List<records> check = new List<records>();
            loadfromfile(path,add);
            int option = menu();
            if(option ==1)
                {
                addmember(add);
            }
            if(option ==2)
            {
                checkRecords(check);
            }
            if(option ==3)
            {
                string member;
                Console.WriteLine("Enter member name");
                member = Console.ReadLine();
                deletemembership(member);
            }
            if(option == 4)
            {
                Console.WriteLine("press any key to exit");
            }
            Console.ReadKey();
        }
        //%%%%%%%%%%%%%% ADMIN MENU %%%%%%%%%%%%%%%%%%%%%%%%%
        static int menu()
        {
            Console.Clear();
            int option;
            Console.WriteLine("Press1.add members");
            Console.WriteLine("Press2.TO check Records");
            Console.WriteLine("Press3.To delete members");
            option = int.Parse(Console.ReadLine());
            return option;
        }

        //%%%%%%%%%%%%%%%%%% ADD MEMBER %%%%%%%%%%%%%%%%%%%%
        static void addmember(List<Member>add)
        {
           
            Member temp = new Member();
            Console.Clear();
            Console.WriteLine("%%%%%%%% Add Member %%%%%%%%%");
            Console.WriteLine("Enter member name:");
            temp.name = Console.ReadLine();
            Console.WriteLine("Enter member address:");
            temp.addresses = Console.ReadLine();
            Console.WriteLine("Enter id:");
            temp.id = Console.ReadLine();
            Console.WriteLine("Member has been added successfully");
            storeinfile(temp);
            add.Add(temp);
        }
        //%%%%%%%%%%%% WRITE IN FILE %%%%%%%%%%%%%%%%%%
        static void storeinfile(Member temp)
        {
            string path = "D:\\C#\\week2\\pd\\menu\\member.txt";
            StreamWriter filevariable = new StreamWriter(path, true);
            filevariable.WriteLine(temp.name + temp.addresses + temp.id);
            filevariable.Flush();
            filevariable.Close();
        }
        //%%%%%%%%%%%%%% READ FROM FILE %%%%%%%%%%%%%%%%%
        static void loadfromfile(string path,List<Member>add)
        {
             path = "D:\\C#\\week2\\pd\\menu\\member.txt";
            if(File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null) ;
                {
                    Member info = new Member();
                    info.name = parseData(record, 1);
                    info.addresses = parseData(record, 2);
                    info.id = parseData(record, 3);
                    add.Add(info);
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        }
        // %%%%%%%%%%%%%%%%%%% PARSE DATA %%%%%%%%%%%%%%%%%%%%
        static string parseData(string record,int field)
        {
            int comma = 1;
            string item = "";
            for(int x =0; x<record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if(comma == field)
                    {
                    item = item + record[x];
                }
            }
            return item;
        }
        //%%%%%%%%%%%%%%%%%% CHECK RECORDS %%%%%%%%%%%%%%%%%%%
        static void checkRecords(List<records>check)
        {
            records temp = new records();
            Console.Clear();
            string name1;
            Console.WriteLine("Enter name:");
            name1 = Console.ReadLine();
            for(int index =0; index<check.Count; index++)
            {
                if(name1 == check[index].name)
                {
                    Console.WriteLine("The member is found successfully");
                    Console.WriteLine(check[index].name+ check[index].addresses+check[index].id);
                }
                else
                {
                    Console.WriteLine("The member is not found successfully");
                }

            }
            Console.ReadKey();
            Console.WriteLine("press any key to continue......");

        }
        //%%%%%%%%%%%%%%%%% DELETE MEMBERSHIP %%%%%%%%%%%%%%%%%%%%
        static void deletemembership(string member)
        {
            
            string path = "D:\\C#\\week2\\pd\\menu\\member.txt";
            List<string> lines = File.ReadAllLines(path).ToList();
            bool memberFound = false;
            for(int i =0; i<lines.Count; i++)
            {
                string[] fields = lines[i].Split(',');

                if (fields[0] == member)
                {
                    lines.RemoveAt(i);
                    memberFound = true;
                    break;
                }
            }
            if(memberFound)
            {
                File.WriteAllLines(path, lines);
                Console.WriteLine("Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Deletion Error");
            }
            Console.ReadKey();

        }
        

    }
}
