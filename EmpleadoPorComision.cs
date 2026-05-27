namespace SistemaNomina;

public class EmpleadoPorComision : Empleado
{

    private decimal _tarifaComision;
    private decimal _ventasBrutas;

    public EmpleadoPorComision(string primerNombre, string apellidoPaterno,
        string numeroSeguroSocial, decimal ventasBrutas, decimal tarifaComision)
        : base(primerNombre, apellidoPaterno, numeroSeguroSocial)
    {
        _ventasBrutas = ventasBrutas;
        _tarifaComision = tarifaComision;
    }


    public decimal TarifaComision
    {
        get
        {
            return _tarifaComision;
        }
        set
        {

            _tarifaComision = (value > 0 && value < 1) ? value : 0; // validación
        }

    }

    public decimal VentasBrutas
    {
        get
        {
            return _ventasBrutas;
        }
        set
        {
            _ventasBrutas = (value >= 0) ? value : 0; 
        }
    }

    public override decimal Ingresos()
    {
        return TarifaComision * VentasBrutas;
    }


    public override string ToString()
    {
        return string.Format("empleado por comisión: {0}\n{1}: {2:C}; {3}: {4:F2}", 
            base.ToString(), "tarifa de comisión", TarifaComision, "ventas brutas", VentasBrutas);
    }
}
