namespace SistemaNomina;


public class EmpleadoBaseMasComision : EmpleadoPorComision
{
    private decimal _salarioBase;

    public EmpleadoBaseMasComision(string primerNombre, string apellidoPaterno,
        string numeroSeguroSocial, decimal ventasBrutas, decimal tarifaComision, decimal salarioBase)
        : base(primerNombre, apellidoPaterno, numeroSeguroSocial, ventasBrutas, tarifaComision)
    {
        _salarioBase = salarioBase;
    }

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

    public override decimal Ingresos()
    {

        return base.Ingresos() + SalarioBase + (SalarioBase * 0.10M);
    }


    public override string ToString()
    {
        return string.Format("empleado por comisión con salario base: {0}\n{1}: {2:C}",
            base.ToString(), "salario base", SalarioBase);
    }
}
