namespace SistemaNomina;

// Esta clase extiende de la clase abstracta Empleado
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
    public decimal SalarioSemanal
    {
        get { return _salarioSemanal; }
        set
        {
            _salarioSemanal = ( ( value >= 0 ) ? value : 0 ); // validación
        }
        
        
    }

    public override decimal Ingresos()
    {
        return SalarioSemanal;
    }

    public override string ToString()
    {
        return string.Format("empleado asalariado: {0}\n{1}: {2:C}",
            base.ToString(), "salario semanal", SalarioSemanal);
    }
}