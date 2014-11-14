using UnityEngine;
using System.Collections;

// superclasse base
public abstract class Acao
{
    public float efeitoDestruir;
    public float efeitoSobreviver;
    public abstract void Executar();
}

public class Fugir : Acao
{
    public Fugir()
    {
        efeitoDestruir = -1f;
        efeitoSobreviver = 1f;
    }

    public override void Executar()
    {
        Debug.Log("fugir");
    }
}

public class Atirar : Acao
{
    public Atirar()
    {
        efeitoDestruir = 1f;
        efeitoSobreviver = 0.5f;
    }
    
    public override void Executar()
    {
        Debug.Log("atirar");
    }
}

public class FazerNada : Acao
{
    public FazerNada()
    {
        efeitoDestruir = 0f;
        efeitoSobreviver = 0f;
    }
    
    public override void Executar()
    {
        Debug.Log("fazer nada");
    }
}

public class Procurar : Acao
{
    public Procurar()
    {
        efeitoDestruir = 0.5f;
        efeitoSobreviver = -0.5f;
    }
    
    public override void Executar()
    {
        Debug.Log("procurar");
    }
}

public class Perseguir : Acao
{
    public Perseguir()
    {
        efeitoDestruir = 1f;
        efeitoSobreviver = -1f;
    }
    
    public override void Executar()
    {
        Debug.Log("Perseguir");
    }
}
