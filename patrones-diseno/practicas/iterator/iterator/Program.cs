using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            AvesEnZoo aves1 = new AvesEnZoo("Águilas ", 35, 10, 25);
            AvesEnZoo aves2 = new AvesEnZoo("Buitres", 100, 55, 45);
            AvesEnZoo aves3 = new AvesEnZoo("Halcones", 80, 25, 55);
            AvesEnZoo[] avesEnZoo = new AvesEnZoo[] { aves1, aves2, aves3 };
            GrupoDeAvesZoo grupoDeAvesZoo = new GrupoDeAvesZoo(avesEnZoo);
            foreach (AvesEnZoo p in avesEnZoo)
            {
                Console.WriteLine(p.ToString() + "\n");
            }
            Console.ReadKey();
        }

        public class AvesEnZoo
        {
            private string tipoDeAve;
            private int numeroAves;
            private int numeroMachos;
            private int numeroHembras;

            public AvesEnZoo(string tipoDeAve, int numeroAves, int numeroMachos, int numeroHembras)
            {
                this.tipoDeAve = tipoDeAve;
                this.numeroAves = numeroAves;
                this.numeroMachos = numeroMachos;
                this.numeroHembras = numeroHembras;
            }

            public virtual string TipoDeAve { get { return tipoDeAve; } }
            public virtual int NumeroAves { get { return numeroAves; } }
            public virtual int NumeroHembras { get { return numeroMachos; } }
            public virtual int NumeroMachos { get { return numeroHembras; } }
            
            public override string ToString()
            {
                return "Tipo ave: " + tipoDeAve + "\nTotal: " + numeroAves + "\nHembras: " + numeroHembras + "\nMachos: " + numeroMachos;
            }
        }
        public class GrupoDeAvesZoo : IEnumerable<AvesEnZoo>
        {
            public AvesEnZoo[] grupoDeAvesZoo;
            public GrupoDeAvesZoo(AvesEnZoo[] grupoDeAvesZoo)
            {
                this.grupoDeAvesZoo = grupoDeAvesZoo;
            }
            public virtual IEnumerator<AvesEnZoo> GetEnumerator()
            {
                IEnumerator<AvesEnZoo> it = new MiIteradorGrupoDeAvesZoo(this);
                return it;
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<AvesEnZoo>)grupoDeAvesZoo).GetEnumerator();
            }
            protected internal class MiIteradorGrupoDeAvesZoo : IEnumerator<AvesEnZoo>
            {
                private readonly GrupoDeAvesZoo outerInstance;
                protected int posicion;
                public MiIteradorGrupoDeAvesZoo(GrupoDeAvesZoo outerInstance)
                {
                    this.outerInstance = outerInstance;
                    posicion = 0;
                }
                public AvesEnZoo Current => throw new NotImplementedException();

                object IEnumerator.Current => throw new NotImplementedException();

                public void Dispose()
                {
                    throw new NotImplementedException();
                }
                public virtual bool hasNext()
                {
                    bool result;
                    if (posicion < outerInstance.grupoDeAvesZoo.Length)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                    return result;
                }
                public bool MoveNext()
                {
                    throw new NotImplementedException();
                }
                public virtual AvesEnZoo Next()
                {
                    AvesEnZoo ave = outerInstance.grupoDeAvesZoo[posicion];
                    posicion++;
                    return ave;
                }
                public virtual void Remove()
                {
                    throw new System.NotSupportedException("No soportado.");
                }

                public void Reset()
                {
                    throw new NotImplementedException();
                }
            }
        }


        
    }
}
