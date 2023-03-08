using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFG_Task_1
{
    internal class Program
    {
        // header information about the assessment
        public string studentIntroduction =
            "Game Programming Year 1 - CUA51020/ICT50220 - CAN - 2023\n" +
            "Maths for Games \n" +
            "Assessment Task 1 - Custom Data Types\n" +
            "Competency: PGDMTH6005\t\tApply fundamental games programming mathematics skills\n" +
            "Competency: CUADIG511\t\tCoordinate testing of interactive media products\n" +
            "Student name (Last, First): Kerr, Zora\n" +
            "Student ID: (s220780)\n\n\n" +
            "Criteria 1. Vector types for 3D vectors\n" +
            "\tWrite Vector data types for 3D vectors, including homogeneous 3D vectors. Types implement methods for, in all instances, translation, scale, magnitude, normalisation, cross product and dot product. All written code conforms to the provided brief (in Instructions to Students)\n\n" +
            "Criteria 2. Matrix types for 3D matrices\n" +
            "\tWrite Matrix data types for 3D matrices, including homogeneous 4D matrices. Types implement methods for multiplication, vectors transformation, and transpose. Types implement methods for setting up as rotation matrices. All written code conforms to the provided brief (in Instructions to Students).\n\n" +
            "Critera 3. Color type\n" +
            "\tWrite a Color data type. As part of the Color type, functions for manipulating a bitfield implemented using bit shift operations All written code conforms to the provided brief (in Instructions to Students).\n\n" +
            "Criteria 4. Unit Testing\n" +
            "\tCustom maths data types have been imported into the unit testing project. All custom maths data types pass all unit tests in the provided Unit Testing Project.\n\n";

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.studentIntroduction);
            Console.ReadLine();
        }
            
    }
}
