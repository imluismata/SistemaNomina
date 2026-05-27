namespace SistemaNomina;

/// <summary>
/// Clase que representa un empleado asalariado (sueldo fijo semanal).
/// PILAR POO - HERENCIA: Extiende de la clase abstracta Empleado,
/// heredando datos comunes (nombre, apellido, seguro social) y obligando
/// a implementar el método abstracto Ingresos() para este tipo específico.
/// </summary>
public class EmpleadoAsalariado : Empleado
{

    private decimal _salarioSemanal;
    
    // Constructor con 4 parámetros
    public EmpleadoAsalariado(string primerNombre, string apellidoPaterno,
        string numeroSeguroSocial, decimal salarioSemanal)
        : base(primerNombre, apellidoPaterno, numeroSeguroSocial)
    {                 
        _salarioSemanal = salarioSemanal; 
    }

    // Propiedad pública
    // PILAR POO - ENCAPSULACIÓN: Protege el dato privado _salarioSemanal con acceso controlado.
    // El getter permite lectura, y el setter permite escritura con validación (RF-3 del SRS).
    public decimal SalarioSemanal
    {
        get { return _salarioSemanal; }
        set
        {
            // Validación: rechaza valores negativos, asignando 0 en su lugar.
            // Mantiene la integridad de los datos del empleado.
            _salarioSemanal = ( ( value >= 0 ) ? value : 0 ); 
        }
    }

    /// <summary>
    /// Calcula los ingresos semanales del empleado asalariado.
    /// PILAR POO - POLIMORFISMO: Implementa el método abstracto Ingresos() de la clase base.
    /// Para empleados asalariados, el cálculo es simple: ingresos = salario semanal.
    /// </summary>
    /// <returns>Decimal con el salario semanal del empleado</returns>
    public override decimal Ingresos()
    {
        return SalarioSemanal;
    }

    /// <summary>
    /// Retorna la representación en texto del empleado asalariado.
    /// PILAR POO - POLIMORFISMO: Sobrescribe ToString() para mostrar información
    /// específica de un empleado asalariado (incluye salario semanal).
    /// </summary>
    public override string ToString()
    {
        return string.Format("empleado asalariado: {0}\n{1}: {2:C}",
            base.ToString(), "salario semanal", SalarioSemanal);
    }
}