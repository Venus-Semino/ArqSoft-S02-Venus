using System;
using System.Collections.Generic;
using System.Text;

namespace Ahorcado
{
    public class PalabrasEnMemoria : IRepositorioPalabras
    {
        private readonly string _categoriaSeleccionada;

        // Diccionario con las categorías sugeridas
        private readonly Dictionary<string, List<string>> _diccionarioPalabras = new()
        {
            { "1", new List<string> { "arquitectura", "componente", "descomposición", "dependencia", "acoplamiento" } },
            { "2", new List<string> { "polimorfismo", "encapsulamiento", "herencia", "abstracción", "clase" } },
            { "3", new List<string> { "ensamblado", "namespace", "interfaz", "delegado", "middleware" } }
        };

        // El constructor recibe la opción elegida por el usuario
        public PalabrasEnMemoria(string categoria)
        {
            _categoriaSeleccionada = categoria;
        }

        public string ObtenerPalabraAleatoria()
        {
            var random = new Random();

            // Verificamos que la opción exista, si no, usamos la 1 por defecto
            var palabrasDeCategoria = _diccionarioPalabras.ContainsKey(_categoriaSeleccionada)
                                      ? _diccionarioPalabras[_categoriaSeleccionada]
                                      : _diccionarioPalabras["1"];

            return palabrasDeCategoria[random.Next(palabrasDeCategoria.Count)];
        }
    }
}