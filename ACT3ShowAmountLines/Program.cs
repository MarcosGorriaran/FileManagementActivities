namespace ACT3
{
    public class Execute
    {
        public static void Main()
        {
            const string AskFileDirectory = "Proporcioname la direccion del archivo que desees que cuente sus lineas de texto: ";
            const string ShowAmountLines = "El archivo posee la siguiente cantidad de lineas: ";
            const string FileNotExistsError = "El archivo especificado no existe";
            const string DirectoryNotExistsError = "La ruta especificada no existe";
            try
            {
                Console.Write(AskFileDirectory);
                Console.Write(ShowAmountLines+CountLinesFromFile(Console.ReadLine() ?? ""));
            }
            catch (FileNotFoundException)
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
        public static int CountLinesFromFile(string fileName)
        {
            return File.ReadLines(fileName).Count();
        }
    }
}