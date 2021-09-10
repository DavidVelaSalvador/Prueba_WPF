using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_WPF
{
    class ObjLista
    {
        private MainWindow Formulario;
        public class ObjPersonaje
        {
            public string name { get; set; }
            public int height { get; set; }
            public string mass { get; set; }
            public string hair_color { get; set; }
            public string skin_color { get; set; }
            public string eye_color { get; set; }
            public string birth_year { get; set; }
            public string gender { get; set; }
            public string homeworld { get; set; }
        }

        List<ObjPersonaje> Lista = new List<ObjPersonaje>();
        WebClient client = new WebClient();
        private String DatosRecibidos = "";
        public bool DatosPersonaje(int index)// pide datos a la API y devuelve verdadero si hemos obtenido respuesta, falso en caso contrario.
        {
            try
            {
                DatosRecibidos = client.DownloadString("https://swapi.dev/api/people/" + index);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public void RecibirDatos(MainWindow form_aux) 
        {
            Formulario = form_aux;
            int i = 0;
            for (i = 0; i < 100; i++)// Solo hay 82 personajes dados de alta en la base de datos.
            {
                if (DatosPersonaje(i))
                {
                    Add();
                }
            }
        }
        private void Add()// añadimos a la lista un nuevo elemento con los datos recibidos.
        {
            ObjPersonaje Obj = new ObjPersonaje { };
            try
            {
                Obj = JsonConvert.DeserializeObject<ObjPersonaje>(DatosRecibidos);
                Lista.Add(Obj);
                Formulario.Title = "Cargando_datos..." + Lista.Count() + "  (Este proceso puede ralentizarse dependiendo de la web swapi)";
                Formulario.Progreso.Value = Lista.Count();
                Formulario.Grid.UpdateLayout();
            }
            catch
            {
                Formulario.Title = "Fallo al insertar el personaje:" + Lista.Count;
            }

        }
        public void SortByName()
        {
            Lista = Lista.OrderBy(ObjPersonaje => ObjPersonaje.name).ToList();
        }
        public void SortByHeight()
        {
            Lista = Lista.OrderBy(ObjPersonaje => ObjPersonaje.height).ToList();
        }
        public int Count()
        {
            return Lista.Count;
        }
        public string Nombre(int index)
        {
            if (index < 0)
            {
                index = 0;
            }
            return Lista[index].name;
        }
        public int Altura(int index)
        {
            if (index < 0)
            {
                index = 0;
            }
            return Lista[index].height;
        }
        public string ColorPelo(int index)
        {
            if (index < 0)
            {
                index = 0;
            }
            return Lista[index].hair_color;
        }
        public string Genero(int index)
        {
            if (index < 0)
            {
                index = 0;
            }
            return Lista[index].gender;
        }
    }
}
