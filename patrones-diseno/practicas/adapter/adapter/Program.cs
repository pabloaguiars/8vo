using System;

namespace adapter
{
    public class PianoElectric : IGuitar
    {
        //esta clase es ruido, puede omitirse y no afecta en nada
        void IGuitar.apagar()
        {
            Console.WriteLine("pianoelectric: apagar");
        }

        void IGuitar.encender()
        {
            Console.WriteLine("pianoelectric: encender");
        }

        void IGuitar.tocar()
        {
            Console.WriteLine("pianoelectric: tocar");
        }
    }

    /// <summary>
    /// Clase de la que se quiere una funcionalidad
    /// </summary>
    public class PianoAcustic
    {
        /// <summary>
        /// Funcionalidad que se quiere
        /// </summary>
        public void tocar()
        {
            Console.WriteLine("pianoacustic: tocar");
        }

        public void parar()
        {
            Console.WriteLine("pianoacustic: parar");
        }
    }

    /// <summary>
    /// Clase que nos ayudará a obtener la funcionalidad que se requiere.
    /// </summary>
    public class PianoAcusticAdapter : PianoAcustic, IGuitar
    {
        void IGuitar.apagar()
        {
            Console.WriteLine("pianoacustic_adapter: tocar");
        }

        void IGuitar.encender()
        {
            Console.WriteLine("pianoacustic_adapter: encender");
        }

        /// <summary>
        /// Nos hacemos de la funcionalidad, este método le pertenece a IGuitar
        /// </summary>
        void IGuitar.tocar()
        {
            // este método le pertenece a PianoAcustic
            tocar();
        }
    }

    /// <summary>
    /// Interfaz que utiliza el cliente para lograr la funcionalidad
    /// </summary>
    public interface IGuitar
    {
        void encender();
        void apagar();

        /// <summary>
        /// Al equipo se le olvidó agregar este método xDxdXd
        /// </summary>
        void tocar();
    }

    /// <summary>
    /// Cliente
    /// </summary>
    public class Client
    {
        private IGuitar guitar;

        public Client(IGuitar guitar)
        {
            this.guitar = guitar;
        }

        public void MakeRequest()
        {
            guitar.tocar();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // podemos llamar la nueva funcionalidad deseada "tocar" de piano acustic desde guitar con el cliente
            IGuitar guitar = new PianoAcusticAdapter();
            Client client = new Client(guitar);
            client.MakeRequest();

            // o solamente, desde la interface
            Console.WriteLine("\nUsando la interface: \n");
            guitar.encender();
            guitar.tocar();
            guitar.apagar();
            

            Console.ReadKey();
        }
    }
}
