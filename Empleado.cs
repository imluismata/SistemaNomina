
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

    
    // propiedades 
    
    // con esta propiedad de solo lectura, obtenemos el nombre del empleado
    public string PrimerNombre
    {
        get { return _primerNombre; }
        
    }
    
    
    // Con esta propiedad que es de solo lectura, obtenemos el apellido del empleado
    public string ApellidoPaterno
    {
        get { return _apellidoPaterno; }
        
    }
    
    // Con esta propiedad de solo lectura, obtenemos el Seguro social del empleado
    public string NumeroSeguroSocial
    {
        get { return _numeroSeguroSocial; }
        
    }

    
    // Esto es para imprimir el nombre del empleado, su apellido y su numero de seguro social
    public override string ToString()
    {
        return $"{PrimerNombre} {ApellidoPaterno}\nNúmero de seguro social: {NumeroSeguroSocial}";

    }
    
    // metodo abstracto definido en la clase Empleado,
    // que se implementara en las clases derivadas,
    // para calcular los ingresos de cada tipo de empleado
    public abstract decimal Ingresos();
    
}