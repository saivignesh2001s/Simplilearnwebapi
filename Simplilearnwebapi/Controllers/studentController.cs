using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using HelperLibrary;
using Simplilearnwebapi.Models;

namespace Simplilearnwebapi.Controllers
{
    public class studentController : ApiController
    {
        // GET: api/student
       
        schoolsmethod s = null;
        public studentController()
        {
            s = new schoolsmethod();

        }
        List<studentmodel> s2 = new List<studentmodel>();
        [Route("Getallstudents")]
        public IEnumerable<studentmodel> Get()
        {
            List<student> m = s.getstudents();
            foreach(var item in m)
            {
                studentmodel s1 = new studentmodel();
                s1.studid = item.studid;
                s1.studentname = item.studname;
                s1.marks = Convert.ToInt32(item.marks);
                s1.subjects = item.subjects;
                s2.Add(s1);
            }
            return s2;

        }

        // GET: api/student/5
        [Route("Findstudent/{id}")]
        public studentmodel Get(int id)
        {
            studentmodel m = new studentmodel();
            student t = s.findstudent(id);
            m.studid = t.studid;
            m.studentname = t.studname;
            m.subjects = t.subjects;
            m.marks = t.marks;
            return m;
        }

        // POST: api/student
        [Route("Addstudent")]
        public HttpResponseMessage Post([FromBody]studentmodel value)
        {
            student s1=new student();
            s1.studid = value.studid;
            s1.studname = value.studentname;
            s1.subjects = value.subjects;
            s1.marks = value.marks;
            bool k = s.addstudent(s1);
            if (k)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);

            }

        }
        [Route("Updatestudent/{id}")]
        // PUT: api/student/5
        public HttpResponseMessage Put(int id, [FromBody]studentmodel value)
        {
            student s1 = new student();
            s1.studid = value.studid;
            s1.studname = value.studentname;
            s1.subjects = value.subjects;
            s1.marks = value.marks;
            bool k = s.updatestudent(id,s1);
            if (k)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);

            }
        }

        // DELETE: api/student/5
        [Route("deletestudent/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            bool k = s.deletestudent(id);
            if (k)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);

            }
        }
    }
}
