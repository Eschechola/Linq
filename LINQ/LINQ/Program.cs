using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {

            /* QUERY EM COLEÇÕES - PEGANDO TODOS OS EMAILS QUE CONTÉM "lucas" - INÍCIO */

            Console.WriteLine("\n\n\n QUERY EM COLEÇÕES - PEGANDO TODOS OS EMAILS QUE CONTÉM \"lucas\" - INÍCIO");
            
            // COLEÇÃO QUE SERÁ UTILIZADA
            var emails = new List<string>
            {
                "lucas.pedro@eu.com",
                "gabriel.lucas@eu.com",
                "joao.pedro@eu.com",
                "pedro.lucas@eu.com",
                "caio.jose@eu.com",
                "julia.maria@eu.com",
                "maria.clara@eu.com",
                "cristina.flavia@eu.com",
                "mariana.santos@eu.com"
            };

            // SEM UTILIZAÇÃO DO LINQ

            var listOfEmailsWithLucas = new List<string>();

            foreach (var email in emails)
            {
                if (email.Contains("lucas"))
                {
                    listOfEmailsWithLucas.Add(email);
                }
            }

            Console.WriteLine("\n\nSem a utilização do LINQ: \n");

            foreach (var email in listOfEmailsWithLucas)
            {
                Console.WriteLine(email.ToString());
            }



            // COM UTILIZAÇÃO DO LINQ

            var listOfEmailsWithLucasLinq = from emailContainLucas in emails
                                            where emailContainLucas.Contains("lucas")
                                            select emailContainLucas;

            Console.WriteLine("\n\nCom a utilização do LINQ: \n");

            foreach (var email in listOfEmailsWithLucasLinq)
            {
                Console.WriteLine(email.ToString());
            }



            /* QUERY EM COLEÇÕES - PEGANDO TODOS OS EMAILS QUE CONTEM LUCAS - FIM */













            Console.WriteLine("\n\n\n");












            /* JOIN - RELACIONANDO COLEÇÕES - INÍCIO */

            Console.WriteLine("\n\n\n JOIN - RELACIONANDO COLEÇÕES - INÍCIO");

            // COLEÇÕES QUE SERÃO UTILIZADAS
            var ocuppations = new List<Ocuppation>
            {
                new Ocuppation { Id = 1, OcuppationName = "Programador" },
                new Ocuppation { Id = 2, OcuppationName = "DBA" },
                new Ocuppation { Id = 3, OcuppationName = "Analista de Infraestrutura" },
                new Ocuppation { Id = 4, OcuppationName = "Técnico em Suporte" }
            };

            var contribuitors = new List<Contribuitor>
            {
                new Contribuitor { Id = 1, OcuppationID = 1, Name = "Lucas" },
                new Contribuitor { Id = 2, OcuppationID = 3, Name = "João" },
                new Contribuitor { Id = 3, OcuppationID = 2, Name = "Maria" },
                new Contribuitor { Id = 4,  OcuppationID = 4, Name = "Pedro", },
            };


            // SEM UTILIZAÇÃO DO LINQ

            var usersJoinedOcuppations = new List<object>();

            for (int i = 0; i < contribuitors.Count; i++)
            {
                for (int j = 0; j < ocuppations.Count; j++)
                {
                    if(contribuitors[i].OcuppationID == ocuppations[j].Id)
                    {
                        usersJoinedOcuppations.Add(new
                        {
                            Name = contribuitors[i].Name,
                            Ocuppation = ocuppations[j].OcuppationName
                        });

                        break;
                    }
                }
            }

            Console.WriteLine("\n\nSem a utilização do LINQ: \n");

            foreach (var userJoined in usersJoinedOcuppations)
            {
                Console.WriteLine(userJoined.ToString());
            }



            // COM UTILIZAÇÃO DO LINQ

            var usersJoinedOcuppationsLinq = from cnt in contribuitors
                                             join ocp in ocuppations
                                             on cnt.OcuppationID equals ocp.Id
                                             select new
                                             {
                                                 Name = cnt.Name,
                                                 OcuppationName = ocp.OcuppationName
                                             };

            Console.WriteLine("\n\nCom a utilização do LINQ: \n");

            foreach (var userJoined in usersJoinedOcuppationsLinq)
            {
                Console.WriteLine(userJoined.ToString());
            }


            /* JOIN - RELACIONANDO COLEÇÕES - FIM */













            Console.WriteLine("\n\n\n");













            /* GROUP BY - AGRUPANDO COLEÇÕES COM ELEMENTOS EM COMUM - INICIO */

            Console.WriteLine("\n\n\nGROUP BY - AGRUPANDO COLEÇÕES COM ELEMENTOS EM COMUM");

            //COLEÇÃO QUE SERÁ UTILIZADA

            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Pedro", Course = "Sistemas de Informação" },
                new Student { Id = 2, Name = "Maria", Course = "Ciência da Computação" },
                new Student { Id = 3, Name = "Júlia", Course = "Matemática" },

                new Student { Id = 4, Name = "Fernanda", Course = "Matemática" },
                new Student { Id = 5, Name = "Paulo", Course = "Sistemas de Informação" },
                new Student { Id = 6, Name = "Julio", Course = "Ciência da Computação" },

                new Student { Id = 7, Name = "Gabriel", Course = "Matemática" },
                new Student { Id = 8, Name = "Mario", Course = "Ciência da Computação" },
                new Student { Id = 9, Name = "Cristina", Course = "Sistemas de Informação" },
            };


            // SEM UTILIZAÇÃO DO LINQ
            var groupSI = new List<object>();
            var groupCC = new List<object>();
            var groupMath = new List<object>();

            foreach(var student in students)
            {
                if(student.Course == "Sistemas de Informação")
                {
                    groupSI.Add(new
                    {
                        Name = student.Name,
                        Course = student.Course
                    });
                }
                else if (student.Course == "Ciência da Computação")
                {
                    groupCC.Add(new
                    {
                        Name = student.Name,
                        Course = student.Course
                    });
                }
                else
                {
                    groupMath.Add(new
                    {
                        Name = student.Name,
                        Course = student.Course
                    });
                }
            }

            Console.WriteLine("\n\nSem a utilização do LINQ: \n");

            Console.WriteLine("\n\nSistemas de Informação: \n");

            foreach(var studentSI in groupSI)
            {
                Console.WriteLine(studentSI.ToString());
            }

            Console.WriteLine("\n\nCiência da Computação: \n");

            foreach (var studentCC in groupCC)
            {
                Console.WriteLine(studentCC.ToString());
            }

            Console.WriteLine("\n\nMatemática: \n");

            foreach (var studentMath in groupMath)
            {
                Console.WriteLine(studentMath.ToString());
            }




            // COM UTILIZAÇÃO DO LINQ
            var studentsLinq = from std in students
                               group std by std.Course into courseGroup
                               orderby courseGroup.Key ascending
                               select courseGroup;

            Console.WriteLine("\n\nCom a utilização do LINQ: \n");

            foreach (var studentGroup in studentsLinq)
            {
                Console.WriteLine("\n\n" + studentGroup.Key + ": \n");

                foreach (var studentGrouped in studentGroup)
                {
                    Console.WriteLine(new
                    {
                        Name = studentGrouped.Name,
                        course = studentGrouped.Course
                    });
                }
            }



            /* GROUP BY - AGRUPANDO COLEÇÕES COM ELEMENTOS EM COMUM - FIM */













            Console.WriteLine("\n\n\n");












            /* EXPRESSÕES LAMBDA - PEGANDO TODOS OS USUARIOS QUE CONTÉM "mariana"  - INÍCO */

            Console.WriteLine("\n\n\n EXPRESSÕES LAMBDA - PEGANDO TODOS OS USUARIOS QUE CONTÉM \"mariana\"");

            // COLEÇÃO QUE SERÁ UTILIZADA
            var names = new List<string>
            {
                "Mariana Andrade",
                "Mariana Silva",
                "Ana Maria",
                "Maria Cláudia",
                "José Pedro",
                "Paulo Silva",
                "Lucas Gabriel",
                "Mariana Cristina",
                "Samuel Rosa"
            };

            // SEM UTILIZAÇÃO DO LINQ

            var listOfnamesWithMariana = new List<string>();

            foreach (var name in names)
            {
                if (name.ToLower().Contains("mariana"))
                {
                    listOfnamesWithMariana.Add(name);
                }
            }

            Console.WriteLine("\n\nSem a utilização do LINQ: \n");

            foreach (var name in listOfnamesWithMariana)
            {
                Console.WriteLine(name.ToString());
            }



            // COM UTILIZAÇÃO DO LINQ

            var listOfNamesWithMarianaLinq = names.Where(n => n.ToLower().Contains("mariana"))
                .ToList();

            Console.WriteLine("\n\nCom a utilização do LINQ: \n");

            foreach (var nameLinq in listOfNamesWithMarianaLinq)
            {
                Console.WriteLine(nameLinq);
            }


            /* EXPRESSÕES LAMBDA - PEGANDO TODOS OS USUARIOS QUE CONTÉM "mariana"  - FIM */


            Console.ReadKey();
        }
    }
}
