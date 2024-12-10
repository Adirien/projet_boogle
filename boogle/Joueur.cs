public class Joueur{


    private string pseudo="";
    public string Pseudo{get; set;}

    private int score;
    public int Score{get; set;}

    private int numeroTour;  

    public int NumeroTour{get; set;}

    /// <summary>
    /// attribut qui pour chaque partie(la clé du dico) donne la liste de s mots trouvés par le jour
    /// </summary>
    private Dictionary<int,List<string>>? motsTrouves; //= new Dictionary<int, List<string>>();
    //public Dictionary<int,List<string>> MotsTrouves{get; set;}

    public Joueur(string pseudo ){
        this.pseudo = pseudo;
        this.score = 0;
        this.numeroTour = 0;
        this.motsTrouves = new Dictionary<int, List<string>>();


    }

    public bool Contains(string mot){
        return this.motsTrouves[this.numeroTour].Contains(mot);
    }

    public bool AddMot(string mot){
        if (! this.Contains(mot))
        {
            this.motsTrouves[this.numeroTour].Add(mot);
            return true;
        }
        return false;
    }

    public override string ToString() { 
       
        return String.Format("Le joueur {0} a {1} points",this.pseudo,this.score);
    }

}