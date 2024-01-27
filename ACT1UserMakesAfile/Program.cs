using System.Text;

namespace ACT1
{
    public class Program
    {
        public static void Main()
        {
            const string AskFile = "Proporcioname el nombre de un archivo que desees leer: ";
            const string WrongTargetFileError = "El nombre del archivo debe de acabar en {0}";
            const string ErrorFolderNotFound = "Es necesario que crea el directorio files en la raiz del programa";
            const string ErrorFileNotFound = "El archivo {0} no existe, se creara el archivo y se escribira en el";
            const string TargetFile = ".txt";
            string fileName="";
            bool error;
            try 
            {
                do
                {
                    Console.Write(AskFile);
                    fileName = Console.ReadLine() ?? "";
                    error = !fileName.EndsWith(TargetFile);
                    if (error) Console.WriteLine(WrongTargetFileError, TargetFile);
                } while (error);


                CheckAllFileReadObjects(fileName);
            }catch (DirectoryNotFoundException)
            {
                Console.WriteLine(ErrorFolderNotFound);
            }catch(FileNotFoundException)
            {
                Console.WriteLine(ErrorFileNotFound, fileName);
                CheckAllFileObjects(fileName);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        public static void CheckAllFileReadObjects(string file)
        {
            FileReadFileObject(file);
            FileReadFileStreamObject(file);
        }
        public static void CheckAllFileObjects(string file)
        {
            FileWriteFileObject(file);
            CheckAllFileReadObjects(file);
            FileWriteFileStreamObject(file);
            CheckAllFileReadObjects(file);
            StreamWriter(file);
            CheckAllFileReadObjects(file);
        }
        public static void FileReadFileObject(string file)
        {
            string path = Path.GetFullPath(@"..\..\..\files\" + file);
            using StreamReader sr = File.OpenText(path);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
        public static void FileReadFileStreamObject(string file)
        {
            string path = Path.GetFullPath(@"..\..\..\files\" + file);
            using FileStream fs = File.OpenRead(path);
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);
            int readLen;
            while ((readLen = fs.Read(b, 0, b.Length)) > 0)
            {
                Console.WriteLine(temp.GetString(b, 0, readLen));
            }
        }
        public static void FileWriteFileStreamObject(string file)
        {
            string path = Path.GetFullPath("..\\..\\..\\files\\" + file);
            using FileStream fs = File.Create(path);

            byte[] info = new UTF8Encoding(true).GetBytes("Escriptura des de FileStream");
            fs.Write(info, 0, info.Length);
        }
        public static void FileWriteFileObject(string file)
        {
            string path = Path.GetFullPath(@"..\..\..\files\" + file);
            if (!File.Exists(path))
            {
                using StreamWriter sw = File.CreateText(path);
                sw.WriteLine("Welcome ");
                sw.WriteLine("to ");
                sw.WriteLine("File Handling");
                sw.Close();
                string createText = "Hello world!" + Environment.NewLine;
                File.WriteAllText(path, createText);

                string appendText = "Nova línia" + Environment.NewLine;
                File.AppendAllText(path, appendText);
                
            }
            
        }
        public static void StreamWriter(string file)
        {
            string path = Path.GetFullPath(@"..\..\..\files\" + file);
            //using StreamWriter sw = new StreamWriter(path);
            //sw.WriteLine("Escriptura amb StreamWriter ");

            using StreamWriter sw = new StreamWriter(path, append: true);
            sw.WriteLine("Escriptura amb StreamWriter en mode Append");
        }
    }
}
