using System;

namespace boogle;

public class Lettre
{
    private string symbole;//il s'agit du nombre de fois qu'il reste a Lettre d'etre utilise dans la generation du plateau

    // nombre de points que cette lettre apporte dans le mot trouvé      
    private int point;

    //fréquence d'apparition de la lettre dans l'alphabet(il s'agit d'un pourcentage)
    private int frequence;

    // nombre de fois que l'on doit voir cette lettre dans le plateau taillePlateau²*6
    private int nbApparition;
    //nombre de fois que l'on peut encore faire apparaitre la lettre dans differents dés

    
    
    public string Symbole
    {
        get{ return this.symbole;}
    }


    

    public int getPoint()
    {
        return this.point;
    }

    
    public int Frequence{
        get{ return frequence; }
        set{frequence = value;}
    }
    

    public int NbApparition{
        get{ return nbApparition;}
        set {nbApparition = value;}    
    }

    public void setNbTotalApparition(int nbTotalApparition)
    {
        this.nbApparition = nbTotalApparition;
    }


    
    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="symbole"></param>
    /// <param name="point"></param>
    /// <param name="frequence"></param>
    public Lettre(string symbole,int point,int frequence){
        this.symbole=symbole;
        this.point=point;
        this.frequence=frequence;
    }

    public string toString(){
        return String.Format("{0}-pt:{1} - f:{2} - nombre apparition: {3}",this.symbole,this.point,this.frequence,this.nbApparition);
    }
   

}//fin class
