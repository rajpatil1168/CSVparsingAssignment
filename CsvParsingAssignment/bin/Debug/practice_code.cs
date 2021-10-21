//using System;
//using System.Drawing;
//using System.Drawing.Imaging;
//using Nvidia.AtpLib;
//using System.Windows.Automation;
//using System.Threading;

//namespace Assignment2
//{
//    class Program1
//    {
//        static void Main(string[] args)
//        {
//            int i = 1;
//            UIA uia = new UIA();
//            Program1 obj_pro1 = new Program1();


//            Console.WriteLine(@"Give inputs for addtion, which you wants to add on calulcator automatically from(0 - 9) only") ;
//            int int_input1 = Int32.Parse(Console.ReadLine());
//            string str_input1;

//            int int_input2 = Int32.Parse(Console.ReadLine());
//            string str_input2;

//            str_input1 = obj_pro1.Coversion_int_to_String(int_input1);
//            str_input2 = obj_pro1.Coversion_int_to_String(int_input2);




//            System.Diagnostics.Process.Start("calc.exe");
//            Console.WriteLine(i++ + ".Calculator Opened.");
//            Thread.Sleep(2000);
//            AutomationElement AE_Calc = uia.GetElementByControlTypeAndName(AutomationElement.RootElement, ControlType.Window, "Calculator");
//            if (AE_Calc != null)
//            {
//                Console.WriteLine(i++ + "." + AE_Calc.Current.Name + " is not null and assigned to variable AE_Calc");
//                AutomationElement AE_group = uia.GetElementByClassName(AE_Calc, "LandmarkTarget", true, 300);
//                if (AE_group != null)
//                {
//                    Console.WriteLine(i++ + "." + AE_group.Current.Name + " is not null and assigned to variable AE_group");
//                    AutomationElement AE_Number_pad = uia.GetElementByControlTypeAndName(AE_group, ControlType.Group, "Number pad");
//                    if (AE_Number_pad != null)
//                    {
//                        Console.WriteLine(i++ + "." + AE_Number_pad.Current.Name + " is not null and assigned to variable AE_Number_pad");
//                        AutomationElement AE_input1 = uia.GetElementByControlTypeAndName(AE_Number_pad, ControlType.Button, str_input1);
//                        AutomationElement AE_input2 = uia.GetElementByControlTypeAndName(AE_Number_pad, ControlType.Button, str_input2);
//                        Console.WriteLine(i++ + "." + AE_input1.Current.Name + " is not null and assigned to variable AE_input1");
//                        Console.WriteLine(i++ + "." + AE_input2.Current.Name + " is not null and assigned to variable AE_input2");
//                        Console.WriteLine("CLICKING"+int_input1+" !!");
//                        Thread.Sleep(2000);
//                        uia.ClickElement(AE_input1);

//                        AutomationElement AE_Standard_operators = uia.GetElementByControlTypeAndName(AE_group, ControlType.Group, "Standard operators");
//                        if (AE_Standard_operators != null)
//                        {
//                            Console.WriteLine(AE_Standard_operators.Current.Name);
//                            AutomationElement AE_plus = uia.GetElementByControlTypeAndName(AE_Standard_operators, ControlType.Button, "Plus");
//                            AutomationElement AE_equal_to = uia.GetElementByControlTypeAndName(AE_Standard_operators, ControlType.Button, "Equals");

//                            Console.WriteLine(@"CLICKING '+' !!");
//                            Thread.Sleep(1000);
//                            uia.ClickElement(AE_plus);

//                            Console.WriteLine("CLICKING" + int_input + " !!");
//                            Thread.Sleep(1000);
//                            uia.ClickElement(AE_input2);

//                            Console.WriteLine(@"CLICKING '=' !!");
//                            Thread.Sleep(1000);
//                            uia.ClickElement(AE_equal_to);

//                            Console.WriteLine(@"CLICKING ScreenShot !!");
//                            Thread.Sleep(3000);
//                            obj_pro1.CaptureMyScreen();
//                        }
//                    }

//                }
//            }


//            else
//                Console.WriteLine("AE_Calse is null");


//            }

//            void CaptureMyScreen()

//            {
//                try

//                {

//                    Bitmap captureBitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);
//                    Rectangle captureRectangle = System.Windows.Forms.Screen.AllScreens[0].Bounds;

//                    Graphics captureGraphics = Graphics.FromImage(captureBitmap);

//                    captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

//                    captureBitmap.Save(@"C:\Users\abhipatil\sw\qa\Assignment_C#_ abhishek\Assignment2\Capture.jpg", ImageFormat.Jpeg);
//                    Console.WriteLine("Screen Captured and Successfully stored !!");


