namespace ACT2
{
    public class Execute
    {
        public static void Main()
        {
            const string AskFileDirectory = "Proporcioname la direccion del archivo que desees que acceda: ";
            const string FileNotExistsError = "El archivo especificado no existe";
            const string DirectoryNotExistsError = "La ruta especificada no existe";
            string fileName;
            try
            {
                Console.Write(AskFileDirectory);
                fileName = Console.ReadLine()??"";

                Console.Write(ReadFirstLine(fileName));
            }catch (FileNotFoundException)
            {
                Console.WriteLine(FileNotExistsError);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(DirectoryNotExistsError);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public static string ReadFirstLine(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            return sr.ReadLine()??"";
        }
    }
}