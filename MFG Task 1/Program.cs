using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Write a collection of custom data types in C#. These will implement the required data types (either as structures or classes) and functions listed below.

Your math data types (i.e., structs or classes) must include the following types. The maths operations should be in column-major order, using a right-handed coordinate system, with the following names of types and functions to ensure that your code works correctly with the Unit Test Application used in Assessment Task 2:

Vector3 (3-dimensional vector using 3 floats)
Vector4 (3-dimensional homogeneous vector using 4 floats)
Matrix3 (2-dimensional 3x3 rotation matrix using 9 float)
Matrix4 (3-dimensional 4x4 transform matrix using 16 float)
Colour (RGBA values stored as a 4 byte integer)
Your types must overload the following mathematical operators and include the additionally mentioned member functions, where V represents a Vector, M represents a Matrix, n represents an index and f represents a float:

V = V + V (point translated by a vector)
V = V – V (point translated by a vector)
V = V x f (vector scale)
V = f x V (vector scale)
V = M x V (vector transformation)
M = M x M (matrix concatenation)
f = V.Dot( V )
V = V.Cross( V )
f = V.Magnitude()
Normalize()
setRotateX( f )
setRotateY( f ) and
setRotateZ( f )
If applicable, your types should all have default constructors, and constructors that allow each float element to be set individually, for example:

Vector3 v3; // default
Vector4 v4( 0, 0, 0, 1 );
Matrix3 m3 = Matrix3( 1, 0, 0, 0, 1, 0, 0, 0, 1 );
(Default constructors won't be possible if you are implementing your types as structs, but will be expected if you are writing classes).

Your Color type will have get and set functions/accessors/methods for each colour component that employ bit shifting and bitwise operators to query or modify the individual colour components of the 4 byte integer. For example:

byte Red { get{…} {set{…} }
or, alternatively

byte GetRed();
void SetRed(byte value);

 

Unit Tests
This project contains a series of pre-programmed tests that will validate the implementation of your custom math data types.

To ensure that your code functions correctly, you will use a Unit Test Project to test the accuracy of your mathematical methods in the code you have written for your Maths Data Types.

To demonstrate competency in this subject your custom data types must pass all unit tests provided.



 * Initial understanding:
 * The "custom data types" I have to create will each be a class, which means I'll be creating 5 classes for this task on top of a header Program class.
 * Each class should have a minimum of one default constructor, and if applicable, an overloaded constructor which allows the parameters to be set individually.
 * The overloads do not differentiate between the two types of vectors or the two types of matrices, which means that each one will need 2 overloads for each calculation (eg v3 + v3, v3 + v4, v3 - v3, v3 - v4, etc)
 * 
 * 
 *  INITIAL PLAN OF PROGRAM LAYOUT
 * 1.0.0.0      Class       Program
 * 1.0.1.0      Method      Normalize()
 * 1.0.2.0      Method      setRotateX( f )
 * 1.0.3.0.     Method      setRotateY( f )
 * 1.0.4.0.     Method      setRotateZ( f )
 * 
 * 2.0.0.0      Class       Vector3   (3-dimensional vector using 3 floats)
 * 2.1.0.0      Constructor Default
 * 2.2.0.0      Constructor Overload (3 floats)
 * 2.3.0.0      Operator    +  (Overload: Vector3 + Vector3)
 * 2.4.0.0      Operator    +  (Overload: Vector3 + Vector3)
 * 2.5.0.0      Operator    -  (Overload: Vector3 - Vector3)
 * 2.6.0.0      Operator    -  (Overload: Vector3 - Vector4)
 * 2.7.0.0      Operator    *  (Overload: Vector3 x f [Vector3.magnitude]) 
 * 2.8.0.0      Operator    *  (Overload: Vector3 x f [Vector4.magnitude]) 
 * 2.9.0.0      Operator    *  (Overload: [Vector3.magnitude] x Vector3) 
 * 2.10.0.0     Operator    *  (Overload: [Vector3.magnitude] x Vector4) 
 * 2.11.0.0     Operator    *  (Overload: Matrix3 x Vector3)
 * 2.12.0.0     Operator    *  (Overload: Matrix4 x Vector3)
 * 2.13.0.0     Operator    ?  (Overload: Vector3.Cross [Vector3])
 * 2.14.0.0     Operator    ?  (Overload: Vector3.Cross [Vector4])
 * 
 * 3.0.0.0      Class       Vector4   (3-dimensional homogeneous vector using 4 floats)
 * 3.1.0.0      Constructor Default
 * 3.2.0.0      Constructor Overload (4 floats)
 * 3.3.0.0      Operator    +  (Overload: Vector4 + Vector3)
 * 3.4.0.0      Operator    +  (Overload: Vector4 + Vector3)
 * 3.5.0.0      Operator    -  (Overload: Vector4 - Vector3)
 * 3.6.0.0      Operator    -  (Overload: Vector4 - Vector4)
 * 3.7.0.0      Operator    *  (Overload: Vector4 x f [Vector3.magnitude]) 
 * 3.8.0.0      Operator    *  (Overload: Vector4 x f [Vector4.magnitude]) 
 * 3.9.0.0      Operator    *  (Overload: [Vector4.magnitude] x Vector3) 
 * 3.10.0.0     Operator    *  (Overload: [Vector4.magnitude] x Vector4) 
 * 3.11.0.0     Operator    *  (Overload: Matrix3 x Vector4)
 * 3.12.0.0     Operator    *  (Overload: Matrix4 x Vector4)
 * 3.13.0.0     Operator    ?  (Overload: Vector4.Cross [Vector3])
 * 3.14.0.0     Operator    ?  (Overload: Vector4.Cross [Vector4])
 * 
 * 4.0.0.0      Class       Matrix3   (2-dimensional 3x3 rotation matrix using 9 float)
 * 4.1.0.0      Constructor Default
 * 4.2.0.0      Constructor Overload (9 floats)
 * 4.3.0.0      Operator    * (Overload: Matrix3 * Matrix3)
 * 4.4.0.0      Operator    * (Overload: Matrix3 * Matrix4)
 * 
 * 5.0.0.0      Class       Matrix4   (3-dimensional 4x4 transform matrix using 16 float)
 * 5.1.0.0      Constructor Default
 * 5.2.0.0      Constructor Overload (16 floats)
 * 5.3.0.0      Operator    * (Overload: Matrix4 * Matrix3)
 * 5.4.0.0      Operator    * (Overload: Matrix4 * Matrix4)
 * 
 * 6.0.0.0      Class       Colour    (RGBA values stored as a 4 byte integer)
 * 6.1.0.0      Constructor Default
 * 6.2.0.0      Constructor Overload (4 byte integer)
 * 
 *
 */

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
