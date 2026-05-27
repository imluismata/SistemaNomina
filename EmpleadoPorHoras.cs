namespace SistemaNomina;

/// <summary>
/// Clase que representa un empleado pagado por horas trabajadas.
/// PILAR POO - HERENCIA: Extiende de la clase abstracta Empleado,
/// heredando propiedades básicas (nombre, apellido, seguro social) y la
/// obligación de implementar el método Ingresos() según el tipo de empleado.
/// </summary>
public class EmpleadoPorHoras : Empleado
{
    private decimal _horas;
    private decimal _sueldo;
    
    public EmpleadoPorHoras(string primerNombre, string apellidoPaterno,
        string numeroSeguroSocial, decimal sueldo, decimal horas)
        : base(primerNombre, apellidoPaterno, numeroSeguroSocial)
    {
        _sueldo = sueldo;
        _horas = horas;
    }

    public decimal Sueldo
    {
        // PILAR POO - ENCAPSULACIÓN: El getter expone el dato privado _sueldo
        // de forma controlada, permitiendo solo lectura desde fuera de la clase.
        get
        {
            return _sueldo;
        }
        // PILAR POO - ENCAPSULACIÓN: El setter valida la entrada antes de asignar.
        // Esto previene que se asignen valores negativos, mantiendo la integridad de datos.
        set
        {
            _sueldo = ( value >= 0 ) ? value : 0;
        }
    }

    public decimal Horas
    {
        // PILAR POO - ENCAPSULACIÓN: Getter controlado para acceso al dato privado _horas
        get
        {
            return _horas;
        }
        // PILAR POO - ENCAPSULACIÓN: Setter con validación.
        // Asegura que las horas no sean negativas ni superen 168 horas semanales.
        set
        {
            _horas = ( ( value >= 0 ) && ( value <= 168 ) ) ?
                 value : 0; 
        }
    }
    
    /// <summary>
    /// Calcula los ingresos semanales del empleado por horas.
    /// PILAR POO - POLIMORFISMO: Sobrescribe el método abstracto Ingresos() de Empleado.
    /// Implementa la fórmula específica del SRS para empleados por horas:
    /// - Si horas ≤ 40: pago = sueldoPorHora × horas
    /// - Si horas > 40: pago = (sueldoPorHora × 40) + (sueldoPorHora × 1.5 × (horas - 40))
    /// </summary>
    /// <returns>Decimal con el total de ingresos semanales</returns>
    public override decimal Ingresos()
    {
        // Caso 1: Horas normales (hasta 40 horas)
        if (Horas <= 40)
        {
            return Sueldo * Horas;
        }
        // Caso 2: Horas extras (más de 40 horas)
        // Se pagan las primeras 40 horas a tarifa normal, y las extras a 1.5x (tiempo y medio)
        else
        {
            return ( 40 * Sueldo ) + ( ( Horas - 40 ) * Sueldo * 1.5M );
        }
    }

    /// <summary>
    /// Retorna la representación en texto del empleado por horas.
    /// PILAR POO - POLIMORFISMO: Sobrescribe ToString() para proporcionar una representación
    /// específica de este tipo de empleado, mostrando información relevante (sueldo/hora y horas trabajadas).
    /// </summary>
    public override string ToString()
    {
        return string.Format("empleado por horas: {0}\n{1}: {2:C}; {3}: {4:F2}", 
            base.ToString(), "sueldo por hora", Sueldo, "horas trabajadas", Horas);
    }
}