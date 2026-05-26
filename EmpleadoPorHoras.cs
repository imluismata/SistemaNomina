namespace SistemaNomina;

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
        get
        {
            return _sueldo;
        }
        set
        {
            _sueldo = ( value >= 0 ) ? value : 0;
        }
    }

    public decimal Horas
    {

        get
        {
            return _horas;
        }
        set
        {
            _horas = ( ( value >= 0 ) && ( value <= 168 ) ) ?
                 value : 0; //
        }
    }
    
    public override decimal Ingresos()
    {
        if (Horas <= 40)
        {
            return Sueldo * Horas;
        }
        else
        {
            return ( 40 * Sueldo ) + ( ( Horas - 40 ) * Sueldo * 1.5M );
        }
    }

    public override string ToString()
    {
        return string.Format("empleado por horas: {0}\n{1}: {2:C}; {3}: {4:F2}", 
            base.ToString(), "sueldo por hora", Sueldo, "horas trabajadas", Horas);
            
    }
}