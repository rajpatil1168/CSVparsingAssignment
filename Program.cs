using Nvidia.AtpLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GamePlaySetup
{
    class Program
    {
        static void Main(string[] args)
        {
            GamePlaySetup runProc = new GamePlaySetup();
            try
            {
                Console.WriteLine("Starting Run part of TEST");
                string name = "Game Play Setup";
                string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string logName = "Setup"; // For generating run.log
                runProc.Init(name, version, args, logName, true);
                runProc.WriteToTaskDir(true); // Write Directly to Task Result Directory
                runProc.EnableResultsInDebugLog(true); // Write results to log file as well
                runProc.EnableOverAllResultCalculation(false);
                runProc.Execute();
            }
            catch (Exception e)
            {
                runProc.HandleException(e);
            }
            //finally
            //{
            //    Win32.ScriptExit(0);
            //}
        }
    }

    class GamePlaySetup : Procedure
    {
        private string toolsPath = AtpEnvironment.ApplicationDir + @"\DL_Setup";
        private string serverToolsPath = AtpEnvironment.ServerApplicationDir + @"\DL_Setup";
        private string deepLearningfolderPath;
        protected override void Run()
        {
            bool status = false;
            try
            {
                //if (!Detection.IsHDREnabled())
                //{
                //    ScriptState.SetCurrentState(ResultType.NOTSUPPORTED.ToString());
                //    resultAgent.AddSubResult("HDR Display Connected", ResultType.NOTSUPPORTED);
                //}
                //else
                //{
                //    resultAgent.AddSubResult("HDR Display Connected", true);
                //}
                //string anacondaFolderName = System.Configuration.ConfigurationManager.AppSettings["AnacondaSetupFolder"];
                //if (string.IsNullOrEmpty(anacondaFolderName))
                //    anacondaFolderName = @"DeepLearning\Anaconda3";
                //deepLearningfolderPath = AtpEnvironment.SystemDrive + @"\" + anacondaFolderName;
                status = CopyPython3();//SetupGamePlayPrerequisites();
                ScriptState.SetCurrentState(status.ToString());
                resultAgent.AddSubResult("Setup Gameplay Prerequisites", status);
            }
            catch(Exception ex)
            {
                log.WriteLine("Exception : " + ex.Message);
                log.WriteLine(ex.StackTrace);
            }
            ScriptState.SetCurrentState(status.ToString());
        }

        private bool CopyPython3()
        {
            bool result = false;
            string python3LocalPath = System.Configuration.ConfigurationManager.AppSettings["PathPythonExecutable"];
            if(string.IsNullOrEmpty(python3LocalPath))
                python3LocalPath = @"D:\python3";
            string serverDirectoryPathForFile = serverToolsPath + @"\python3";
            if (!Directory.Exists(python3LocalPath))
            {
                Directory.CreateDirectory(python3LocalPath);
                if (Directory.Exists(serverDirectoryPathForFile))
                {
                    log.WriteLine("Copying Python3 package Files...");
                    FileCopier fileCopier = new FileCopier(serverDirectoryPathForFile, python3LocalPath, "Python3 Package Copy");
                    fileCopier.Copy();
                    fileCopier.WaitForComplete();
                    log.WriteLine("Python3 package Files Copied...");
                    result = true;
                }
                else
                {
                    log.WriteLine("ERR:  Python3 package not found in location - " + serverDirectoryPathForFile);
                }
            }
            else
            {
                log.WriteLine("Python3 package already exists");
                result = true;
            }
            return result;
        }

        private void ExecuteDLInstallCommands(string command, string workingDir, int timeout, Log log)
        {
            log.WriteLine("Running command: " + command);
            log.WriteLine("Working Directory: " + workingDir);
            Command cmd = new Command("/C " + command);
            cmd.WorkingDirectory(workingDir);
            bool isProcessExited = false;
            cmd.ExecuteCmd(out isProcessExited);
            log.WriteLine("Is process Exited: " + isProcessExited);
            DateTime start = DateTime.Now;
            int count = 0;
            while (!cmd.HasExited && count < 3)
            {
                if (cmd.WaitForExit(timeout))
                {
                    log.WriteLine("Command " + command + " is executed successfully.");
                    DateTime endtime = DateTime.Now;
                    TimeSpan time = endtime - start;
                    log.WriteLine("Time for installation: " + time.Minutes + "." + time.Seconds + " mins");

                }
                count++;
            }


            if (cmd.ExitCode != 0)
                log.WriteLine("Package install is not comelete or faild :- Exid code is: " + cmd.ExitCode);
        }
        public bool InstallAnaconda()
        {
            string anacondaExeName = System.Configuration.ConfigurationManager.AppSettings["AnacondaExeName"];
            if (string.IsNullOrEmpty(anacondaExeName))
                anacondaExeName = "Anaconda3-2020.11-Windows-x86_64.exe";
            if (!File.Exists(toolsPath + @"\" + anacondaExeName))
            {
                log.WriteLine(anacondaExeName + " not found at " + toolsPath + ". Copying it...");

                FileCopier.CopyFile(serverToolsPath, toolsPath, anacondaExeName, true);
                if (!File.Exists(toolsPath + @"\" + anacondaExeName))
                {
                    resultAgent.WriteLine(anacondaExeName + " not found at " + toolsPath + " after copy");
                    return false;
                }
                else
                    log.WriteLine(anacondaExeName + " File copied at " + toolsPath);
            }
            
            ExecuteDLInstallCommands(anacondaExeName + " /InstallationType=JustMe /RegisterPython=1 /S /D=" + deepLearningfolderPath, toolsPath, 60000 * 30, log);
            log.WriteLine("Setting envirement variable");
            string currentUseEVPath = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User);
            string variablesToSet = deepLearningfolderPath + @"\Scripts;" + deepLearningfolderPath;
            Environment.SetEnvironmentVariable("PATH", currentUseEVPath + ";" + variablesToSet, EnvironmentVariableTarget.User);
            Thread.Sleep(1000);
            string variables = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User);
            if (variables.Contains(variablesToSet))
                log.WriteLine("Enviornment variables set successfully: " + variables);
            else
            {
                log.WriteLine("Enviornment variable are not set. Still continuing with setup as not dependent on it.");
            }
            return File.Exists(deepLearningfolderPath + @"\python.exe");
        }

        public bool InstallCUDAToolkit()
        {
            string cudaExeName = System.Configuration.ConfigurationManager.AppSettings["CudaExeName"];
            if (string.IsNullOrEmpty(cudaExeName))
                cudaExeName = "cuda_11.2.0_460.89_win10.exe";
            if (!File.Exists(toolsPath + @"\" + cudaExeName))
            {
                log.WriteLine(cudaExeName + " not found at " + toolsPath + ". Copying it...");
                FileCopier.CopyFile(serverToolsPath, toolsPath, cudaExeName, true);
                if (!File.Exists(toolsPath + @"\" + cudaExeName))
                {
                    resultAgent.WriteLine(cudaExeName + " not found at " + toolsPath + " after copy");
                    return false;
                }
                else
                    log.WriteLine(cudaExeName + " File copied at " + toolsPath);
            }

            ExecuteDLInstallCommands(cudaExeName + " -s", toolsPath, 60000 * 30, log);
            return Directory.Exists(AtpEnvironment.SystemDrive + @"\Program Files\NVIDIA GPU Computing Toolkit\CUDA");
        }

        public void InstallRequiredPythonPackages(string[] allPackages)
        {
            string pipPath = deepLearningfolderPath + @"\Scripts\pip3.exe";
            int timeout = 300000;
            log.WriteLine("Installing packages");
            foreach (string pckg in allPackages)
            {
                if (string.IsNullOrEmpty(pckg))
                    continue;
                string command = pipPath + " install " + pckg;
                ExecuteDLInstallCommands(command, deepLearningfolderPath + @"\Scripts", timeout, log);
                Thread.Sleep(2000);
            }
        }
        public bool SetupGamePlayPrerequisites()
        {
            string pythonPath = deepLearningfolderPath + @"\python.exe";
            if (File.Exists(pythonPath))
            {
                log.WriteLine("Ananconda already installed");
            }
            else
            {
                if (!InstallAnaconda())
                {
                    resultAgent.WriteLine("Unable to install anaconda on the system");
                    return false;
                }
                else
                {
                    log.WriteLine("Anaconda installed on the system");
                }
            }
            
            int timeout = 60000;
            log.WriteLine("Upgrade pip");
            string upgrade_pip = pythonPath + " -m pip install --upgrade pip"; // upgrade pip to latest to install pymssql
            ExecuteDLInstallCommands(upgrade_pip, deepLearningfolderPath, timeout, log);
            Thread.Sleep(2000);

            string requiredPackageFileName = System.Configuration.ConfigurationManager.AppSettings["PackageToInstall"];
            if (string.IsNullOrEmpty(requiredPackageFileName))
                requiredPackageFileName = "PackagesToInstall.txt";

            string[] allPackages = File.ReadAllLines(requiredPackageFileName);
            InstallRequiredPythonPackages(allPackages);

            return true;
        }
    }
}
