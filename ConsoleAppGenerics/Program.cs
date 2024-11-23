namespace ConsoleAppGenerics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            System.Collections.ArrayList arrayList = new System.Collections.ArrayList();

            arrayList.Add(1);
            arrayList.Add("Hola");
            List<int> numeros = new List<int>();
            List<string> names = new List<string>();

           

           // numeros.Add()

            int element = numeros[0];
            //(int) arrayList[0];


            //Caja<string> cajaString = new Caja<string>();
            
            Caja<int,string> cajaEnteros = new Caja<int, string>();

            

           
        }
    }

    public class Caja<T,TModel> : ICaja<T>
    {
        List<T> list;
        public Caja()
        {
            this.list = new List<T>();
        }
        public T Contenido { get; set; }

        public void Agregar(T elmento)
        {
           this.list.Add(elmento);
        }

        public void Eliminar(T elmento)
        {
           this.list.Remove(elmento);
        }
        

        public List<T> GetElements()
        {
            return this.list;
        }
    }
    public interface ICaja<T> 
    {
        void Agregar(T elmento);
        void Eliminar(T elmento);
        List<T> GetElements();

         
    }

}