//                }

//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex.Message);
//                }

//            }

//            string Coversion_int_to_String(int variable)
//            {

//                string buffer_set ="";

//                switch (variable)
//                {
//                    case 1:
//                        Console.WriteLine("Case 1");
//                        buffer_set = "One";
//                        break;

//                    case 2:
//                        Console.WriteLine("Case 2");
//                        buffer_set = "Two";
//                        break;

//                    case 3:
//                        Console.WriteLine("Case 2");
//                        buffer_set = "Three";
//                        break;

//                    case 4:
//                        Console.WriteLine("Case 2");
//                        buffer_set = "Four";
//                        break;

//                    case 5:
//                        Console.WriteLine("Case 2");
//                        buffer_set = "Five";
//                        break;

//                    case 6:
//                        Console.WriteLine("Case 2");
//                        buffer_set = "Six";
//                        break;

//                    case 7:
//                        Console.WriteLine("Case 2");
//                        buffer_set = "Seven";
//                        break;

//                    case 8:
//                        Console.WriteLine("Case 2");
//                        buffer_set = "Eight";
//                        break;

//                    case 9:
//                        Console.WriteLine("Case 2");
//                        buffer_set = "Nine";
//                        break;

//                    case 0:
//                        Console.WriteLine("Case 2");
//                        buffer_set = "Zero";
//                        break;

//                    default:
//                        Console.WriteLine("The wrong input.");
//                        break;


//                }
//                return buffer_set;

//            }




//        }


//    }


































//int i = 1;

//UIA uia = new UIA();

//Console.WriteLine("Give inputs for addtion, which you wants to add on calulcator automatically from(0-9) only");
//            public Int64 int_input1 = Convert.ToInt64(Console.ReadLine());
//string str_input1;


////String input1 = (Console.ReadLine());
////Int64 input2 = Convert.ToInt64(Console.ReadLine());






//string operation1 = "plus/+";
//string operation2 = "equal to/=";

////if (calculator not open)
////{
////    System.Diagnostics.Process.Start("calc.exe");
////}


////if (calculator open){


//Console.WriteLine(i++ + ".Calculator Opened.");
//                Thread.Sleep(2000);
//                AutomationElement AE_Calc = uia.GetElementByControlTypeAndName(AutomationElement.RootElement, ControlType.Window, "Calculator");
//                if (AE_Calc != null)
//                {
//                    Console.WriteLine(i++ + "." + AE_Calc.Current.Name + " is not null and assigned to variable AE_Calc");
//                    AutomationElement AE_group = uia.GetElementByClassName(AE_Calc, "LandmarkTarget", true, 300);
//                    if (AE_group != null)
//                    {
//                        Console.WriteLine(i++ + "." + AE_group.Current.Name + " is not null and assigned to variable AE_group");
//                        AutomationElement AE_Number_pad = uia.GetElementByControlTypeAndName(AE_group, ControlType.Group, "Number pad");
//                        if (AE_Number_pad != null)
//                        {
//                            Console.WriteLine(i++ + "." + AE_Number_pad.Current.Name + " is not null and assigned to variable AE_Number_pad");
//                            AutomationElement AE_Input1 = uia.GetElementByControlTypeAndName(AE_Number_pad, ControlType.Button, str_input1);
//AutomationElement AE_Input2 = uia.GetElementByControlTypeAndName(AE_Number_pad, ControlType.Button, str_input2);
//Console.WriteLine(i++ + "." + AE_input1.Current.Name + " is not null and assigned to variable AE_input1");
//                            Console.WriteLine(i++ + "." + AE_input2.Current.Name + " is not null and assigned to variable AE_input2");
//                            Console.WriteLine("CLICKING " + input1 + "!!");
//                            Thread.Sleep(2000);
//                            uia.ClickElement(AE_input1);

//                            AutomationElement AE_Standard_operators = uia.GetElementByControlTypeAndName(AE_group, ControlType.Group, "Standard operators");
//                            if (AE_Standard_operators != null)
//                            {
//                                Console.WriteLine(AE_Standard_operators.Current.Name);
//                                AutomationElement AE_plus = uia.GetElementByControlTypeAndName(AE_Standard_operators, ControlType.Button, "Plus");
//AutomationElement AE_equal_to = uia.GetElementByControlTypeAndName(AE_Standard_operators, ControlType.Button, "Equals");

//Console.WriteLine(@"CLICKING '+' !!");
//                                Thread.Sleep(1000);
//                                uia.ClickElement(AE_plus);

