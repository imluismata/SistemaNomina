
namespace SistemaNomina;

/// <summary>
/// Clase abstracta que define la estructura base de todos los tipos de empleados.
/// PILAR POO - ABSTRACCIÓN: Define la interfaz común para todos los empleados,
/// especificando qué datos y comportamientos deben tener. Usa métodos abstractos
/// para obligar a las subclases a implementar el cálculo de ingresos específico de cada tipo.
/// 
/// PILAR POO - HERENCIA: Las subclases (EmpleadoAsalariado, EmpleadoPorHoras, etc.)
/// heredan los atributos comunes (nombre, apellido, seguro social) y métodos base.
/// </summary>
public abstract class Empleado {
    private string _primerNombre;
    private string _apellidoPaterno;
    private string _numeroSeguroSocial;

    /// <summary>
    /// Constructor base para inicializar datos comunes de todo empleado.
    /// </summary>
    /// <param name="primerNombre">Primer nombre del empleado</param>
    /// <param name="apellidoPaterno">Apellido paterno del empleado</param>
    /// <param name="numeroSeguroSocial">Número de seguro social (identificador único)</param>
    public Empleado (string primerNombre, string apellidoPaterno, string numeroSeguroSocial)
    {
        _primerNombre = primerNombre;
        _apellidoPaterno = apellidoPaterno;
        _numeroSeguroSocial = numeroSeguroSocial;
    }


    // PROPIEDADES CON ENCAPSULACIÓN
    // PILAR POO - ENCAPSULACIÓN: Expone los datos privados a través de propiedades de solo lectura.
    // Esto permite acceso controlado sin posibilidad de modificación desde fuera de la clase,
    // garantizando que estos valores no cambien después de la inicialización del empleado.

    /// <summary>
    /// Obtiene el primer nombre del empleado.
    /// </summary>
    public string PrimerNombre
    {
        // PILAR POO - ENCAPSULACIÓN: Propiedad solo de lectura (get sin set)
        // Previene cambios no controlados en el nombre del empleado.
        get { return _primerNombre; }
    }


    /// <summary>
    /// Obtiene el apellido paterno del empleado.
    /// </summary>
    public string ApellidoPaterno
    {
        // PILAR POO - ENCAPSULACIÓN: Propiedad solo de lectura (get sin set)
        // El apellido se asigna solo en el constructor y no puede cambiar después.
        get { return _apellidoPaterno; }
    }

    /// <summary>
    /// Obtiene el número de seguro social del empleado.
    /// </summary>
    public string NumeroSeguroSocial
    {
        // PILAR POO - ENCAPSULACIÓN: Propiedad solo de lectura
        // Protege este identificador único del empleado.
        get { return _numeroSeguroSocial; }
    }


    /// <summary>
    /// Retorna la representación en texto del empleado con sus datos básicos.
    /// PILAR POO - POLIMORFISMO: Las subclases sobrescriben este método para incluir
    /// información específica de cada tipo de empleado (salario, horas, etc.).
    /// </summary>
    public override string ToString()
    {
        return $"{PrimerNombre} {ApellidoPaterno}\nNúmero de seguro social: {NumeroSeguroSocial}";
    }

    /// <summary>
    /// Método abstracto que calcula los ingresos semanales del empleado.
    /// PILAR POO - ABSTRACCIÓN: Define un contrato que todas las subclases deben cumplir.
    /// Cada tipo de empleado implementa este método de forma diferente según su tipo de compensación.
    /// 
    /// PILAR POO - POLIMORFISMO: Permite que cada subclase proporcione una implementación
    /// específica del cálculo de ingresos, sin que el código cliente necesite conocer
    /// el tipo exacto de empleado.
    /// </summary>
    /// <returns>Decimal representando los ingresos semanales</returns>
    public abstract decimal Ingresos();

}
