using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Kurs
{
    public enum typesDoc { Therapist, Pediatrician, Optometrist, Traumatologist, Psychiatrist };
    
    
    public abstract class Person
    {
        private string name; // имя человека
 
        public string Name
        {
            get
            {
                return name;
            }
        }
        public Person()
        {
            name = "None";
        }
        public Person(string name)
        {
            this.name = name;
        }
 
    }
 
    public class Doctor : Person
    {
        public typesDoc type; // тип доктора
        private LinkedList<Patient> patients = new LinkedList<Patient>();  // записанные пациенты на прием
 
        public Doctor() : base()
        {
            type = (typesDoc)0;
        }
 
        public Doctor(string name,typesDoc type) : base(name)
        {
            this.type = type;           
        }
 
        public void pushPatient(Patient patient)
        {
            if (patient.severityDisease <= 5)  // если тяжесть заболевания не превышает среднюю
                                              // то добавляем в конец очереди
            {
                patients.AddLast(patient);
            }
            else                             // иначе в начало
            {
                patients.AddFirst(patient);
            }
        }
        public bool isAvailable() 
        {
            return patients.Count() < 15;
        }
 
        public int queueSize() // возвращает количество человек в очереди
        {
            return patients.Count();
        }
    }
 
    public class Patient : Person
    {
        public int severityDisease;  // степень тяжести заболевания от 0 до 10
 
        public Patient() : base()
        {
            severityDisease = 0;
        }
 
        public Patient(string name, int severityDisease) : base(name)
        {
            if (severityDisease >= 0 && severityDisease <= 10) // если степень тяжести заболевания не выходит за рамки (0..10)
            { 
                this.severityDisease = severityDisease;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
 


 

    interface IAction
    {
        void appointmentTherapist(Patient patient);
        void appointmentPediatrician(Patient patient);
        void appointmentOptometrist(Patient patient);
        void appointmentTraumatologist(Patient patient);
        void appointmentPsychiatrist(Patient patient);
        
    }

    

    public class Polyclinic : IAction
    {
        
        LinkedList<Doctor> listDoctors = new LinkedList<Doctor>(); // список, который хранит в себе врачей поликлиники
 
        public Polyclinic(LinkedList<Doctor> doctors)
        {
            foreach (Doctor doctor in doctors)
            {
                listDoctors.AddLast(doctor);
            }
        }
 
        public void appointmentTherapist(Patient patient) // запись к терапевту
        {
            bool flag = true;
            // поиск нужного доктора, среди доступных
            foreach (Doctor doctor in listDoctors)
            {
                if (doctor.type == typesDoc.Therapist) // если тип врача совпал с нужным доктором,
                {                   // то, если к доктору не записано максимальное количество пациентов,
                    if (doctor.isAvailable()) // добавляем в очередь, иначе ищем нужного доктора дальше
                    {
                        flag = false;
                        doctor.pushPatient(patient);
                        Console.WriteLine($"{patient.Name} записан к терапевту.");
                        return;
                    }                  
                }
            }
            if (flag) // если очередь к доктору переполнена или он не вышел на работу
            {
                Console.WriteLine($"На данный момент нет возможности для записи к терапевту для пациента: {patient.Name}");
            }
        }
         public void appointmentPediatrician(Patient patient) // запись к педиатру
        {
            bool flag = true;
            foreach (Doctor doctor in listDoctors)
            {
                if (doctor.type == typesDoc.Pediatrician)
                {
                    if (doctor.isAvailable())
                    {
                        flag = false;
                        doctor.pushPatient(patient);
                        Console.WriteLine($"{patient.Name} записан к педиатру.");
                        return;
                    }
                }
            }
            if (flag)
            {
                Console.WriteLine($"На данный момент нет возможности для записи к педиатру для пациента: {patient.Name}");
            }
        }
         public void appointmentOptometrist(Patient patient)
        {
            bool flag = true;
            foreach (Doctor doctor in listDoctors)
            {
                if (doctor.type == typesDoc.Optometrist)
                {
                    if (doctor.isAvailable())
                    {
                        flag = false;
                        doctor.pushPatient(patient);
                        Console.WriteLine($"{patient.Name} записан к окулисту.");
                        return;
                    }
                    
                }
            }
            if (flag)
            {
                Console.WriteLine($"На данный момент нет возможности для записи к окулисту для пациента: {patient.Name}");
            }
        }
         public void appointmentTraumatologist(Patient patient)  // запись к травматологу
        {
            bool flag = true;
            foreach (Doctor doctor in listDoctors)
            {
                if (doctor.type == typesDoc.Traumatologist)
                {
                    if (doctor.isAvailable())
                    {
                        flag = false;
                        doctor.pushPatient(patient);
                        Console.WriteLine($"{patient.Name} записан к травматологу.");
                        return;
                    }
                }
            }
            if (flag)
            {
                Console.WriteLine($"На данный момент нет возможности для записи к травматологу для пациента: {patient.Name}");
            }
        }
         public void appointmentPsychiatrist(Patient patient) // запись к психотерапевту
        {
            bool flag = true;
            foreach (Doctor doctor in listDoctors)
            {
                if (doctor.type == typesDoc.Psychiatrist)
                {
                    if (doctor.isAvailable())
                    {
                        flag = false;
                        doctor.pushPatient(patient);
                        Console.WriteLine($"{patient.Name} записан к психиатру.");
                        return;
                    }                  
                }
            }
            if (flag)
            {
                Console.WriteLine($"На данный момент нет возможности для записи к психиатру для пациента: {patient.Name}");
            }
        }
        
 
        public void getAvailableDoctors()  // список врачей, который работают в данный момент
        {
            Console.WriteLine("Список доступных врачей:");
            foreach(Doctor doctor in listDoctors)
            {
                Console.WriteLine($"{doctor.type.ToString()}");
            }
        }
 
        public void numPatientsWaitingForDoc() // выводит количество пациентов в очереди к каждому врачу
        {
            Console.WriteLine("Список количества пациентов, которые находятся в очереди к каждому врачу:");
            foreach (Doctor doctor in listDoctors)
            {
                Console.WriteLine($"{doctor.type.ToString()}: {doctor.queueSize()}");
            }
        }
    }
}
