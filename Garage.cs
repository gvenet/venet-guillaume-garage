using System.Runtime.Serialization.Formatters.Binary;

namespace ft
{
    [Serializable]
    public class Garage
    {
        List<Moteur> moteurs = new List<Moteur>();

        public List<Moteur> Moteurs
        {
            get { return moteurs; }
        }

        List<Vehicule> vehicules = new List<Vehicule>();

        public List<Vehicule> Vehicules
        {
            get { return vehicules; }
            set { vehicules = value; }
        }

        List<Option> options = new List<Option>();

        public List<Option> Options
        {
            get { return options; }
            set { options = value; }
        }
        Utils utls = new Utils();
        Vehicule? current = null;

        public Vehicule Current
        {
            get { return current!; }
            set { current = value; }
        }

        public Garage() { }
        public void Afficher()
        {
            foreach (Vehicule vehicule in vehicules)
            {
                if (vehicule.GetType() == typeof(Moto))
                {
                    Moto? moto = vehicule as Moto;
                    if (moto != null)
                        moto.Afficher();
                    else
                        throw new ArgumentException(
                            "L'objet de type moto est null dans la liste de vehicules"
                        );
                }
                else if (vehicule.GetType() == typeof(Camion))
                {
                    Camion? camion = vehicule as Camion;
                    if (camion != null)
                        camion.Afficher();
                    else
                        throw new ArgumentException(
                            "L'objet de type camion est null dans la liste de vehicules"
                        );
                }
                else if (vehicule.GetType() == typeof(Voiture))
                {
                    Voiture? voiture = vehicule as Voiture;
                    if (voiture != null)
                        voiture.Afficher();
                    else
                        throw new ArgumentException(
                            "L'objet de type voiture est null dans la liste de vehicules"
                        );
                }
            }
        }
        public void AfficherMoto()
        {
            foreach (Vehicule vehicule in vehicules)
            {
                if (vehicule.GetType() == typeof(Moto))
                {
                    Moto? moto = vehicule as Moto;
                    if (moto != null)
                        moto.Afficher();
                    else
                        throw new ArgumentException(
                            "L'objet de type moto est null dans la liste de vehicules"
                        );
                }
            }
        }
        public void AfficherVoiture()
        {
            foreach (Vehicule vehicule in vehicules)
            {
                if (vehicule.GetType() == typeof(Voiture))
                {
                    Voiture? voiture = vehicule as Voiture;
                    if (voiture != null)
                        voiture.Afficher();
                    else
                        throw new ArgumentException(
                            "L'objet de type voiture est null dans la liste de vehicules"
                        );
                }
            }
        }
        public void AfficherCamion()
        {
            foreach (Vehicule vehicule in vehicules)
            {
                if (vehicule.GetType() == typeof(Camion))
                {
                    Camion? camion = vehicule as Camion;
                    if (camion != null)
                        camion.Afficher();
                    else
                        throw new ArgumentException(
                            "L'objet de type camion est null dans la liste de vehicules"
                        );
                }
            }
        }
        public void TrierVehicule()
        {
            vehicules.Sort(
                delegate (Vehicule A,Vehicule B)
                {
                    if (A != null && B != null)
                        return A.CompareTo(B);
                    else
                        throw new ArgumentException("Input de tri null");
                }
            );
        }

        public void AjouterMoteur(Moteur moteur)
        {
            moteurs.Add(moteur);
        }

        public void AjouterOption(Option option)
        {
            options.Add(option);
        }

        public void AjouterVehicule(Vehicule vehicule)
        {
            vehicules.Add(vehicule);
        }

        public void AfficherOptionsVehicule()
        {
            if (current == null)
                throw new Exception("Veuillez selectionner un vehicule");
            else
                current.AfficherOptions();
        }

        public void AfficherOptions()
        {
            foreach (Option option in options)
                option.Afficher();
        }

        public void AfficherMarques()
        {
            foreach (Marque marque in (Marque[])Enum.GetValues(typeof(Marque)))
            {
                Console.WriteLine(marque);
            }
        }

        public void AfficherTypesMoteurs()
        {
            foreach (TypeMoteur type in (TypeMoteur[])Enum.GetValues(typeof(TypeMoteur)))
            {
                Console.WriteLine(type);
            }
        }

        public void AfficherMoteurs()
        {
            foreach (Moteur moteur in moteurs)
                moteur.Afficher();
        }

        public void Enregistrer()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream? flux = null;
            try
            {
                flux = new FileStream("data.bin",FileMode.Create,FileAccess.Write);
                formatter.Serialize(flux,this);
                flux.Flush();
            }
            catch { }
            finally
            {
                if (flux != null)
                    flux.Close();
            }
        }
        public T Charger<T>()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream? flux = null;
            try
            {
                flux = new FileStream("data.bin",FileMode.Open,FileAccess.Read);
                return (T)formatter.Deserialize(flux);
            }
            catch
            {
                return default(T)!;
            }
            finally
            {
                if (flux != null)
                    flux.Close();
            }
        }
    }
}
