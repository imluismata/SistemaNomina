namespace SistemaNomina;

/// <summary>
/// Clase que representa un empleado asalariado con comisión adicional.
/// PILAR POO - HERENCIA: Extiende de EmpleadoPorComision, heredando la funcionalidad
/// de cálculo de comisiones y añadiendo un salario base fijo.
/// 
/// PILAR POO - POLIMORFISMO: Sobrescribe el método Ingresos() para proporcionar
/// una fórmula específica que combina salario base, comisión y bono.
/// </summary>
public class EmpleadoBaseMasComision : EmpleadoPorComision
{
    private decimal _salarioBase;

    /// <summary>
    /// Constructor que inicializa un empleado asalariado con comisión.
    /// </summary>
    public EmpleadoBaseMasComision(string primerNombre, string apellidoPaterno,
        string numeroSeguroSocial, decimal ventasBrutas, decimal tarifaComision, decimal salarioBase)
        : base(primerNombre, apellidoPaterno, numeroSeguroSocial, ventasBrutas, tarifaComision)
    {
        _salarioBase = salarioBase;
    }

    // PILAR POO - ENCAPSULACIÓN: Propiedad con validación para el salario base.
    // Permite lectura y escritura controlada (RF-3 del SRS: actualizar información).
    public decimal SalarioBase
    {
        get
        {
            return _salarioBase;
        }
        set
        {
            _salarioBase = ( value >= 0 ) ? value : 0; // validación
        }
    }

    /// <summary>
    /// Calcula los ingresos semanales del empleado asalariado por comisión.
    /// Fórmula según SRS: (ventasBrutas × tarifaComision) + salarioBase + (salarioBase × 0.10)
    /// Esta incluye el salario base más un bono del 10% sobre el salario base.
    /// PILAR POO - POLIMORFISMO: Sobrescribe el método Ingresos() de la clase base (EmpleadoPorComision)
    /// para proporcionar un cálculo específico para este tipo de empleado.
    /// </summary>
    /// <returns>Decimal con el total de ingresos semanales</returns>
    public override decimal Ingresos()
    {
        // Calcula comisión sobre ventas brutas + salario base + 10% del salario base (bono)
        // base.Ingresos() retorna: ventasBrutas × tarifaComision (herencia de EmpleadoPorComision)
        return base.Ingresos() + SalarioBase + (SalarioBase * 0.10M);
    }

    /// <summary>
    /// Retorna la representación en texto del empleado asalariado con comisión.
    /// PILAR POO - POLIMORFISMO: Sobrescribe ToString() para mostrar información
    /// específica de este tipo de empleado incluyendo el salario base.
    /// </summary>
    public override string ToString()
    {
        return string.Format("empleado por comisión con salario base: {0}\n{1}: {2:C}",
            base.ToString(), "salario base", SalarioBase);
    }
}
