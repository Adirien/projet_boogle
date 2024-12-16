using System;

namespace boogle;

/// <summary>
/// Classe qui simule un sblier
/// 
/// </summary>
public class Sablier
{

    private DateTime startDateTime;
    private TimeSpan timeSpan;
    private DateTime endDateTime;
    private DateTime currentTime;

    public Sablier(int secondes)
    {
        timeSpan = new TimeSpan(0, 0,secondes);
    }

    /// <summary>
    /// on recupure le moment où le tour commence
    /// on ajoute la duree du tour : timeSpan
    /// </summary>
    public void Start()
    {
        //moment ou le tour debute
        startDateTime = DateTime.Now;
        // moment où le tour s'arrete 
        endDateTime = startDateTime.Add(timeSpan);
    }

    /// <summary>
    /// On s'informe si le temps s'ecoule encore ou pas.
    /// 
    /// </summary>
    /// <returns>
    /// True --> il reste du temps au chronometre
    /// False --> le temps est terminé
    /// </returns>
    public bool TempsSEcoule()
    {
        currentTime = DateTime.Now;
        return  currentTime<= endDateTime;    
    }

    public string toString()
    {
        TimeSpan interval = this.endDateTime - this.currentTime;
        return String.Format("{0}",interval.ToString());            
    }
}
