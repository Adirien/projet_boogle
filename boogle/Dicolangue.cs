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
    
    public string Langue
    { get { return langue; }
        set { langue = value; }
    }
    public Dicolangue(string langue)
    {
        this.dicolangue = new Dictionary<int,List<string>>();
        this.langue = langue;

    }

    public void Liretxt()  //STOCKER DANS UN DICO PAR TAILLE DE MOTS
    {
        if (this.langue=="francais"||this.langue=="french")
        {

            string line;
            try
            {
                ///Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("MotsPossiblesFR.txt");
                ///Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {

                    //write the line to console window
                    // Console.WriteLine('-'+line+'-');
                    string[] arr = line.Split(' ');
                    for (int i=0;i<arr.Length; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(arr[i]))
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
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

        }
        else
        {
            string line;
            try
            {
                
                StreamReader sr = new StreamReader("MotsPossiblesEN.txt");
                
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
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

        }
    }

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
