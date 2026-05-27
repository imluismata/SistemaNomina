
namespace SistemaNomina;


public abstract class Empleado {
    private string _primerNombre;
    private string _apellidoPaterno;
    private string _numeroSeguroSocial;

    public Empleado (string primerNombre, string apellidoPaterno, string numeroSeguroSocial)
    {
        _primerNombre = primerNombre;
        _apellidoPaterno = apellidoPaterno;
        _numeroSeguroSocial = numeroSeguroSocial;
    }


    public string PrimerNombre
    {

        get { return _primerNombre; }
    }



    public string ApellidoPaterno
    {

        get { return _apellidoPaterno; }
    }


    public string NumeroSeguroSocial
    {

        get { return _numeroSeguroSocial; }
    }



    public override string ToString()
    {
        return $"{PrimerNombre} {ApellidoPaterno}\nNúmero de seguro social: {NumeroSeguroSocial}";
    }

    public abstract decimal Ingresos();

}
