using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Passenger
    {
        //Properties 
        
        //public int PassengerId { get; set; } //hethi nhotouha en commentaire bech el migration tetada bech madech ichoufha hiya cle primaire iwali ichou passeport number kima ahna zedneh 

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date,ErrorMessage ="Invalid date")]

        public DateTime BirthDate { get; set; }
        [Key]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "PassportNumber doit avoir exactement 7 caractères.")]
        public string PassportNumber { get; set; }

        [EmailAddress(ErrorMessage = "Adresse email invalide.")]
        public string EmailAddress { get; set; }

        [StringLength(25, MinimumLength = 3, ErrorMessage = "FirstName doit avoir entre 3 et 25 caractères.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Phone(ErrorMessage = "Numéro de téléphone invalide.")]
        public string TelNumber { get; set; }
        public int Age { get; set; }
        /*public int Age { get {
                int age = 0;
                age = DateTime.Now.Year - BirthDate.Year;
                if (DateTime.Now.DayOfYear < BirthDate.DayOfYear)
                    age--;
                return age;

            }
        }*/
        //Passenger peut avoir  une liste de flight : proprietes de navigation
        public IList<Flight> Flights { get; set; }
        /* 
         * IList => interface c'est un contrat pour garantir statbilite les entites
         * ki bech yahkiw mabathhom yahkiw via des interfaces khater liste inajem yetbadel fiha barcha hajet 

         */

        //Methode qui permet de checker profile du passenger 
        public bool CheckProfile(string firstname , string lastname)
        {
            return this.FirstName == firstname && this.LastName == lastname;
        }

       /* 
        public bool CheckProfile(string firstName, string lastName, string email)
        {
            return this.FirstName == firstName && this.LastName == lastName && this.EmailAddress == email;
        }
       */

        //Methode qui remplace les deux autres methodes : houni email wala optionnel ken dakhlou il teste ala 3 attributs sn ken madakhlech il test 2attribut barka  
        public bool CheckProfile(string firstName, string lastName, string email = null)
        {
            if (email == null)
            {
               return  this.FirstName == firstName && this.LastName == lastName;
            }
            return this.FirstName == firstName && this.LastName == lastName && this.EmailAddress == email;


        }

        //Methode qui permet de savoir l'identité du passenger 
        public virtual string GetPassengerType() 
        {
            return "I am a passenger";
        }

        //Methode parreil lel methode el foukania mais elle est deconseille khater de un lezem passenger nhotou lekher vu que traveller w staff deja houwa passenger en plus cette methode n'est pas considérer comme orienté objet khater if else barcha code mais lwech namel fil les classes w el heritage 
        public string GetPassengerType2()
        {
            if (this is Traveller)
                return "I am a traveller";
            if (this is Staff)
                return "I am a passenger , I am a staff";
            return "I am a passenger";
        }

        //Calculer age a partir de BirthDate 
        //Methode 1 : Bech tekbel birth date w variable a partir mil birth date bech tcalcul lomer w tafectih lel calculatedage 
        public void GetAge(DateTime birthDate, ref int calculatedAge)
        {

            calculatedAge = DateTime.Now.Year - birthDate.Year; // houni par exemple 2000 W 2025 => 25ANS 
            if (DateTime.Now.DayOfYear < birthDate.DayOfYear)  //Day of year tatini el rond ta nhar fil am 1-> 365/366 ronf taa lyouma 34 par exemple w houwa mawloud fi 23MARS par exemple Day of year teou iji 82 nhar ken talkaha akal tnakess khater mezel mawslech
                calculatedAge --; 
        }
        //Methode 2 : Tekhdem al passenger bech tehsseb lomer teou w thot age fil propietes age 
        public void GetAge(Passenger passenger)
        {
            passenger.Age = DateTime.Now.Year - passenger.BirthDate.Year;
            if(DateTime.Now.DayOfYear < passenger.BirthDate.DayOfYear) 
                passenger.Age --;

        }

        public override string ToString()
        {
            return
                $"Passenger: {FirstName} {LastName}, " +
                $"Email: {EmailAddress}, " +
                $"Telphone Number: {TelNumber}, " +
                $"Passport Number: {PassportNumber}, " +
                $"Birth Date: {BirthDate.ToShortDateString()}";
        }
    }
}
