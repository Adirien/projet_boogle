using System;

namespace boogle;

public class Dicolangue
{

    private Dictionary<int, List<string>> dicolangue;

    private string langue;
    public Dictionary<int,List<string>> DicoLangue
    {
        get { return dicolangue; }
    }
    
    //index du tableau contenant la longueur des mots
    private int indexLongueurMot = -1;

    // tableau provenant de la list contenant les keys du dictionnaire dicolangue
    private int[]? innerTab = null;
    public Dicolangue(string langue)
    {
        this.dicolangue = new Dictionary<int,List<string>>();
        this.langue = langue;
        this.Liretxt();

    }

    private void Liretxt()  //STOCKER DANS UN DICO PAR TAILLE DE MOTS
    {
        string? nomFichier;

        //en fonction de la langue choisie on va ouvrir le fichier correspondant
        if (this.langue == "FR")
        {
            nomFichier = "MotsPossiblesFR.txt";
        }
        else 
        {
            nomFichier = "MotsPossiblesEn.txt";
        }    

        try
        {
            string line;
            StreamReader sr = new StreamReader(nomFichier);                
            line = sr.ReadLine();
            
            while (line != null)
            {

                
                string[] arr = line.Split(' ');
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(arr[i])) // je verifie que le mot en question existe bien et ne soit pas vide car sinon dans ma liste je risque dajouter quelque chose de vide ce qui est genant
                    {
                        int taillemot = arr[i].Length;
                        if (this.dicolangue.ContainsKey(taillemot)) //si la taille du mot existe deja alors ajoute a la liste
                        {
                            this.dicolangue[taillemot].Add(arr[i]);
                        }
                        else
                        {
                            List<string> list = new List<string>() { arr[i] }; // si la taille existe pas, ajouter une key associee a une liste
                            this.dicolangue.Add(taillemot, list);
                        }
                    }
                }
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();
        }
        catch (Exception ex)
        {
           Console.WriteLine("Exception: " + ex.Message); 
        }
        // on cree le tableau issu de la liste des clés  du dictionnaire
        this.innerTab = this.dicolangue.Keys.ToArray();
    }//fin Liretxt

    public bool Verifier(string mot)  // je verifier dans la liste associe a la taille du mot si on retrouve bien le mot 
    {
        
        int taille=mot.Length;
        if (this.dicolangue.ContainsKey(taille))
        {
            List<string> liste= dicolangue[taille];
            int longueur=liste.Count;
            for (int i = 0;i < longueur;i++)
            {
                if (liste[i].ToLower()==mot)
                {
                    return true;
                    
                }


            }

            
        }
        return false;
    }

    public bool RechDichoRecursif(string mot)
    {   
        string motMajuscule = mot.ToUpper();
        if (this.indexLongueurMot == -1){
            
            this.indexLongueurMot = 0;
        }
        if (this.indexLongueurMot>= this.innerTab.Length){            
            this.indexLongueurMot = -1;
            return false;
        }
        else
        {
            if(this.dicolangue[this.innerTab[this.indexLongueurMot]].Contains(motMajuscule)){
                this.indexLongueurMot = -1;
                return true;
            }
            else{
                this.indexLongueurMot +=1;
                return false | this.RechDichoRecursif(mot);

            }
           
        }
    }// fin RechDico


    public string toString()
    {
        string s = "";
        foreach(int taille in  this.dicolangue.Keys)
        {
            int quantite = this.dicolangue[taille].Count;
            
            s = s + ("il y a " + quantite + " mots de taille" + taille + "  dans la langue " + this.langue+"\n");
        }
        Dictionary<char,List<string>> ordrealpha=new Dictionary<char,List<string>>();
        foreach (List<string> ligne in this.dicolangue.Values)   // ici je vais creer une autre liste pour ranger les mots par ordre alaphabetique cest demande dans lennonce
        {
            foreach(string mot in ligne )
            {
                
                
                    char c = mot[0];
                    if (!ordrealpha.ContainsKey(c))
                    {
                        ordrealpha[c] = new List<string>();
                    }
                    ordrealpha[c].Add(mot);
            }
        }
        foreach (char  lettre in ordrealpha.Keys)
        {
            int quantite = ordrealpha[lettre].Count;            
            s = s + ("il y a " + quantite + " mots qui ont comme premiere lettre "+ lettre+ "  dans la langue " + this.langue + "\n");

        }

        return s;
    }
}

//}
