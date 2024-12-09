using System;
using System.IO.Pipelines;

namespace boogle;

public class DicoLangueV2
{

    //la langue choisie par les joueurs
    private string langue = "";

    //on stocke le fichier contenant les mots du fichier motspossibles dans un dictionnaire
    //la clé est la longeur des mots
    //la valeur est une liste de mots ayant tous la meme taille
    private Dictionary<int,List<string>> dicolangue;
    public Dictionary<int,List<string>> dico_langue 
    {
       get { return dicolangue; }
    }

    private int indexLongueurMot = -1;
    private int[]? innerTab = null;

    public DicoLangueV2(string langue){
        this.langue = langue;
        this.dicolangue = new Dictionary<int,List<string>>();
        this.lireFichier();

    }

    
    private void lireFichier(){
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
    }//fin lire fichier


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
            
            s = s + ("il y a " + quantite + " mots de taille " + taille + "  dans la langue " + this.langue+"\n");
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


   

}//fin de class 