//                                if (uia.ClickElement(AE_plus))
//                                {
//                                    Console.WriteLine("CLICKED " + operation1 + "!!");
//                                }

//                                Console.WriteLine(@"CLICKING '5' !!");
//                                Thread.Sleep(1000);
//                                uia.ClickElement(AE_input2);

//                                if (uia.ClickElement(AE_input2))
//                                {
//                                    Console.WriteLine("CLICKED " + input2 + "!!");
//                                }

//                                Console.WriteLine(@"CLICKING '=' !!");
//                                Thread.Sleep(1000);
//                                uia.ClickElement(AE_equal_to);

//                                if (uia.ClickElement(AE_equal_to))
//                                {
//                                    Console.WriteLine("CLICKED " + operation1 + "!!");
//                                }


//                                Console.WriteLine(@"CLICKING ScreenShot !!");
//                                Thread.Sleep(3000);
//                                CaptureMyScreen();
//                            }
//                        }

//                    }


//                    else
//                        Console.WriteLine("AE_Calse is null");
//                }
//            }
//            void CaptureMyScreen()

//{
//    try

//    {

//        Bitmap captureBitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);
//        Rectangle captureRectangle = System.Windows.Forms.Screen.AllScreens[0].Bounds;

//        Graphics captureGraphics = Graphics.FromImage(captureBitmap);

//        captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

//        captureBitmap.Save(@"C:\Users\abhipatil\sw\qa\Assignment_C#_ abhishek\Assignment2\Capture.jpg", ImageFormat.Jpeg);
//        Console.WriteLine("Screen Captured and Successfully stored !!");


//    }

//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }

//}



//    }
//}











//using System;
//using System.Drawing;
//using System.Drawing.Imaging;
//using Nvidia.AtpLib;
//using System.Windows.Automation;
//using System.Threading;

//namespace Assignment2
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int i = 1;
//            UIA uia = new UIA();
//            System.Diagnostics.Process.Start("calc.exe");
//            Console.WriteLine(i++ +".Calculator Opened.");
//            Thread.Sleep(2000);

//            AutomationElement AE_Calc = uia.GetElementByControlTypeAndName(AutomationElement.RootElement, ControlType.Window, "Calculator");
//            if (AE_Calc != null)
//            {
//                Console.WriteLine(i++ +"."+ AE_Calc.Current.Name+ " is not null and assigned to variable AE_Calc");
//                AutomationElement AE_group = uia.GetElementByClassName(AE_Calc, "LandmarkTarget", true, 300);
//                if (AE_group != null)
//                {
//                    Console.WriteLine(i++ + "." + AE_group.Current.Name + " is not null and assigned to variable AE_group");
//                    AutomationElement AE_Number_pad = uia.GetElementByControlTypeAndName(AE_group, ControlType.Group, "Number pad");
//                    if (AE_Number_pad != null)
//                    {
//                        Console.WriteLine(i++ + "."+AE_Number_pad.Current.Name + " is not null and assigned to variable AE_Number_pad");
//                        AutomationElement AE_Four = uia.GetElementByControlTypeAndName(AE_Number_pad, ControlType.Button, "Four");
//                        AutomationElement AE_Five = uia.GetElementByControlTypeAndName(AE_Number_pad, ControlType.Button, "Five");
//                        Console.WriteLine(i++ + "." + AE_Four.Current.Name + " is not null and assigned to variable AE_Four");
//                        Console.WriteLine(i++ + "." + AE_Five.Current.Name + " is not null and assigned to variable AE_Five");
//                        Console.WriteLine("CLICKING 4 !!");
//                        Thread.Sleep(2000);
//                        uia.ClickElement(AE_Four);                        

//                        AutomationElement AE_Standard_operators = uia.GetElementByControlTypeAndName(AE_group, ControlType.Group, "Standard operators");
//                        if (AE_Standard_operators != null)
//                        {
//                            Console.WriteLine(AE_Standard_operators.Current.Name);
//                            AutomationElement AE_plus = uia.GetElementByControlTypeAndName(AE_Standard_operators, ControlType.Button, "Plus");
//                            AutomationElement AE_equal_to = uia.GetElementByControlTypeAndName(AE_Standard_operators, ControlType.Button, "Equals");

//                            Console.WriteLine(@"CLICKING '+' !!");
//                            Thread.Sleep(1000);
//                            uia.ClickElement(AE_plus);

//                            Console.WriteLine(@"CLICKING '5' !!");
//                            Thread.Sleep(1000);
//                            uia.ClickElement(AE_Five);

