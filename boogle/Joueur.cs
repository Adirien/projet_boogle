public class Joueur{


    private string pseudo;
    public string Pseudo
    {
        get{return pseudo;}
    }

    private int score;
    public int Score
    {
        get{return score;}
        set{score=value;}
    }

    private int numeroTour;  

    public int NumeroTour
    {
        get {return numeroTour;} 
        set {numeroTour = value;
            motsTrouves[numeroTour] = new List<string>();
        }
    }

    /// <summary>
    /// attribut qui pour chaque tour de la partie (la clé du dico) donne la liste des mots trouvés par le jour
    /// </summary>
    private Dictionary<int,List<string>>? motsTrouves; //= new Dictionary<int, List<string>>();
    

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

    /// <summary>
    /// On renvoie la liste contenant les mots trouvés 
    /// durant le tour en cours
    /// </summary>
    /// <returns> La Liste des mots
    /// </returns>
    public string AfficherListTourEncours(){
        string s = "";
        foreach(string mot in this.motsTrouves[this.numeroTour])
        {

            s += mot+" ";
        }
        return s;
    }

    public string toString() { 
        string s = String.Format("Le joueur {0} a {1} points.\n",this.pseudo,this.score);
        foreach (int num_tour in this.motsTrouves.Keys){
            List<string> l_mots_trouves = this.motsTrouves[num_tour];
            string  mots = "";
            foreach (string mot in l_mots_trouves)
            {
                mots += String.Format("{0},", mot);
            }
            // on enleve le dernier caractere car il s'agit d'une virgule
            if (mots != ""){
                mots = mots[0..^1];
            }
            
            s += String.Format("le tour n° {0} contient les mots [{1}] ",num_tour,mots);
        }
        return s;
    }

}