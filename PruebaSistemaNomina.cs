namespace SistemaNomina;

using System;
using System.Collections.Generic;

public class PruebaSistemaNomina
{
    // ENCAPSULACION Guardamos los empleados en una Lista privada
    // Solo esta clase puede acceder directamente a esta colección
    private static List<Empleado> empleados = new List<Empleado>();

    public static void Main(string[] args)
    {
        // Variable para controlar cuAndo salir del programa
        bool salir = false;

        // Bucle principal del programa que se repite hasta que el usuario seleccione salir
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("SISTEMA DE NOMINA");
            Console.WriteLine(" 1. Agregar nuevo empleado");
            Console.WriteLine(" 2. Listar todos los empleados");
            Console.WriteLine(" 3. Generar reporte semanal");
            Console.WriteLine(" 4. Actualizar empleado");
            Console.WriteLine(" 5. Eliminar empleado");
            Console.WriteLine(" 6. Salir");
            Console.Write("Selecciona una opción (1-6): ");

            string opcion = Console.ReadLine();

            // Switch para ejecutar el método correspondiente según la opción del usuario
            switch (opcion)
            {
                case "1":
                    // Llamamos al metodo para agregar un nuevo empleado
                    AgregarEmpleado();
                    break;
                case "2":
                    // Llamamos al metodo para listar todos los empleados
                    ListarEmpleados();
                    break;
                case "3":
                    // Llamamos al metodo para generar el reporte de la semana
                    GenerarReporte();
                    break;
                case "4":
                    // Llamamos al metodo para actualizar los datos de un empleado
                    ActualizarEmpleado();
                    break;
                case "5":
                    // Llamamos al metodo para eliminar un empleado
                    EliminarEmpleado();
                    break;
                case "6":
                    // El usuario eligio salir, entonces ponemos salir en true
                    salir = true;
                    Console.WriteLine("\n Sistema cerrado correctamente.");
                    break;
                default:
                    Console.WriteLine("\n Opción no valida.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    // Método para agregar un nuevo empleado al sistema
    private static void AgregarEmpleado()
    {
        Console.Clear();
        Console.WriteLine("AGREGAR NUEVO EMPLEADO");

        Console.WriteLine("Selecciona el tipo de empleado:");
        Console.WriteLine("1. Empleado Asalariado");
        Console.WriteLine("2. Empleado Por Horas");
        Console.WriteLine("3. Empleado Por Comisión");
        Console.WriteLine("4. Empleado Asalariado por Comisión\n");
        Console.Write("Opción (1-4): ");

        string tipo = Console.ReadLine();

        // Pedimos los datos que todos los empleados tienen en común
        Console.Write("\nPrimer nombre?: ");
        string nombre = Console.ReadLine() ?? "";

        Console.Write("Apellido paterno?: ");
        string apellido = Console.ReadLine() ?? "";

        Console.Write("Número de seguro social?: ");
        string ss = Console.ReadLine() ?? "";

        // ABSTRACCION Usamos la referencia de tipo base Empleado
        // Esto nos permite guardar cualquier tipo de empleado en una sola variable
        Empleado emp = null;

        try
        {
            // Segun el tipo seleccionado, creamos el objeto correspondiente
            // POLIMORFISMO Cada tipo de empleado se crea diferente pero todos son Empleado
            switch (tipo)
            {
                case "1":
                    // HERENCIA EmpleadoAsalariado hereda de Empleado
                    // Usamos el constructor de EmpleadoAsalariado para crear la instancia
                    Console.Write("Salario semanal?: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal salario))
                        emp = new EmpleadoAsalariado(nombre, apellido, ss, salario);
                    break;

                case "2":
                    // HERENCIA EmpleadoPorHoras hereda de Empleado
                    // Usamos las propiedades Sueldo y Horas de la clase EmpleadoPorHoras
                    Console.Write("Sueldo por hora?: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal sueldo))
                    {
                        Console.Write("Horas trabajadas?: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal horas))
                            emp = new EmpleadoPorHoras(nombre, apellido, ss, sueldo, horas);
                    }
                    break;

                case "3":
                    // HERENCIA EmpleadoPorComision hereda de Empleado
                    // Usamos las propiedades VentasBrutas y TarifaComision
                    Console.Write("Ventas brutas?: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal ventas))
                    {
                        Console.Write("Tarifa de comisión (ej: 0.06 para 6%)?: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal tasa))
                            emp = new EmpleadoPorComision(nombre, apellido, ss, ventas, tasa);
                    }
                    break;

                case "4":
                    // HERENCIA EmpleadoBaseMasComision hereda de EmpleadoPorComision
                    // Es una herencia en dos niveles EmpleadoBaseMasComision -> EmpleadoPorComision -> Empleado
                    // Usamos VentasBrutas, TarifaComision del padre y SalarioBase que es propia
                    Console.Write("Ventas brutas?: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal ventas2))
                    {
                        Console.Write("Tarifa de comisión?: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal tasa2))
                        {
                            Console.Write("Salario base?: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal salarioBase))
                                emp = new EmpleadoBaseMasComision(nombre, apellido, ss, ventas2, tasa2, salarioBase);
                        }
                    }
                    break;
            }

            // Si el empleado se crea correctamente, lo agregamos a la lista
            if (emp != null)
            {
                empleados.Add(emp);
                Console.WriteLine($"\n Empleado agregado correctamente.");
                // POLIMORFISMO Llamamos a ToString que es diferente para cada tipo de empleado
                Console.WriteLine(emp);
            }
            else
            {
                Console.WriteLine("\n Error: Datos inválidos.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n Error: {ex.Message}");
        }

        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey();
    }

    // Metodo para mostrar todos los empleados registrados
    private static void ListarEmpleados()
    {
        Console.Clear();
        Console.WriteLine(" LISTADO DE EMPLEADOS REGISTRADOS");

        // Verificamos si hay empleados en la lista
        if (empleados.Count == 0)
        {
            Console.WriteLine("No hay empleados registrados.");
        }
        else
        {
            // Recorremos la lista de empleados y mostramos cada uno
            for (int i = 0; i < empleados.Count; i++)
            {
                // POLIMORFISMO Llamamos a ToString que mostrara la informacion diferente
                // segun el tipo de empleado
                Console.WriteLine($"[{i + 1}] {empleados[i]}");

                // POLIMORFISMO Llamamos a Ingresos que calcula diferente segun el tipo
                // de empleado, Cada clase tiene su propia forma de calcular ingresos
                Console.WriteLine($"    Ingresos semanales: {empleados[i].Ingresos():C}\n");
            }
        }

        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey();
    }

    // Metodo para generar un reporte con el total de la nómina semanal
    private static void GenerarReporte()
    {
        Console.Clear();
        Console.WriteLine("REPORTE SEMANAL DE NOMINA");

        if (empleados.Count == 0)
        {
            Console.WriteLine("No hay empleados registrados.");
        }
        else
        {
            // Variable para acumular el total de ingresos de todos los empleados
            decimal totalNomina = 0;

            // Iteramos sobre cada empleado en la lista
            foreach (var emp in empleados)
            {
                // POLIMORFISMO Llamamos a Ingresos que calcula diferente para cada tipo
                // Si es EmpleadoAsalariado, calcula un tipo de ingreso
                // Si es EmpleadoPorHoras, calcula otro tipo
                // Si es EmpleadoPorComision, calcula otro tipo, etc.
                decimal ingresos = emp.Ingresos();
                totalNomina += ingresos;

                // ENCAPSULACION Accedemos a las propiedades públicas del empleado
                // que están protegidas por encapsulación (son de solo lectura)
                Console.WriteLine($"{emp.PrimerNombre} {emp.ApellidoPaterno}");
                Console.WriteLine($"  SS: {emp.NumeroSeguroSocial}");
                Console.WriteLine($"  Ingresos: {ingresos:C}\n");
            }

            // Mostramos el total de la nómina y estadísticas
            Console.WriteLine($"TOTAL NÓMINA SEMANAL: {totalNomina:C}");
            Console.WriteLine($"Cantidad de empleados: {empleados.Count}");
            Console.WriteLine($"Promedio por empleado: {(empleados.Count > 0 ? totalNomina / empleados.Count : 0):C}");
        }

        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey();
    }

    // Metodo para actualizar los datos de un empleado existente
    private static void ActualizarEmpleado()
    {
        Console.Clear();
        Console.WriteLine(" ACTUALIZAR EMPLEADO");

        if (empleados.Count == 0)
        {
            Console.WriteLine("No hay empleados registrados.");
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
            return;
        }

        // Mostrar lista de empleados para elegir cual actualizar
        for (int i = 0; i < empleados.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {empleados[i].PrimerNombre} {empleados[i].ApellidoPaterno}");
        }

        Console.Write("\nCual deseas actualizar? (numero): ");
        if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= empleados.Count)
        {
            // Restamos 1 porque los arrays comienzan en 0
            indice--;
            var emp = empleados[indice];

            Console.WriteLine($"\nEmpleado actual: {emp.PrimerNombre} {emp.ApellidoPaterno}\n");

            // POLIMORFISMO: Aqui usamos is para verificar el tipo real del objeto
            // Dependiendo de si es EmpleadoAsalariado, EmpleadoPorHoras, etc
            // haremos una actualización diferente

            if (emp is EmpleadoAsalariado empAsalariado)
            {
                // Si es un EmpleadoAsalariado, actualizamos su SalarioSemanal
                // Este metodo pertenece a la clase EmpleadoAsalariado
                Console.Write("Nuevo salario semanal?: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal nuevoSalario))
                {
                    empAsalariado.SalarioSemanal = nuevoSalario;
                    Console.WriteLine($" Salario actualizado a: {empAsalariado.SalarioSemanal:C}");
                }
            }
            else if (emp is EmpleadoPorHoras empHoras)
            {
                // Si es un EmpleadoPorHoras, actualizamos sus propiedades Sueldo y Horas
                // Estas propiedades pertenecen a la clase EmpleadoPorHoras
                Console.Write("Nuevo sueldo por hora?: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal nuevoSueldo))
                {
                    empHoras.Sueldo = nuevoSueldo;
                    Console.Write("Nuevas horas trabajadas?: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal nuevasHoras))
                    {
                        empHoras.Horas = nuevasHoras;
                        Console.WriteLine(" Datos actualizados.");
                    }
                }
            }
            else if (emp is EmpleadoBaseMasComision empBase)
            {
                // Si es un EmpleadoBaseMasComision, tenemos más opciones de actualización
                // porque esta clase tiene propiedades que heredan de su padre VentasBrutas
                // y sus propias propiedades SalarioBase
                Console.WriteLine("Que deseas actualizar?");
                Console.WriteLine("1. Salario base");
                Console.WriteLine("2. Ventas brutas");
                Console.Write("Opcion: ");
                string opcion = Console.ReadLine() ?? "";

                if (opcion == "1")
                {
                    Console.Write("Nuevo salario base?: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal nuevoBase))
                    {
                        // Actualizamos la propiedad SalarioBase de EmpleadoBaseMasComision
                        empBase.SalarioBase = nuevoBase;
                        Console.WriteLine($" Salario base actualizado.");
                    }
                }
                else if (opcion == "2")
                {
                    Console.Write("Nuevas ventas brutas?: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal nuevasVentas))
                    {
                        // Actualizamos la propiedad VentasBrutas que hereda de EmpleadoPorComision
                        empBase.VentasBrutas = nuevasVentas;
                        Console.WriteLine($" Ventas actualizadas.");
                    }
                }
            }
            else if (emp is EmpleadoPorComision empComision)
            {
                // Si es un EmpleadoPorComision pero no es BaseMasComision,
                // actualizamos VentasBrutas y TarifaComision
                Console.WriteLine("Que deseas actualizar?");
                Console.WriteLine("1. Ventas brutas");
                Console.WriteLine("2. Tarifa de comision");
                Console.Write("Opcion: ");
                string opcion = Console.ReadLine() ?? "";

                if (opcion == "1")
                {
                    Console.Write("Nuevas ventas brutas?: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal nuevasVentas))
                    {
                        // Actualizamos la propiedad VentasBrutas de EmpleadoPorComision
                        empComision.VentasBrutas = nuevasVentas;
                        Console.WriteLine($" Ventas actualizadas.");
                    }
                }
                else if (opcion == "2")
                {
                    Console.Write("Nueva tarifa de comision?: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal nuevaTarifa))
                    {
                        // Actualizamos la propiedad TarifaComision de EmpleadoPorComision
                        empComision.TarifaComision = nuevaTarifa;
                        Console.WriteLine($" Tarifa actualizada.");
                    }
                }
            }

            // POLIMORFISMO Llamamos a Ingresos que calculará los nuevos ingresos
            // El metodo se ejecutará segun el tipo real del empleado
            Console.WriteLine($"Nuevos ingresos: {emp.Ingresos():C}");
        }
        else
        {
            Console.WriteLine("\n Indice no valido.");
        }

        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey();
    }

    // Metodo para eliminar un empleado de la nomina
    private static void EliminarEmpleado()
    {
        Console.Clear();
        Console.WriteLine(" ELIMINAR EMPLEADO");

        if (empleados.Count == 0)
        {
            Console.WriteLine("No hay empleados registrados.");
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
            return;
        }

        // Mostrar la lista de empleados disponibles para eliminar
        for (int i = 0; i < empleados.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {empleados[i].PrimerNombre} {empleados[i].ApellidoPaterno}");
        }

        Console.Write("\nCual deseas eliminar? (numero): ");
        if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= empleados.Count)
        {
            // Restamos 1 porque los arrays comienzan en 0
            indice--;
            var emp = empleados[indice];

            // Pedimos confirmación antes de eliminar
            Console.Write($"\nEstas seguro de eliminar a {emp.PrimerNombre} {emp.ApellidoPaterno}? (s/n): ");
            if (Console.ReadLine()?.ToLower() == "s")
            {
                // Eliminamos el empleado de la lista
                empleados.RemoveAt(indice);
                Console.WriteLine(" Empleado eliminado correctamente.");
            }
        }
        else
        {
            Console.WriteLine("\n Indice no valido.");
        }

        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey();
    }
}