//                            Console.WriteLine(@"CLICKING '=' !!");
//                            Thread.Sleep(1000);
//                            uia.ClickElement(AE_equal_to);

//                            Console.WriteLine(@"CLICKING ScreenShot !!");
//                            Thread.Sleep(3000);
//                            CaptureMyScreen();
//                        }
//                    }

//                }


//                else
//                    Console.WriteLine("AE_Calse is null");


//            }

//            void CaptureMyScreen()

//            {
//                try

//                {

//                    Bitmap captureBitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);
//                    Rectangle captureRectangle = System.Windows.Forms.Screen.AllScreens[0].Bounds;

//                    Graphics captureGraphics = Graphics.FromImage(captureBitmap);

//                    captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);                   

//                    captureBitmap.Save(@"C:\Users\abhipatil\sw\qa\Assignment_C#_ abhishek\Assignment2\Capture.jpg", ImageFormat.Jpeg);
//                    Console.WriteLine("Screen Captured and Successfully stored !!");


//                }

//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex.Message);
//                }

//            }
//        }


//    }
//}









//System.Diagnostics.Process[] A = System.Diagnostics.Process.GetProcesses();
//System.Diagnostics.Process[] C = System.Diagnostics.Process.GetProcessesByName("Calculator.exe");
// //System.Diagnostics.Process B = System.Diagnostics.Process.GetProcessById(5156);
//// Console.WriteLine(B);                    
// for (n = 0; i<C.Length; i++)
// {
//     Console.WriteLine(C[i]);

//     if (A[i] == B)
//     {
//         flag = 1;
//         Console.WriteLine(i++ + "Calculator already Opened.");

//         break;
//     }

// }


//if (flag == 1)
//{
//    Console.WriteLine(i++ + "Calculator already Opened.");

//}
//else
//{
//    System.Diagnostics.Process.Start("calc.exe");

//    Console.WriteLine(i++ + ".Calculator Opened.");
//    Thread.Sleep(2000);
//}



//AE cal call krava lagel...null alyvr not 
///procee clas chi method get proces  by name -->process gheun cal present ahe ka?? 
//GetElementById(AutomationElement.RootElement, string automationId, bool recursive, int timeout)






//        Console.WriteLine("Calculator is not already opened .");
//        System.Diagnostics.Process.Start("calc.exe");
//        Console.WriteLine(i++ + ".Calculator Opened.");
//        Thread.Sleep(1000);



//System.Diagnostics.Process[] A = System.Diagnostics.Process.GetProcesses();
//System.Diagnostics.Process[] C = System.Diagnostics.Process.GetProcessesByName("Calculator");
////System.Diagnostics.Process B = System.Diagnostics.Process.GetProcessById(5156);
////Console.WriteLine(C[]); 
////Console.WriteLine(C[0].ProcessName.ToString());
//if(C.Length!=0)
//{
//    Console.WriteLine(i++ + "Calculator already Opened.");
//}
//else
//{
//    Console.WriteLine(i++ + "not Opened.");

//}



//if (flag == 1)
//{
//    Console.WriteLine(i++ + "Calculator already Opened.");

//}
//else
//{
//    System.Diagnostics.Process.Start("calc.exe");

//    Console.WriteLine(i++ + ".Calculator Opened.");
//    Thread.Sleep(2000);
//}




//Console.WriteLine(@"Give inputs for addtion, which you wants to add on calulcator automatically from(0 - 9) only");
//Console.WriteLine("\n INPUT 1: ");
//int int_input1 = Int32.Parse(Console.ReadLine());


//Console.WriteLine("\n INPUT 2: ");
//int int_input2 = Int32.Parse(Console.ReadLine());
//Console.WriteLine("\n \n\n");

//Console.WriteLine("\n Give operation: ");
//string str_operation = Console.ReadLine();
//Console.WriteLine("\n \n\n");

//string str_operation_name = obj_pro1.Coversion_sign_to_String(str_operation);


//string str_input1 = obj_pro1.Coversion_int_to_String(int_input1);
//string str_input2 = obj_pro1.Coversion_int_to_String(int_input2);

//string compare = "";


//if ((String.Equals(str_input1, compare)) || (String.Equals(str_input2, compare)) || (String.Equals(str_operation_name, compare)))
//{
//    Console.WriteLine(@"Either Input1 or Input2 is not between 0 and 9....REENTER or RERUN !!");
//}
//else
//{


//Console.WriteLine("Calculator is not already opened .");
//System.Diagnostics.Process.Start("calc.exe");
//Console.WriteLine(i++ + ".Calculator Opened.");
//Thread.Sleep(1000);