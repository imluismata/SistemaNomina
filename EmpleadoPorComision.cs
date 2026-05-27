namespace SistemaNomina;

/// <summary>
/// Clase que representa un empleado pagado por comisión sobre ventas.
/// PILAR POO - HERENCIA: Extiende de la clase abstracta Empleado,
/// heredando datos básicos y obligación de implementar Ingresos().
/// </summary>
public class EmpleadoPorComision : Empleado
{

    private decimal _tarifaComision;
    private decimal _ventasBrutas;

    /// <summary>
    /// Constructor que inicializa un empleado por comisión.
    /// </summary>
    public EmpleadoPorComision(string primerNombre, string apellidoPaterno,
        string numeroSeguroSocial, decimal ventasBrutas, decimal tarifaComision)
        : base(primerNombre, apellidoPaterno, numeroSeguroSocial)
    {
        _ventasBrutas = ventasBrutas;
        _tarifaComision = tarifaComision;
    }

    // PILAR POO - ENCAPSULACIÓN: Propiedad con validación.
    // La tarifa de comisión debe estar entre 0 y 1 (representando porcentajes).
    public decimal TarifaComision
    {
        get
        {
            return _tarifaComision;
        }
        set
        {
            // Validación: solo acepta valores entre 0 y 1
            _tarifaComision = (value > 0 && value < 1) ? value : 0; // validación
        }

    }

    // PILAR POO - ENCAPSULACIÓN: Propiedad con nombre en PascalCase según convenciones .NET.
    // Reemplaza la anterior "ventasBrutas" (camelCase) para mantener estándares de C#.
    public decimal VentasBrutas
    {
        get
        {
            return _ventasBrutas;
        }
        set
        {
            _ventasBrutas = (value >= 0) ? value : 0; // validación        }
        }
    }

    // PILAR POO - POLIMORFISMO: Este método sobrescribe (override) el método abstracto Ingresos()
    // definido en la clase base Empleado. Proporciona una implementación específica para 
    // calcular ingresos de empleados por comisión según la fórmula del SRS.
    public override decimal Ingresos()
    {
        // Fórmula SRS: ventasBrutas × tarifaComision
        return TarifaComision * VentasBrutas;
    }

    /// <summary>
    /// Retorna la representación en texto del empleado por comisión.
    /// PILAR POO - POLIMORFISMO: Sobrescribe ToString() para mostrar información
    /// relevante de este tipo de empleado (tarifa de comisión y ventas brutas).
    /// </summary>
    public override string ToString()
    {
        return string.Format("empleado por comisión: {0}\n{1}: {2:C}; {3}: {4:F2}", 
            base.ToString(), "tarifa de comisión", TarifaComision, "ventas brutas", VentasBrutas);
    }
}
