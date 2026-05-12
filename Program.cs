Console.WriteLine("=== AHORCADO ===");
Console.WriteLine("Elige una categoría:");
Console.WriteLine("1. Arquitectura");
Console.WriteLine("2. POO");
Console.WriteLine("3. .NET");
Console.Write("Ingresa el número de la categoría: ");
string categoriaElegida = Console.ReadLine();

var repositorio = new Ahorcado.PalabrasEnMemoria(categoriaElegida);
var motor = new Ahorcado.MotorAhorcado(repositorio);
var ui = new Ahorcado.ConsolaUI(motor);

while (!motor.Ganado() && !motor.Perdido())
{
    ui.MostrarTablero();
    char letra = ui.PedirLetra();

    if (motor.LetraYaUsada(letra))
    {
        ui.MostrarMensaje("Ya usaste esa letra. Presiona Enter para continuar...");
        Console.ReadLine(); // Pausa breve para que el usuario lea
        continue;
    }

    motor.RegistrarLetra(letra);
}

ui.MostrarTablero();
if (motor.Ganado())
    ui.MostrarMensaje($"\n¡Ganaste! La palabra era: {motor.PalabraSecreta}");
else
    ui.MostrarMensaje($"\nPerdiste. La palabra era: {motor.PalabraSecreta}");
if (ui.PreguntarOtraVez())
{
    var nuevoMotor = new Ahorcado.MotorAhorcado(repositorio);
    var nuevaUI = new Ahorcado.ConsolaUI(nuevoMotor);
}