using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConsoleApplication15
{
       
    class Program
    {
    string []att=new string[5];
   public void Search(string []id, string []name, string []smster, double []cgpa, string []dep, string []uni,ref int size)
   {
	int choice,found = 0;
    string id1, str1, choice1;
	do
	{
        Console.WriteLine("Press 1 search by ID");
        Console.WriteLine("Press 2 search by Name");
        Console.WriteLine("Press 3 for see list of students");
        Console.WriteLine("Press 4 for Exit");
        choice1=Console.ReadLine();
        choice = Convert.ToInt32(choice1);
		switch (choice)
		{
		case 1:
               
                Console.WriteLine("Press 1 search by ID");
                id1 = Console.ReadLine();
                Console.WriteLine("ID" + "\t" + "Name"+"\t\t" + "Smester"+"\t" + "CGPA" + "\t" + "Dept"+"\t"+"Uni");
			for (int i = 0; i < size; i++)
			{

				if (id[i] == id1)
				{
                    Console.WriteLine(id[i] + "\t" + name[i] + "\t" + smster[i] + "\t" + cgpa[i] + "\t" + dep[i] + "\t" + uni[i]);	
					found = 1;
				}
				
			}
			if (found == 0)
			{
                Console.WriteLine("Record Not Found");
			}
			found = 0;
			break;
		case 2:
            Console.WriteLine("Enter Student Name:");
            str1 = Console.ReadLine();
            Console.WriteLine("ID" + "\t" + "Name" + "\t\t" + "Smester" + "\t" + "CGPA" + "\t" + "Dept" + "\t" + "Uni");
			for (int i = 0; i < size; i++)
			{
				if (name[i] == str1)
				{
                    Console.WriteLine(id[i] + "\t" + name[i] + "\t" + smster[i] + "\t" + cgpa[i] + "\t" + dep[i] + "\t" + uni[i]);	

					
					found = 1;
				}

			}
			if (found == 0)
			{
                Console.WriteLine("Record Not Found");
			}
			found = 0;
			break;
		case 3:
            Console.WriteLine("ID" + "\t" + "Name" + "\t\t" + "Smester" + "\t" + "CGPA" + "\t" + "Dept" + "\t" + "Uni");
			for (int i = 0; i < size; i++)
			{
                Console.WriteLine(id[i] + "\t" + name[i] + "\t" + smster[i] + "\t" + cgpa[i] + "\t" + dep[i] + "\t" + uni[i]);	
			}
			break;
		case 4:
			break;
		}
	} while (choice != 4);

}
   public void Heighest(string[] id, string[] name, string[] smster, double[] cgpa, string[] dep, string[] uni, ref int size)
{
	double max0, temp0;
	string max1, max2, max3, max4, max5;
	string temp1, temp2, temp3, temp4, temp5;
	int count2 = 0;
	for (int i = 0; i <size; i++)
	{
	  max0 = cgpa[i];
	  max1 = id[i];
	  max2 = name[i];
	  max3 = smster[i];
	  max4 = dep[i];
	  max5 = uni[i];
	  for (int j = i + 1; j < size; j++)
	  {
		  if (max0>cgpa[j])
		  {
			  temp0 = max0;
			  max0 = cgpa[j];
			  cgpa[j] = temp0;
			  temp1 = max1;
			  max1 = id[j];
			  id[j] = temp1;

			  temp2 = max2;
			  max2 = name[j];
			  name[j] = temp2;

			  temp3 = max3;
			  max3 = smster[j];
			  smster[j] = temp3;

			  temp4 = max4;
			  max4 =dep[j];
			  dep[j] = temp4;

			  temp5 = max5;
			  max5 = uni[j];
			  uni[j] = temp5;
		  }

	  }
	  cgpa[i] = max0;
	  id[i]=max1;
      name[i]=max2;
	  smster[i]=max3;
	  dep[i]=max4;
	  uni[i]=max5;
	}
    Console.WriteLine("ID" + "\t" + "Name" + "\t\t" + "Smester" + "\t" + "CGPA" + "\t" + "Dept" + "\t" + "Uni");
	for (int i = size - 1; i >= 0; i--)
	{
		count2++;

        Console.WriteLine(id[i] + "\t" + name[i] + "\t" + smster[i] + "\t" + cgpa[i] + "\t" + dep[i] + "\t" + uni[i]);	

		if (count2 == 3)
		{
			break;
		}
	}
	
}
   public void Delete(string[] id, string[] name, string[] smster, double[] cgpa, string[] dep, string[] uni, ref int size)
   {
       string id1;
       int count1 = 0;
       Console.WriteLine("Enter ID to be DELETE:");
       id1 = Console.ReadLine();
       for (int i = 0; i < size; i++)
       {
           if (id[i] == id1)
           {
               for (int j = i; j < (size - 1); j++)
               {
                   id[j] = id[j + 1];
                   name[j] = name[j + 1];
                   smster[j] = smster[j + 1];
                   cgpa[j] = cgpa[j + 1];
                   dep[j] = dep[j + 1];
                   uni[j] = uni[j + 1];
               }
               count1++;
               size = size - 1;
               break;
           }
       }
       if (count1 == 0)
       {
           Console.WriteLine("Record NOt found");
       }
       else
       {
           Console.WriteLine("Record Deleted successfully");
       }
   }
   public void Attendance(string[] id, string[] name, ref int size)
   {
       File.WriteAllText("attend.txt", String.Empty);

	for (int i = 0; i<size; i++)
	{
        Console.WriteLine("ID" + "\t" + "Name");
        Console.WriteLine(id[i] + "\t" + name[i] + "");
        Console.WriteLine("Mark Attendance:");
		att[i]=Console.ReadLine();
        string path = "attend.txt";
        
        using (StreamWriter sw = new StreamWriter(@path,true))
        {
            sw.WriteLine(id[i] + "\t" + name[i] + "\t" + att[i]);
        }
	}
}
   public void viewAtend(string[] id, string[] name, ref int size)
   {

           string path = "attend.txt";
           using (StreamReader sw = new StreamReader(path))
           {
               Console.WriteLine("ID" + "\t" + "Name" + "\t\t" + "Attendance");
       for (int i = 0; i < size; i++)
       {
          
              Console.WriteLine( sw.ReadLine());
           }
           
       }
       
   }
        static void Main(string[] args)
        {
            Program obj = new Program();
            string line;
            string []id=new string [10];
            string []name=new string[10];
            string []smster=new string[10];
            double []cgpa=new double[10];
            string []dep=new string[10];
            string []uni=new string[10];
            string a="", b="", c="", e="", f="";
            double d=0.0;
            int size;
            int i = 0, count = -1;
            int choice;
            string ch;
            string file = "record.txt";
            StreamReader sr = new StreamReader(file);
            while (sr.EndOfStream == false)
            {
                line = sr.ReadLine();
                if (i == 0)
                {
                    a =line;
                    i++;
                }
                else if (i == 1)
                {
                    b = line;
                    i++;
                }
                else if (i == 2)
                {
                    c = line;
                    i++;
                }
                else if (i == 3)
                {
                    d =Convert.ToDouble(line);
                    i++;
                }
                else if (i == 4)
                {
                    e =line;
                    i++;
                }
                else if (i == 5)
                {
                    
                    f =line;
                    i++;
                    if (i % 6 == 0)
                    {
                        count++;
                        id[count] = a;
                        name[count] = b;
                        smster[count] = c;
                        cgpa[count] = d;
                        dep[count] = e;
                        uni[count] = f;
                      
                    }
                    i = 0;
                }
            }
            Console.ReadLine();
            sr.Close();
            size=count+1;
            do
            {
                Console.WriteLine("Press 1 for Search");
                Console.WriteLine("Press 2 for Delete");
                Console.WriteLine("Press 3 for Top 3 Students");
                Console.WriteLine("Press 4 for Mark ATTENDACE");
                Console.WriteLine("Press 5 for View ATTENDACE");
                Console.WriteLine("Press 6 for Exit");
                ch = Console.ReadLine();
                choice = Convert.ToInt32(ch);
                switch (choice)
                {

                    case 1:
                        obj.Search(id, name, smster, cgpa, dep, uni, ref size);
                        break;
                    case 2:
                        obj.Delete(id, name, smster, cgpa, dep, uni,ref size);
                        break;
                    case 3:
                        obj.Heighest(id, name, smster, cgpa, dep, uni,ref  size);
                        break;
                    case 4:
                        obj.Attendance(id, name,ref size);

                        break;
                    case 5:
                        obj.viewAtend(id, name, ref size);
                        break;
                    case 6:
                        break;
                }
            } while (choice != 6);

           
            Console.ReadKey();

      
        }
    }
}