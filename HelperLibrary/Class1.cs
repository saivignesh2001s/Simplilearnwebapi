using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace HelperLibrary
{
    public class schoolsmethod
    {
        schoolsEntities context = null;
        public schoolsmethod()
        {
            context = new schoolsEntities();
        }
        public bool addstudent(student p)
        {
            try
            {
                context.students.Add(p);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }


        }
        public bool updatestudent(int id,student p)
        {
            try
            {
                List<student> k1 = context.students.ToList();
                student k = k1.Find(p1=>p1.studid==id);
                k.studid = p.studid;
                k.studname = p.studname;
                k.marks = p.marks;
                k.subjects = p.subjects;
                context.SaveChanges();
                return true;

            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public student findstudent(int id)
        {
            List<student> k1 = context.students.ToList();
            student k = k1.Find(p => p.studid == id);
            return k;

        }
        public List<student> getstudents()
        {
            return context.students.ToList();
        }
        public bool deletestudent(int id)
        {
            try
            {
                List<student> k1 = context.students.ToList();
                student k = k1.Find(p => p.studid == id);
                context.students.Remove(k);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}
