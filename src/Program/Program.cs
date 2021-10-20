using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider p = new PictureProvider();
            String pathL = @"C:\Users\mielp\OneDrive\Escritorio\Programación 2\Proyectos\PipesYFilters\PII_Pipes_Filters_Start\src\Program\luke.jpg";
            String pathB = @"C:\Users\mielp\OneDrive\Escritorio\Programación 2\Proyectos\PipesYFilters\PII_Pipes_Filters_Start\src\Program\beer.jpg";
            PipeNull pipe1 = new PipeNull();
            FilterNegative fNegativo = new FilterNegative();
            PipeSerial pipe2 = new PipeSerial(fNegativo, pipe1);
            FilterGreyscale fGris = new FilterGreyscale();
            PipeSerial pipe3 = new PipeSerial(fGris, pipe2);
            IPicture picture = p.GetPicture(pathL);
            IPicture pictureEnviado = pipe3.Send(picture);
            p.SavePicture(pipe3.Send(p.GetPicture(pathL)),pathB);

        }
    }
}
